/// <summary>
/// 
/// 클래스 요약
///  * 프로그램에서 사용 되는 사용자(카메라)의 시점 좌표와 glControl 위에서의 마우스 커서의 X,Y 좌표를 갖는 클래스.
/// 
/// @param
/// angleX, angleY : 사용자의 좌우, 상하 회전 각도
/// panX, panY, panZ : 사용자의 x,y,z 축의 위치
/// mouseX, mouseY : MouseEvent에서 갱신 된 glControl 영역 위의 커서의 x,y 좌표
/// cameraPos : 사용자(카메라)의 위치(x=0, y=0, z=250)
/// targetPos : 사용자(카메라)의 시선이 향하는 위치(원점)
/// upDirection : x,y,z 축 중에서 위쪽 방향을 향하는 축. 해당 축만 1.0f. 그 외에는 0.0f
/// 
/// @functioin
/// Initialize : 새로운 파일 로드시, 이벤트로 인한 시점 변화시, 시점을 초기화
/// 
/// </summary>

using OpenTK;

namespace objViewer.InfoClass
{
    class ViewInfo
    {
        private float angleX, angleY, panX, panY, panZ;
        private int mouseX, mouseY;
        private Vector3 cameraPos, targetPos, upDirection;

        public ViewInfo()
        {
            angleX = 0.0f;
            angleY = 0.0f;
            panX = 0.0f;
            panY = -86.0f;
            panZ = 0.0f;
            mouseX = 0;
            mouseY = 0;

            cameraPos = new Vector3(0.0f, 0.0f, 250.0f);
            targetPos = new Vector3();
            upDirection = new Vector3(0.0f, 1.0f, 0.0f);
        }

        public void Initialize()
        {
            angleX = 0;
            angleY = 0;
            panX = 0;
            panY = -86.0f;
            panZ = 0;
            mouseX = 0;
            mouseY = 0;
        }

        #region Getter and Setter
        public float AngleX
        {
            get { return angleX; }
            set { angleX = value; }
        }

        public float AngleY
        {
            get { return angleY; }
            set { angleY = value; }
        }

        public float PanX
        {
            get { return panX; }
            set { panX = value; }
        }

        public float PanZ
        {
            get { return panZ; }
            set { panZ = value; }
        }

        public float PanY
        {
            get { return panY; }
            set { panY = value; }
        }

        public int MouseX
        {
            get { return mouseX; }
            set { mouseX = value; }
        }

        public int MouseY
        {
            get { return mouseY; }
            set { mouseY = value; }
        }

        public Vector3 CameraPos
        {
            get { return cameraPos; }
        }

        public Vector3 TargetPos
        {
            get { return targetPos; }
        }

        public Vector3 UpDirection
        {
            get { return upDirection; }
        }
        #endregion
    }
}
