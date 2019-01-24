using System;
using System.Windows.Forms;

namespace objViewer
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// 
        /// * MainForm : winform 구성 및 전체적인 기능 실행
        /// 
        /// * Draw : glControl 화면에 그리는 작업 묶음
        ///     ㄴLineDraw - 라인
        ///     ㄴObjDraw - 오브젝트와 격자, 라인 총괄
        /// 
        /// * InfoClass : 값전달을 위한 정보 묶음 클래스
        ///     ㄴLineInfo - LineDraw에서 사용하는 한 라인이 갖는 정보에 대한 클래스
        ///     ㄴViewInfo - 뷰어 전체의 시점과 오브젝트의 위치 좌표에 대한 클래스
        ///     ㄴDrawRefInfo - 프로그램 전반에서 참조하는 draw에서 사용하는 bool 변수와 Color 값에 대한 클래스
        /// 
        /// * InputEvent : input 이벤트 묶음
        ///     ㄴMouseEvent - 마우스 이벤트
        ///     ㄴKeyEvent - 키보드 이벤트
        ///  
        /// * ObjParse : obj 파일 파싱
        ///     ㄴObjMesh - obj파일로 부터 읽어들인 데이터로 오브젝트 렌더링
        ///     ㄴObjMeshLoader - obj파일 파싱
        /// 
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
