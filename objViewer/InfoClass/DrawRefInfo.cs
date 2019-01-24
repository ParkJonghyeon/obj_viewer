/// <summary>
/// 
/// 클래스 요약
///  * 프로그램에서 mesh 렌더링에 참조 되는 사용자의 옵션 선택 값과 bool 변수들에 대한 클래스.
/// 
/// @param
/// gridLineColor : 격자의 선 색의 사용자 선택값
/// lineColor, lineWidth : mesh 위에 그려질 선의 색과 크기의 사용자 선택값
/// objColor, bgColor : mesh의 색과 배경 색의 사용자 선택값
/// isDrawGrid : 격자 표시 선택 값
/// isDrawLine : 선 그리기 작업 선택 값
/// isDrawFace : 폴리곤 렌더링 전환 선택 값
/// vertexSelect : isDrawLine이 true일 때, 마우스를 좌클릭 한 경우 true. 선 그리기에 사용하는 bool값
/// vertexDelete : isDrawLine이 true일 때, 마우스를 우클릭 한 경우 true. 선 지우기에 사용하는 bool값
/// 
/// </summary>

using System.Drawing;

namespace objViewer.InfoClass
{
    class DrawRefInfo
    {
        private Color gridLineColor, lineColor, objColor, bgColor;
        private int lineWidth;
        private bool isDrawGrid, isDrawLine, isDrawFace;
        private bool vertexAdd, vertexDelete;

        public DrawRefInfo()
        {
            gridLineColor = Color.White;
            lineColor = Color.White;
            objColor = Color.White;
            bgColor = Color.Black;

            lineWidth = 5;
            
            isDrawGrid = false;
            isDrawLine = false;
            isDrawFace = false;

            vertexAdd = false;
            vertexDelete = false;
        }

        #region Getter and Setter
        public Color GridLineColor
        {
            get { return gridLineColor; }
            set { gridLineColor = value; }
        }

        public Color LineColor
        {
            get { return lineColor; }
            set { lineColor = value; }
        }

        public Color ObjColor
        {
            get { return objColor; }
            set { objColor = value; }
        }

        public Color BgColor
        {
            get { return bgColor; }
            set { bgColor = value; }
        }

        public int LineWidth
        {
            get { return lineWidth; }
            set { lineWidth = value; }
        }

        public bool IsDrawGrid
        {
            get { return isDrawGrid; }
            set { isDrawGrid = value; }
        }

        public bool IsDrawLine
        {
            get { return isDrawLine; }
            set { isDrawLine = value; }
        }

        public bool IsDrawFace
        {
            get { return isDrawFace; }
            set { isDrawFace = value; }
        }

        public bool VertexAdd
        {
            get { return vertexAdd; }
            set { vertexAdd = value; }
        }

        public bool VertexDelete
        {
            get { return vertexDelete; }
            set { vertexDelete = value; }
        }
    }
    #endregion
}
