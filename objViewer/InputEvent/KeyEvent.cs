/// <summary>
/// 
/// 클래스 요약
///  * 키 입력이 발생 할 경우 처리할 이벤트들에 대한 클래스.
/// 
/// @params
/// glControl, viewInfo : MainForm에서 생성자를 통해 객체를 받아온다 (클래스 간 상호 작용을 위한 Call by Reference).
/// movePoint : 한번 키 입력에 이동 할 수치
/// 
/// @functioin
/// KeyEvent : 입력 키 코드에 따른 viewInfo의 대응 값들의 가감 처리
/// 
/// </summary>

using System.Windows.Forms;
using OpenTK;

using objViewer.InfoClass;

namespace objViewer.InputEvent
{
    class KeyEvent
    {
        GLControl glControl = null;
        ViewInfo viewInfo = null;
        int movePoint = 2;

        public KeyEvent(GLControl GLControl, ViewInfo viewInfo)
        {
            this.glControl = GLControl;
            this.viewInfo = viewInfo;
        }

        public void glControl_KeyPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.W:
                    viewInfo.PanY += movePoint;
                    break;
                case Keys.S:
                    viewInfo.PanY -= movePoint;
                    break;
                case Keys.A:
                    viewInfo.PanX += movePoint;
                    break;
                case Keys.D:
                    viewInfo.PanX -= movePoint;
                    break;
                case Keys.Q:
                    viewInfo.AngleX -= movePoint;
                    if (viewInfo.AngleX < 0)
                        viewInfo.AngleX += 360;
                    break;
                case Keys.E:
                    viewInfo.AngleX += movePoint;
                    if (viewInfo.AngleX > 360)
                        viewInfo.AngleX -= 360;
                    break;
                case Keys.R:
                    viewInfo.AngleY -= movePoint;
                    if (viewInfo.AngleX < 0)
                        viewInfo.AngleX += 360;
                    break;
                case Keys.F:
                    viewInfo.AngleY += movePoint;
                    if (viewInfo.AngleY > 360)
                        viewInfo.AngleY -= 360;
                    break;
                default:
                    break;
            }

            glControl.Invalidate();
        }
    }
}
