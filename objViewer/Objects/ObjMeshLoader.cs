/// <summary>
/// 
/// 클래스 요약
///  * 전달 받은 경로에 위치한 obj파일을 읽어 내부 텍스트를 파싱
///  파싱한 값들을 ObjMesh로 전달
/// 
/// @functioin
/// Load : ObjMesh에서 호출 되어 파일명과 호출한 ObjMesh 객체를 ReadFile에 전달하여 파싱 시작
/// ReadFile : obj파일을 읽어 파싱
/// ParseFaceParameter : 폴리곤 구성 정보를 담은 face parameter를 파싱하여 FindOrAddObjVertex의 결과값인 인덱스 값을 반환
/// FindOrAddObjVertex : ParseFaceParameter에서 전달 받은 값들로 Dictionary에 값을 저장하거나 기존에 존재하는 값의 인덱스 반환
/// 
/// </summary>

using System;
using System.IO;
using System.Collections.Generic;
using OpenTK;
using System.Linq;

namespace objViewer.Objects
{
    public class ObjMeshLoader
    {
        public static bool Load(ObjMesh mesh, string fileName)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    ReadFile(mesh, streamReader);
                    streamReader.Close();
                    return true;
                }
            }
            catch { return false; }
        }

        static char[] splitCharacters = new char[] { ' ' };

        static List<Vector3> vertices;
        
        static List<Vector3> normals;
        static List<Vector2> texCoords;
        static Dictionary<ObjMesh.ObjVertex, uint> objVerticesIndexDictionary;
        static List<ObjMesh.ObjVertex> objVertices;
        static List<ObjMesh.ObjTriangle> objTriangles;
        static List<ObjMesh.ObjQuad> objQuads;
        
        static void ReadFile(ObjMesh mesh, TextReader textReader)
        {
            vertices = new List<Vector3>();
            normals = new List<Vector3>();
            texCoords = new List<Vector2>();
            objVerticesIndexDictionary = new Dictionary<ObjMesh.ObjVertex, uint> ();
            objVertices = new List<ObjMesh.ObjVertex>();
            objTriangles = new List<ObjMesh.ObjTriangle>();
            objQuads = new List<ObjMesh.ObjQuad>();
            
            string line;
            while ((line = textReader.ReadLine()) != null)
            {
                line = line.Trim(splitCharacters);
                line = line.Replace("  ", " ");

                string[] parameters = line.Split(splitCharacters);
                switch (parameters[0])
                {
                    case "p": // Point
                        break;

                    case "v": // Vertex
                        float x = float.Parse(parameters[1]);
                        float y = float.Parse(parameters[2]);
                        float z = float.Parse(parameters[3]);
                        vertices.Add(new Vector3(x, y, z));
                        break;

                    case "vt": // TexCoord
                        float u = float.Parse(parameters[1]);
                        float v = float.Parse(parameters[2]);
                        texCoords.Add(new Vector2(u, v));
                        break;

                    case "vn": // Normal
                        float nx = float.Parse(parameters[1]);
                        float ny = float.Parse(parameters[2]);
                        float nz = float.Parse(parameters[3]);
                        normals.Add(new Vector3(nx, ny, nz));
                        break;

                    case "f":
                        switch (parameters.Length)
                        {
                            case 4:
                                ObjMesh.ObjTriangle objTriangle = new ObjMesh.ObjTriangle();
                                objTriangle.Index0 = ParseFaceParameter(parameters[1]);
                                objTriangle.Index1 = ParseFaceParameter(parameters[2]);
                                objTriangle.Index2 = ParseFaceParameter(parameters[3]);
                                objTriangles.Add(objTriangle);
                                break;

                            case 5:
                                ObjMesh.ObjQuad objQuad = new ObjMesh.ObjQuad();
                                objQuad.Index0 = ParseFaceParameter(parameters[1]);
                                objQuad.Index1 = ParseFaceParameter(parameters[2]);
                                objQuad.Index2 = ParseFaceParameter(parameters[3]);
                                objQuad.Index3 = ParseFaceParameter(parameters[4]);
                                objQuads.Add(objQuad);
                                break;
                        }
                        break;
                }
            }

            mesh.Vertices = objVertices.ToArray();
            mesh.Triangles = objTriangles.ToArray();
            mesh.Quads = objQuads.ToArray();

            objVerticesIndexDictionary = null;
            vertices = null;
            normals = null;
            texCoords = null;
            objVertices = null;
            objTriangles = null;
            objQuads = null;            
        }
        
        static char[] faceParamaterSplitter = new char[] { '/' };
        static UInt32 ParseFaceParameter(string faceParameter)
        {
            Vector3 vertex = new Vector3();
            Vector2 texCoord = new Vector2();
            Vector3 normal = new Vector3();

            string[] parameters = faceParameter.Split(faceParamaterSplitter, StringSplitOptions.None);

            int vertexIndex = int.Parse(parameters[0]);
            if (vertexIndex < 0) vertexIndex = vertices.Count + vertexIndex;
            else vertexIndex = vertexIndex - 1;
            vertex = vertices[vertexIndex];

            if (parameters.Length > 1 && texCoords.Count > 0 && parameters[1].Length > 0)
            {
                int texCoordIndex = int.Parse(parameters[1]);
                if (texCoordIndex < 0) texCoordIndex = texCoords.Count + texCoordIndex;
                else texCoordIndex = texCoordIndex - 1;
                texCoord = texCoords[texCoordIndex];
            }

            if (parameters.Length > 2 && normals.Count > 0)
            {
                int normalIndex = int.Parse(parameters[2]);
                if (normalIndex < 0) normalIndex = normals.Count + normalIndex;
                else normalIndex = normalIndex - 1;
                normal = normals[normalIndex];
            }
            return FindOrAddObjVertex(ref vertex, ref texCoord, ref normal);
        }

        static UInt32 FindOrAddObjVertex(ref Vector3 vertex, ref Vector2 texCoord, ref Vector3 normal)
        {
            ObjMesh.ObjVertex newObjVertex = new ObjMesh.ObjVertex();
            newObjVertex.Vertex = vertex;
            newObjVertex.TexCoord = texCoord;
            newObjVertex.Normal = normal;

            UInt32 index;
            if (objVerticesIndexDictionary.TryGetValue(newObjVertex, out index))
            {
                return index;
            }
            else
            {
                objVertices.Add(newObjVertex);
                objVerticesIndexDictionary[newObjVertex] = (UInt32)(objVertices.Count - 1);
                
                return (UInt32)(objVertices.Count - 1);
            }
        }
    }
}