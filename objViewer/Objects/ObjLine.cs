/// <summary>
/// 
/// 클래스 요약
///  * 사용자가 mesh 위에 그린 선 하나에 대한 객체.
/// 
/// @param
/// id : 객체의 id값. 객체 selection을 위한 pushName에서의 인자값과 dictionary의 key값으로 사용
/// lineColor, lineWidth : 선의 색상과 크기
/// startVertex, endVertex : 시작 점과 끝 점의 xyz 좌표 값
/// 
/// </summary>

using System.Drawing;
using OpenTK;

namespace objViewer.Objects
{
    class LineObj
    {
        private int id;
        private Color lineColor;
        private int lineWidth;
        private Vector3 startVertex;
        private Vector3 endVertex;

        public LineObj(int vertexId)
        {
            id = vertexId;
            lineColor = Color.White;
            LineWidth = 5;
            startVertex = new Vector3();
            endVertex = new Vector3();
        }

        public LineObj(Vector3 sV)
        {
            id = -1;
            lineColor = Color.White;
            lineWidth = 5;
            startVertex = sV;
            endVertex = new Vector3();
        }

        #region Getter and Setter
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Vector3 StartVertex
        {
            get { return startVertex; }
            set { startVertex = value; }
        }

        public Vector3 EndVertex
        {
            get { return endVertex; }
            set { endVertex = value; }
        }

        public Color LineColor
        {
            get { return lineColor; }
            set { lineColor = value; }
        }

        public int LineWidth
        {
            get { return lineWidth; }
            set { lineWidth = value; }
        }
        #endregion

        // id가 같으면 같은 객체로 처리하도록 override
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            LineObj compare = obj as LineObj;
            if (compare == null) return false;
            else return this.Id.Equals(compare.Id);
        }
        
        public override int GetHashCode()
        {
            return this.Id;            
        }
    }
}
