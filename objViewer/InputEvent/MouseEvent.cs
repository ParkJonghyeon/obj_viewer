/// <summary>
/// 
/// 클래스 요약
///  * 마우스 입력이 발생 할 경우 처리할 이벤트들에 대한 클래스.
/// 
/// @params
/// glControl, viewInfo, drawRefInfo : MainForm에서 생성자를 통해 객체를 받아온다 (클래스 간 상호 작용을 위한 Call by Reference).
/// 
/// @functioin
/// glControl_MouseDown : 마우스 버튼이 glControl 영역 위에서 눌릴 때 발생하는 이벤트. 좌/우 버튼에 따라 vertex 추가, 삭제를 위한 bool 변수 true
/// glControl_MouseMove : 마우스가 glControl 영역 위에서 이동 할 때 발생하는 이벤트. ViewInfo의 mouseX,Y 값 갱신
/// glControl_MouseWheel : 마우스 휠이 glControl 영역 위에서 움직일 때 발생하는 이벤트. 휠 방향에 따라 PanZ의 값 가감
/// 
/// </summary>

using System.Windows.Forms;
using OpenTK;

using objViewer.InfoClass;

namespace objViewer.InputEvent
{
    class MouseEvent
    {
        GLControl glControl = null;
        ViewInfo viewInfo = null;
        DrawRefInfo drawRefInfo = null;

        public MouseEvent(GLControl GLControl, ViewInfo viewInfo, DrawRefInfo drawRefInfo)
        {
            this.glControl = GLControl;
            this.viewInfo = viewInfo;
            this.drawRefInfo = drawRefInfo;
        }

        public void glControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawRefInfo.IsDrawLine)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        drawRefInfo.VertexAdd = true;
                        glControl.Invalidate();
                        break;
                    case MouseButtons.Right:
                        drawRefInfo.VertexDelete = true;
                        glControl.Invalidate();
                        break;
                }
            }
        }

        public void glControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawRefInfo.IsDrawLine)
            {
                viewInfo.MouseX = e.X;
                viewInfo.MouseY = e.Y;
                glControl.Invalidate();
            }
        }

        public void glControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                viewInfo.PanZ -= 10.0f;
            }
            else
            {
                viewInfo.PanZ += 10.0f;
            }
            glControl.Invalidate();
        }
    }
}
