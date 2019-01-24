using System;
using System.ComponentModel;

namespace objViewer
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.glControl = new OpenTK.GLControl();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lineColorPreView = new System.Windows.Forms.PictureBox();
            this.labelLineInfo = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.FileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openobjFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LineToolLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.brushOptionBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.widthWToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.smallSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.middleMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frontFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawFaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etcColorChangeEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgColorChangeBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objColorChangeOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColorChangeGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelFileRoot = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lineColorPreView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Location = new System.Drawing.Point(0, 24);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(1026, 539);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // lineColorPreView
            // 
            this.lineColorPreView.BackColor = System.Drawing.Color.White;
            this.lineColorPreView.Location = new System.Drawing.Point(994, 688);
            this.lineColorPreView.Name = "lineColorPreView";
            this.lineColorPreView.Size = new System.Drawing.Size(20, 20);
            this.lineColorPreView.TabIndex = 16;
            this.lineColorPreView.TabStop = false;
            this.lineColorPreView.Click += new System.EventHandler(this.lineColorPreView_Click);
            // 
            // labelLineInfo
            // 
            this.labelLineInfo.Location = new System.Drawing.Point(910, 687);
            this.labelLineInfo.Name = "labelLineInfo";
            this.labelLineInfo.Size = new System.Drawing.Size(84, 21);
            this.labelLineInfo.TabIndex = 1;
            this.labelLineInfo.Text = "Line Color : ";
            this.labelLineInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorDialog
            // 
            this.colorDialog.Color = System.Drawing.Color.Red;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileFToolStripMenuItem,
            this.LineToolLToolStripMenuItem,
            this.cameraCToolStripMenuItem,
            this.OptionOToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1026, 24);
            this.menuStrip.TabIndex = 18;
            this.menuStrip.Text = "menuStrip1";
            // 
            // FileFToolStripMenuItem
            // 
            this.FileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openobjFileToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeXToolStripMenuItem});
            this.FileFToolStripMenuItem.Name = "FileFToolStripMenuItem";
            this.FileFToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.FileFToolStripMenuItem.Text = "파일(&F)";
            // 
            // openobjFileToolStripMenuItem
            // 
            this.openobjFileToolStripMenuItem.Name = "openobjFileToolStripMenuItem";
            this.openobjFileToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.openobjFileToolStripMenuItem.Text = "새 파일 열기(&N)";
            this.openobjFileToolStripMenuItem.Click += new System.EventHandler(this.openobjFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // closeXToolStripMenuItem
            // 
            this.closeXToolStripMenuItem.Name = "closeXToolStripMenuItem";
            this.closeXToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.closeXToolStripMenuItem.Text = "끝내기(&X)";
            this.closeXToolStripMenuItem.Click += new System.EventHandler(this.closeXToolStripMenuItem_Click);
            // 
            // LineToolLToolStripMenuItem
            // 
            this.LineToolLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawLineToolStripMenuItem,
            this.toolStripSeparator1,
            this.brushOptionBToolStripMenuItem1});
            this.LineToolLToolStripMenuItem.Name = "LineToolLToolStripMenuItem";
            this.LineToolLToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.LineToolLToolStripMenuItem.Text = "선 도구(&L)";
            // 
            // drawLineToolStripMenuItem
            // 
            this.drawLineToolStripMenuItem.Name = "drawLineToolStripMenuItem";
            this.drawLineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.drawLineToolStripMenuItem.Text = "선 그리기(&L)";
            this.drawLineToolStripMenuItem.CheckedChanged += new System.EventHandler(this.drawLineToolStripMenuItem_CheckedChanged);
            this.drawLineToolStripMenuItem.Click += new System.EventHandler(this.drawLineToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // brushOptionBToolStripMenuItem1
            // 
            this.brushOptionBToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorCToolStripMenuItem,
            this.widthWToolStripMenuItem1});
            this.brushOptionBToolStripMenuItem1.Name = "brushOptionBToolStripMenuItem1";
            this.brushOptionBToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.brushOptionBToolStripMenuItem1.Text = "선 속성(&B)";
            // 
            // colorCToolStripMenuItem
            // 
            this.colorCToolStripMenuItem.Name = "colorCToolStripMenuItem";
            this.colorCToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.colorCToolStripMenuItem.Text = "색(&C)";
            this.colorCToolStripMenuItem.Click += new System.EventHandler(this.colorCToolStripMenuItem_Click);
            // 
            // widthWToolStripMenuItem1
            // 
            this.widthWToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallSToolStripMenuItem,
            this.middleMToolStripMenuItem,
            this.largeLToolStripMenuItem});
            this.widthWToolStripMenuItem1.Name = "widthWToolStripMenuItem1";
            this.widthWToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.widthWToolStripMenuItem1.Text = "굵기(&W)";
            this.widthWToolStripMenuItem1.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.widthWToolStripMenuItem1_DropDownItemClicked);
            // 
            // smallSToolStripMenuItem
            // 
            this.smallSToolStripMenuItem.Name = "smallSToolStripMenuItem";
            this.smallSToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.smallSToolStripMenuItem.Text = "얇은 선(&S)";
            // 
            // middleMToolStripMenuItem
            // 
            this.middleMToolStripMenuItem.Name = "middleMToolStripMenuItem";
            this.middleMToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.middleMToolStripMenuItem.Text = "보통 선(&M)";
            // 
            // largeLToolStripMenuItem
            // 
            this.largeLToolStripMenuItem.Name = "largeLToolStripMenuItem";
            this.largeLToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.largeLToolStripMenuItem.Text = "굵은 선(&L)";
            // 
            // cameraCToolStripMenuItem
            // 
            this.cameraCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frontFToolStripMenuItem,
            this.leftLToolStripMenuItem,
            this.rightRToolStripMenuItem,
            this.backBToolStripMenuItem,
            this.upUToolStripMenuItem,
            this.downDToolStripMenuItem});
            this.cameraCToolStripMenuItem.Name = "cameraCToolStripMenuItem";
            this.cameraCToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cameraCToolStripMenuItem.Text = "카메라(&C)";
            this.cameraCToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cameraCToolStripMenuItem_DropDownItemClicked);
            // 
            // frontFToolStripMenuItem
            // 
            this.frontFToolStripMenuItem.Name = "frontFToolStripMenuItem";
            this.frontFToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.frontFToolStripMenuItem.Text = "정면(&F)";
            // 
            // leftLToolStripMenuItem
            // 
            this.leftLToolStripMenuItem.Name = "leftLToolStripMenuItem";
            this.leftLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.leftLToolStripMenuItem.Text = "좌측면(&L)";
            // 
            // rightRToolStripMenuItem
            // 
            this.rightRToolStripMenuItem.Name = "rightRToolStripMenuItem";
            this.rightRToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rightRToolStripMenuItem.Text = "우측면(&R)";
            // 
            // backBToolStripMenuItem
            // 
            this.backBToolStripMenuItem.Name = "backBToolStripMenuItem";
            this.backBToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.backBToolStripMenuItem.Text = "후면(&B)";
            // 
            // upUToolStripMenuItem
            // 
            this.upUToolStripMenuItem.Name = "upUToolStripMenuItem";
            this.upUToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.upUToolStripMenuItem.Text = "상단(&U)";
            // 
            // downDToolStripMenuItem
            // 
            this.downDToolStripMenuItem.Name = "downDToolStripMenuItem";
            this.downDToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.downDToolStripMenuItem.Text = "하단(&D)";
            // 
            // OptionOToolStripMenuItem
            // 
            this.OptionOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showGridToolStripMenuItem,
            this.drawFaceToolStripMenuItem,
            this.etcColorChangeEToolStripMenuItem});
            this.OptionOToolStripMenuItem.Name = "OptionOToolStripMenuItem";
            this.OptionOToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.OptionOToolStripMenuItem.Text = "옵션(&O)";
            // 
            // showGridToolStripMenuItem
            // 
            this.showGridToolStripMenuItem.Name = "showGridToolStripMenuItem";
            this.showGridToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.showGridToolStripMenuItem.Text = "격자 보기(&G)";
            this.showGridToolStripMenuItem.Click += new System.EventHandler(this.showGridToolStripMenuItem_Click);
            // 
            // drawFaceToolStripMenuItem
            // 
            this.drawFaceToolStripMenuItem.Name = "drawFaceToolStripMenuItem";
            this.drawFaceToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.drawFaceToolStripMenuItem.Text = "폴리곤 렌더링(&R)";
            this.drawFaceToolStripMenuItem.Click += new System.EventHandler(this.drawFaceToolStripMenuItem_Click);
            // 
            // etcColorChangeEToolStripMenuItem
            // 
            this.etcColorChangeEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bgColorChangeBToolStripMenuItem,
            this.objColorChangeOToolStripMenuItem,
            this.gridColorChangeGToolStripMenuItem});
            this.etcColorChangeEToolStripMenuItem.Name = "etcColorChangeEToolStripMenuItem";
            this.etcColorChangeEToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.etcColorChangeEToolStripMenuItem.Text = "기타 색상 설정(&E)";
            this.etcColorChangeEToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.etcColorChangeEToolStripMenuItem_DropDownItemClicked);
            // 
            // bgColorChangeBToolStripMenuItem
            // 
            this.bgColorChangeBToolStripMenuItem.Name = "bgColorChangeBToolStripMenuItem";
            this.bgColorChangeBToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bgColorChangeBToolStripMenuItem.Text = "배경 색상(&B)";
            // 
            // objColorChangeOToolStripMenuItem
            // 
            this.objColorChangeOToolStripMenuItem.Name = "objColorChangeOToolStripMenuItem";
            this.objColorChangeOToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.objColorChangeOToolStripMenuItem.Text = "모델 색상(&O)";
            // 
            // gridColorChangeGToolStripMenuItem
            // 
            this.gridColorChangeGToolStripMenuItem.Name = "gridColorChangeGToolStripMenuItem";
            this.gridColorChangeGToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gridColorChangeGToolStripMenuItem.Text = "격자 색상(&G)";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelFileRoot});
            this.statusStrip.Location = new System.Drawing.Point(0, 566);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1026, 22);
            this.statusStrip.TabIndex = 19;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelFileRoot
            // 
            this.toolStripStatusLabelFileRoot.Name = "toolStripStatusLabelFileRoot";
            this.toolStripStatusLabelFileRoot.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabelFileRoot.Text = "file://";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 588);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.lineColorPreView);
            this.Controls.Add(this.labelLineInfo);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.glControl);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Obj Viewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.lineColorPreView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelLineInfo;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.PictureBox lineColorPreView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openobjFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGridToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFileRoot;
        private System.Windows.Forms.ToolStripMenuItem drawFaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LineToolLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frontFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downDToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem brushOptionBToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem colorCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem widthWToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem smallSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem middleMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem etcColorChangeEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bgColorChangeBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objColorChangeOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridColorChangeGToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem closeXToolStripMenuItem;
    }
}

