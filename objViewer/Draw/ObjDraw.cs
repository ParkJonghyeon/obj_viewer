/// <summary>
/// 
/// 클래스 요약
///  * glControl에 mesh를 그리는 클래스. drawRefInfo의 값에 의해 grid와 line을 그리기도 함.
/// 
/// @param
/// mouseCoordOn3d : glControl에 그려진 공간상의 3차원 좌표 값을 마우스의 x,y 좌표를 통해 저장
/// mouseInObject : 마우스 커서가 유효한 영역 위에 위치했는지 판별
/// addStartVertex : line의 시작 점을 찍었는지 끝 점을 찍었는지 판별
/// 
/// @functioin
/// setFile : 전달 받은 파일 경로를 ObjMesh로 전달
/// InitGLControl : glControl 최초 로딩 시에 한번만 호출. 첫 호출 이후 값의 변화 없는 값들
/// ObjectPaint : MainForm에서 접근하여 glControl에 그리기 시작하는 함수
/// Get3dVertexPosition : 화면에서 클릭한 점의 3D 좌표 획득
/// SetupViewport3D : 3D 뷰포트 설정
/// SetupLighting : 폴리곤 렌더링 시에만 광원 활성화
/// DrawAll : drawRefInfo 값에 따라서 그려야 할 모든 객체를 glControl상에 그려줌
/// TrackingAndDrawPoint : mesh 위에 커서를 따라 pointer를 그리고 클릭 지점에서 AddLine을 실행
/// AddLine : addStartVertex 값에 따라서 선의 시작 점과 끝 점 좌표를 lineDraw에 전달
/// DrawGrid : 격자를 그림
/// 
/// </summary>

using System;
using System.IO;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Glu = OpenTK.Graphics.Glu;

using objViewer.Objects;
using objViewer.InfoClass;

namespace objViewer.Draw
{
    class ObjDraw
    {
        GLControl glControl;
        ViewInfo viewInfo;
        DrawRefInfo drawRefInfo;
        ObjMesh mesh;
        LineDraw lineDraw;

        private String objFileName = "";
        private String objFileDir = "";

        Matrix4 modelview, projection;
        float aspectRatio;

        Vector3 mouseCoordOn3d;
        private bool mouseInObject = false, addStartVertex = true;

        // private const int SELECT_BUFF_SIZE = 256;
        // private uint[] selectBuff;
        // private int hits;

        #region light Value
        float[] lightPosition = { 100.0f, 100.0f, 100.0f, 0.0f }; //광원 위치. 원점에서 위에 위치
        float[] lightAmbient = { 0.5f, 0.5f, 0.5f, 1.0f }; //주변광. 광원에서 모든 방향으로 방출하는 빛
        float[] lightDiffuse = { 0.3f, 0.3f, 0.3f, 1.0f }; //발산광. 조명에서 한방향으로 방출하는 빛
        float[] matSpecular = { 0.2f, 0.2f, 0.2f, 1.0f }; //반사광. 오브젝트가 반사하는 빛
        float[] matShininess = { 20.0f }; //선명도. 오브젝트 표면 반짝임 정도
        #endregion

        public ObjDraw(GLControl glControl, ViewInfo viewInfo, DrawRefInfo drawRefInfo)
        {
            this.glControl = glControl;
            this.viewInfo = viewInfo;
            this.drawRefInfo = drawRefInfo;
            this.lineDraw = new LineDraw();
        }

        public void setFile(String filePath)
        {
            this.objFileName = Path.GetFileName(filePath);
            this.objFileDir = Path.GetDirectoryName(filePath) + "\\";

            if (!objFileName.Equals(""))
            {
                mesh = new ObjMesh(objFileDir + objFileName);
                mesh.Prepare();
                lineDraw.InitLineDraw();
            }
        }
        
        public void InitGLControl()
        {
            aspectRatio = glControl.Width / (float)glControl.Height;
            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 0.01f, 2048.0f);
            modelview = Matrix4.LookAt(viewInfo.CameraPos, viewInfo.TargetPos, viewInfo.UpDirection);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.PointSmooth);
            GL.Enable(EnableCap.LineSmooth);

            GL.ShadeModel(ShadingModel.Smooth);

            GL.Material(MaterialFace.Front, MaterialParameter.Specular, matSpecular);
            GL.Material(MaterialFace.Front, MaterialParameter.Shininess, matShininess);
            GL.Light(LightName.Light0, LightParameter.Position, lightPosition);
            GL.Light(LightName.Light0, LightParameter.Ambient, lightAmbient);
            GL.Light(LightName.Light0, LightParameter.Diffuse, lightDiffuse);

            GL.Enable(EnableCap.ColorMaterial);
        }

        public void ObjectPaint()
        {
            if (drawRefInfo.IsDrawLine)
            {
                mouseInObject = Get3dVertexPosition(viewInfo.MouseX, viewInfo.MouseY);
            }

            SetupViewport3D();
            SetupLighting();
            DrawAll();

            /*if (drawRefInfo.VertexDelete)
            {
                // SelectObject의 반환 값으로 선택 된 라인의 name값을 전달하여 선택 된 라인 객체를 삭제함
                // lineDraw.deleteVertex(SelectObject(viewInfo.MouseX, viewInfo.MouseY));
                drawRefInfo.VertexDelete = false;
            }*/
        }

        /**
         * glControl 방식의 x,y 좌표를 윈도우 방식의 x,y 좌표로 변환 및 Z-buffer 값을 찾아냄. (winX/Y/Z)
         * winZ의 경우 GL.ReadPixels를 통해서 현재 커서가 가르키는 물체의 공간상에서의 z좌표를 읽어와 사용함.
         * 커서가 물체에서 벗어날 경우 다른 좌표를 찍게 되는데 면이 아닌 점인 경우,
         * 마우스가 점 위에 위치하지 않으면 잘못 된 좌표를 찾게 될 수 있으므로 주의해야함.
         * 
         * OpenTK.Graphics.Glu에서 지원하는 UnProject 함수를 통해서 mouseCoordOn3d에 3차원 위치 좌표를 저장
         * */
        private bool Get3dVertexPosition(int mouseX, int mouseY)
        {
            int[] viewport = new int[4];
            double[] modelMatrix = new double[16];
            double[] projMatrix = new double[16];

            float winX = 0, winY = 0, winZ = 0;

            GL.GetInteger(GetPName.Viewport, viewport);
            GL.GetDouble(GetPName.ModelviewMatrix, modelMatrix);
            GL.GetDouble(GetPName.ProjectionMatrix, projMatrix);

            winX = mouseX;
            winY = viewport[3] - mouseY;
            GL.ReadPixels((int)winX, (int)winY, 1, 1, PixelFormat.DepthComponent, PixelType.Float, ref winZ);

            Glu.UnProject(new Vector3(winX, winY, winZ), modelMatrix, projMatrix, viewport, out mouseCoordOn3d);
            
            if ((mouseCoordOn3d.X < 500 && mouseCoordOn3d.X > -500))
            {
                if ((mouseCoordOn3d.Z < 500 && mouseCoordOn3d.Z > -500))
                    return true; // 원점으로부터 전후좌우 500 이내의 영역은 mesh 위의 점이라고 판단한다.
                else
                    return false;
            }
            else
                return false;
        }

        /**
         * 현재 당장 구현할 기능은 아님.
         * 기기 도착 이후 값 측정해가면서 필요성 유무를 체크하고
         * 필요가 없다면 지워버릴것
         */

        // 줌을 최대한으로 키워서 셀렉트 하면 버퍼의 7번째에 해당 obj의 네임이 들어가있음
        // 단 줌이 크지 않을 경우 너무 많은 네임 정보를 가져옴. zFar이나 delX, delY의 문제인가 검증 필요함

        // pickmatrix는 픽영역을 설정한 뒤 공간에 시점과 물체를 다시 그려서 픽 영역에 해당하는 부분의 픽을 확인
        // 현재 문제는 화면에 그려진 obj는 모두 이름을 가져와 버리는 문제임
        // 화면에서 벗어난 물체의 이름은 가져오지 않는다. -> pickmatrix에서 지정한 영역의 의미가 없음.
        // 마우스 주변의 인접한 작은 공간만을 쓰도록 해야함.
        /*
        private int SelectObject(int mouseX, int mouseY)
        {
            int selectedObjName = -1;

            int[] viewport = new int[4];
            selectBuff = new uint[SELECT_BUFF_SIZE];
            GL.SelectBuffer(SELECT_BUFF_SIZE, selectBuff);
            GL.GetInteger(GetPName.Viewport, viewport);
            
            GL.RenderMode(RenderingMode.Select);
            GL.PushMatrix();
            GL.InitNames();
            GL.PushName(-1);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Glu.PickMatrix(mouseX, viewport[3] - mouseY, 1, 1, viewport);

            SetupViewport3D();
            DrawAll();
            hits = GL.RenderMode(RenderingMode.Render);


            GL.PopMatrix();

            selectedObjName = (int) selectBuff[7];

            return selectedObjName;
        }*/

        /**
         * @params
         * aspectRatio : 투영 영역의 가로와 세로의 비율. mesh가 찌그러지게 출력 되는 것을 보정
         * */
        private void SetupViewport3D()
        {
            GL.ClearColor(drawRefInfo.BgColor);
            GL.Color3(drawRefInfo.LineColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            GL.Ortho(0, glControl.Width, glControl.Height, 0, 0.01f, 2048.0f);
            GL.Viewport(0, 0, glControl.Width, glControl.Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
        }

        private void SetupLighting()
        {
            if (drawRefInfo.IsDrawFace)
            {
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);
                GL.Enable(EnableCap.CullFace);
            }
            else
            {
                GL.Disable(EnableCap.Lighting);
                GL.Disable(EnableCap.Light0);
                GL.Disable(EnableCap.CullFace);
            }
        }

        private void DrawAll()
        {
            // 원점을 중심으로 카메라의 회전 및 이동. 때문에 Trans -> Rotate 순서
            GL.Translate(-viewInfo.PanX, viewInfo.PanY, viewInfo.PanZ);
            GL.Rotate(viewInfo.AngleY, 1.0f, 0, 0);
            GL.Rotate(viewInfo.AngleX, 0, 1.0f, 0);

            if (drawRefInfo.IsDrawLine && mouseInObject)
            {
                TrackingAndDrawPoint();
            }
            if (drawRefInfo.VertexAdd)
            {
                AddLine(mouseCoordOn3d);
                drawRefInfo.VertexAdd = false;
            }
            
            if (!objFileName.Equals(""))
            {
                mesh.Render(drawRefInfo.IsDrawFace, drawRefInfo.ObjColor);

                if (drawRefInfo.IsDrawLine)
                {
                    lineDraw.drawLine();
                }
            }

            if (drawRefInfo.IsDrawGrid)
                DrawGrid(0, 0, 32, 1536);

            glControl.SwapBuffers();
        }

        private void TrackingAndDrawPoint()
        {
            GL.PointSize(drawRefInfo.LineWidth);
            GL.Color3(drawRefInfo.LineColor);
            GL.Begin(BeginMode.Points);
            GL.Vertex3(mouseCoordOn3d);
            GL.End();

            GL.PointSize(1);
        }

        private void AddLine(Vector3 mouseCoordOn3d)
        {
            if (addStartVertex)
            {
                lineDraw.addStartVertex(mouseCoordOn3d);
                addStartVertex = false;
            }
            else
            {
                lineDraw.addEndVertex(mouseCoordOn3d, drawRefInfo.LineColor, drawRefInfo.LineWidth);
                addStartVertex = true;
            }
        }

        #region DrawGrid
        /** 
         * @params
         * gridColor : 격자 선 색상
         * gridCenterX/Y : 격자의 X,Y 중심 좌표
         * cellSize : 격자 한칸의 길이
         * girdSize : 총 격자의 길이
         * 
         * 격자의 수는 (gridSize/cellSize)^2 만큼 생성 됨
         * */
        private void DrawGrid(float gridCenterX, float gridCenterY, int cellSize = 16, int gridSize = 256)
        {
            int dX = (int)Math.Round(gridCenterX / cellSize) * cellSize;
            int dZ = (int)Math.Round(gridCenterY / cellSize) * cellSize;

            int ratio = gridSize / cellSize;

            int lineCount;

            GL.PushMatrix();
            GL.Translate(dX - gridSize / 2, 0, dZ - gridSize / 2);

            GL.Begin(BeginMode.Lines);
            for (lineCount = 0; lineCount < ratio + 1; lineCount++)
            {
                int current = lineCount * cellSize;

                GL.Color3((lineCount == (ratio + 1) / 2) ? Color.Green : drawRefInfo.GridLineColor); // z축 중간 선만 초록 선으로
                GL.Vertex3(current, 0, 0);
                GL.Vertex3(current, 0, gridSize);

                GL.Color3((lineCount == (ratio + 1) / 2) ? Color.Red : drawRefInfo.GridLineColor); // x축 중간 선만 빨간 선으로
                GL.Vertex3(0, 0, current);
                GL.Vertex3(gridSize, 0, current);
            }
            GL.End();
            GL.PopMatrix();
        }
        #endregion
    }
}
