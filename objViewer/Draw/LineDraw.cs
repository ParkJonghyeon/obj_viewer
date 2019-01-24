/// <summary>
/// 
/// 클래스 요약
///  * 사용자가 mesh 위에 그린 lineInfo 객체들을 관리하고, 일괄적으로 화면상에 그려주는 클래스.
/// 
/// @param
/// lineObjList : lineInfo 객체들의 정보를 담는 list.
/// lineObjId : lineInfo의 id 값. lineInfo 객체에 할당 할 때마다 1씩 증가.
/// 
/// @functioin
/// InitLineDraw : 새로운 파일 로드 시, 전역변수 초기화.
/// addSVertex : 선의 시작 점 클릭 시 tmpLineInfo 객체 생성.
/// addEVertex : 선의 끝 점 클릭 시 tmpLineInfo 객체의 값을 인자로 채우고 dictionary에 add.
/// deleteVertex : 인자로 받은 id와 일치하는 id를 가진 lineInfo 객체를 list에서 삭제
/// drawLine : list에 있는 모든 lineInfo 객체를 glControl에 그림.
/// 
/// </summary>

using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

using objViewer.Objects;

namespace objViewer.Draw
{
    class LineDraw
    {
        private List<LineObj> lineObjList;
        private LineObj tmpLineInfo;
        private int lineObjId = 101;

        public LineDraw()
        {
            lineObjList = new List<LineObj>();
        }

        public void InitLineDraw()
        {
            lineObjList.Clear();
            tmpLineInfo = null;
            lineObjId = 101;
        }

        public void addStartVertex(Vector3 startVertex)
        {
            tmpLineInfo = new LineObj(startVertex);
        }

        public void addEndVertex(Vector3 endVertex, Color vertexColor, int vertexWidth)
        {
            tmpLineInfo.Id = lineObjId++;
            tmpLineInfo.EndVertex = endVertex;
            tmpLineInfo.LineColor = vertexColor;
            tmpLineInfo.LineWidth = vertexWidth;

            lineObjList.Add(tmpLineInfo);
            tmpLineInfo = null;
        }

        public void deleteVertex(int vertexId)
        {
            LineObj removeL = new LineObj(vertexId);
            lineObjList.Remove(removeL);
        }

        public void drawLine()
        {
            if(lineObjList.Count > 0)
            {
                int index;

                //GL.InitNames();

                for (index = 0; index< lineObjList.Count; index++)
                {
                    GL.PushMatrix();
                    GL.LoadName(lineObjList[index].Id);
                    // GL.PushName(lineObjList[index].Id);
                    GL.LineWidth(lineObjList[index].LineWidth);
                    GL.Begin(BeginMode.Lines);
                    GL.Color3(lineObjList[index].LineColor);
                    GL.Vertex3(lineObjList[index].StartVertex);
                    GL.Vertex3(lineObjList[index].EndVertex);
                    GL.End();
                    // GL.PopName();
                    GL.PopMatrix();
                }

                GL.LineWidth(1);
                GL.Color3(Color.White);
            }
        }
    }
}
