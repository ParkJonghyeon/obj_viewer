/// <summary>
/// 
/// 클래스 요약
///  * MainForm의 구성요소 및 프로그램이 기본적인 동작을 수행하는 부분
///  사용자의 입력을 받아 이벤트 객체들에게 전달 및 objDraw 객체를 호출하여 화면상에 mesh와 line을 그리도록 함
///  사용자의 입력 결과는 Info 클래스들을 통해서 참조 값을 수정
///  objDraw는 Info 클래스들의 값을 참조하여 glControl.Invalidate()가 호출 될 때 마다 화면을 새로 그린다.
/// 
/// </summary>

using System;
using System.Drawing;
using System.Windows.Forms;

using objViewer.Draw;
using objViewer.InputEvent;
using objViewer.InfoClass;

namespace objViewer
{
    public partial class MainForm : Form
    {
        public enum LineSize { SLINE = 1, MLINE = 5, LLINE = 10 }; // 라인 두께의 한계는 최소 1에서 10이므로 총 3개의 선택 값으로 제한

        ObjDraw objDraw = null;
        MouseEvent mouseEvent = null;
        KeyEvent keyEvent = null;
        ViewInfo viewInfo = null;
        DrawRefInfo drawRefInfo = null;

        #region MainForm
        public MainForm()
        {
            InitializeComponent();
            
            viewInfo = new ViewInfo();
            drawRefInfo = new DrawRefInfo();
            objDraw = new ObjDraw(this.glControl, viewInfo, drawRefInfo);
            mouseEvent = new MouseEvent(this.glControl, viewInfo, drawRefInfo);
            keyEvent = new KeyEvent(this.glControl, viewInfo);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.glControl.Width = this.Width;
            this.glControl.Height = this.statusStrip.Location.Y - 1;
            this.labelLineInfo.Location = new Point(this.Width - 150, this.statusStrip.Location.Y + 1);
            this.lineColorPreView.Location = new Point(this.labelLineInfo.Location.X + 80, this.labelLineInfo.Location.Y);

            this.lineColorPreView.BackColor = this.colorDialog.Color;
            this.middleMToolStripMenuItem.Checked = true;
            drawRefInfo.LineWidth = (int)LineSize.MLINE;
            drawRefInfo.LineColor = this.colorDialog.Color;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.glControl.Width = this.Width;
            this.glControl.Height = this.statusStrip.Location.Y - 1;
            this.labelLineInfo.Location = new Point(this.Width - 150, this.statusStrip.Location.Y + 1);
            this.lineColorPreView.Location = new Point(this.labelLineInfo.Location.X + 80, this.labelLineInfo.Location.Y);
        }
        #endregion

        #region glControl
        private void glControl_Load(object sender, EventArgs e)
        {
            glControl.MouseDown += new MouseEventHandler(mouseEvent.glControl_MouseDown);
            glControl.MouseMove += new MouseEventHandler(mouseEvent.glControl_MouseMove);
            glControl.MouseWheel += new MouseEventHandler(mouseEvent.glControl_MouseWheel);
            glControl.KeyDown += new KeyEventHandler(keyEvent.glControl_KeyPress);

            objDraw.InitGLControl();
        }

        // glControl_Load 이후, 또는 glControl1.Invalidate() 호출 시에 실행
        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            objDraw.ObjectPaint();
            glControl.Select(); // glControl에 오토 포커스. glControl에 포커스 되어있지 않으면 이벤트 클래스가 이벤트를 인식하지 못함
        }
        #endregion

        #region File MenuItems
        private void openobjFileToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            this.openFileDialog.DefaultExt = "obj";
            this.openFileDialog.Filter = "Images Files(*.obj)|*.obj";

            DialogResult result = this.openFileDialog.ShowDialog();

            if (result == DialogResult.OK && this.openFileDialog.FileNames.Length > 0)
            {
                foreach (string filePath in this.openFileDialog.FileNames)
                {
                    this.toolStripStatusLabelFileRoot.Text = "file://" + filePath;
                    objDraw.setFile(filePath);
                    viewInfo.Initialize();
                    glControl.Invalidate();

                    this.drawLineToolStripMenuItem.Checked = false;
                }
            }
        }

        private void closeXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Draw Line MenuItems
        private void drawLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.drawLineToolStripMenuItem.Checked = ! this.drawLineToolStripMenuItem.Checked;
        }

        private void drawLineToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            drawRefInfo.IsDrawLine = this.drawLineToolStripMenuItem.Checked;
            glControl.Invalidate();
        }
        
        private void colorCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectColor();
        }

        // lineColorPreView_Click에서도 사용함.
        private void selectColor()
        {
            DialogResult result = this.colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.lineColorPreView.BackColor = colorDialog.Color;
                drawRefInfo.LineColor = colorDialog.Color;
            }
        }
        
        private void widthWToolStripMenuItem1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.smallSToolStripMenuItem.Checked = false;
            this.middleMToolStripMenuItem.Checked = false;
            this.largeLToolStripMenuItem.Checked = false;

            switch (e.ClickedItem.Name)
            {
                case "smallSToolStripMenuItem":
                    this.smallSToolStripMenuItem.Checked = true;
                    drawRefInfo.LineWidth = (int)LineSize.SLINE;
                    break;
                case "middleMToolStripMenuItem":
                    this.middleMToolStripMenuItem.Checked = true;
                    drawRefInfo.LineWidth = (int)LineSize.MLINE;
                    break;
                case "largeLToolStripMenuItem":
                    this.largeLToolStripMenuItem.Checked = true;
                    drawRefInfo.LineWidth = (int)LineSize.LLINE;
                    break;
            }
        }
        #endregion

        #region Camera View MenuItems
        private void cameraCToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            viewInfo.Initialize();

            switch (e.ClickedItem.Name)
            {
                case "frontFToolStripMenuItem":
                    break;
                case "leftLToolStripMenuItem":
                    viewInfo.AngleX = -90;
                    break;
                case "rightRToolStripMenuItem":
                    viewInfo.AngleX = 90;
                    break;
                case "backBToolStripMenuItem":
                    viewInfo.AngleX = -180;
                    break;
                case "upUToolStripMenuItem":
                    viewInfo.PanY = 0;
                    viewInfo.AngleY = 90;
                    break;
                case "downDToolStripMenuItem":
                    viewInfo.PanY = 0;
                    viewInfo.AngleY = -90;
                    break;
            }
            glControl.Invalidate();
        }
        #endregion

        #region Option MenuItems
        private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.showGridToolStripMenuItem.Checked = ! this.showGridToolStripMenuItem.Checked;
            drawRefInfo.IsDrawGrid = this.showGridToolStripMenuItem.Checked;
            glControl.Invalidate();
        }

        private void drawFaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.drawFaceToolStripMenuItem.Checked = ! this.drawFaceToolStripMenuItem.Checked;
            drawRefInfo.IsDrawFace = this.drawFaceToolStripMenuItem.Checked;
            glControl.Invalidate();
        }

        private void etcColorChangeEToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DialogResult result = this.colorDialog.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                switch (e.ClickedItem.Name)
                {
                    case "bgColorChangeBToolStripMenuItem":
                        drawRefInfo.BgColor = colorDialog.Color;
                        break;
                    case "objColorChangeOToolStripMenuItem":
                        drawRefInfo.ObjColor = colorDialog.Color;
                        break;
                    case "gridColorChangeGToolStripMenuItem":
                        drawRefInfo.GridLineColor = colorDialog.Color;
                        break;
                }
            }
            glControl.Invalidate();
        }
        #endregion

        private void lineColorPreView_Click(object sender, EventArgs e)
        {
            selectColor();
        }
    }
}