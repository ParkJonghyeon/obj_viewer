/// <summary>
/// 
/// 클래스 요약
///  * obj 파일을 파싱하여 얻은 mesh의 정보를 통해 glControl 상에 렌더링 시키는 클래스.
/// 
/// @param
/// vertices : obj 파일에서 읽어들인 TexCoord, Normal, Vertex에 대한 정보를 가진 ObjVertex 구조체
/// triangles, quad : 각각 삼각형, 사각형을 구성하는 정점 인덱스에 대한 Index를 가진 ObjTriangle,ObjQuad 구조체
/// *BufferId : 버퍼 공간 할당 위한 Id값
/// 
/// @functioin
/// Prepare : 렌더링을 위한 버퍼 할당
/// Render : 사용자의 설정에 따라서 getElements를 사용해 점/면으로 렌더링
/// 
/// </summary>

using System;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace objViewer.Objects
{
    public class ObjMesh
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct ObjVertex
        {
            public Vector2 TexCoord;
            public Vector3 Normal;
            public Vector3 Vertex;

            /** 
             * Dictionary를 사용하는데 GetHashCode를 재정의 하지 않을 경우
             * 기본 정의 함수를 사용하게 되는데 이 경우 Dictionary의 탐색 효율이 매우 떨어지게 된다.
             * 때문에 Dictionary를 사용할 경우 field의 HashCode의 XOR 연산을 반환하도록 아래와 같이 재정의를 해야한다.
             * XOR 연산에 사용 할 HashCode의 field는 각 객체/구조체를 구분할 수 있는 값들을 사용하도록 한다.
             * */
            public override int GetHashCode()
            {
                return ( (object.Equals(TexCoord, null) ? 0 : TexCoord.GetHashCode()) ^
                    (object.Equals(Normal, null) ? 0 : Normal.GetHashCode()) ^
                    (object.Equals(Vertex, null) ? 0 : Vertex.GetHashCode()) );
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ObjTriangle
        {
            public UInt32 Index0;
            public UInt32 Index1;
            public UInt32 Index2;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ObjQuad
        {
            public UInt32 Index0;
            public UInt32 Index1;
            public UInt32 Index2;
            public UInt32 Index3;
        }
        
        ObjVertex[] vertices;
        ObjTriangle[] triangles;
        ObjQuad[] quads;
        
        int verticesBufferId = 0;
        int trianglesBufferId = 0;
        int quadsBufferId = 0;
        
        public ObjMesh(string fileName)
        {
            ObjMeshLoader.Load(this, fileName);
        }

        #region Getter and Setter
        public ObjVertex[] Vertices
        {
            get { return vertices; }
            set { vertices = value; }
        }
        
        public ObjTriangle[] Triangles
        {
            get { return triangles; }
            set { triangles = value; }
        }

        public ObjQuad[] Quads
        {
            get { return quads; }
            set { quads = value; }
        }
        #endregion

        public void Prepare()
        {
            if (verticesBufferId == 0)
            {
                GL.GenBuffers(1, out verticesBufferId);
                GL.BindBuffer(BufferTarget.ArrayBuffer, verticesBufferId);
                GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Length * Marshal.SizeOf(typeof(ObjVertex))), vertices, BufferUsageHint.StaticDraw);
            }

            if (trianglesBufferId == 0)
            {
                GL.GenBuffers(1, out trianglesBufferId);
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, trianglesBufferId);
                GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(triangles.Length * Marshal.SizeOf(typeof(ObjTriangle))), triangles, BufferUsageHint.StaticDraw);
            }

            if (quadsBufferId == 0)
            {
                GL.GenBuffers(1, out quadsBufferId);
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, quadsBufferId);
                GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(quads.Length * Marshal.SizeOf(typeof(ObjQuad))), quads, BufferUsageHint.StaticDraw);
            }
        }

        public void Render(bool isDrawFace, Color objColor)
        {            
            GL.PushClientAttrib(ClientAttribMask.ClientVertexArrayBit);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.BindBuffer(BufferTarget.ArrayBuffer, verticesBufferId);
            GL.InterleavedArrays(InterleavedArrayFormat.T2fN3fV3f, Marshal.SizeOf(typeof(ObjVertex)), IntPtr.Zero);
            
            GL.Color3(objColor);

            if (triangles.Length > 0)
            {
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, trianglesBufferId);
                if (isDrawFace)
                {
                    // 와이어 프레임 렌더링이 필요할 경우 사용. 아니라면 삭제 할 것.
                    // GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                    GL.DrawElements(BeginMode.Triangles, triangles.Length * 3, DrawElementsType.UnsignedInt, 0);
                }
                else
                {
                    GL.DrawElements(BeginMode.Points, triangles.Length * 3, DrawElementsType.UnsignedInt, 0);
                }
            }

            if (quads.Length > 0)
            {
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, quadsBufferId);
                if (isDrawFace)
                {
                    // GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line); //폴리곤의 와이어프레임화
                    GL.DrawElements(BeginMode.Quads, quads.Length * 4, DrawElementsType.UnsignedInt, 0);
                }
                else
                {
                    GL.DrawElements(BeginMode.Points, quads.Length * 4, DrawElementsType.UnsignedInt, 0);
                }
            }
            GL.PopClientAttrib();
        }                
    }
}
