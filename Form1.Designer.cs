namespace TrackPointFnLocker
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_privilege = new System.Windows.Forms.Label();
            this.chk_StartUp = new System.Windows.Forms.CheckBox();
            this.chk_FnLock = new System.Windows.Forms.CheckBox();
            this.chk_FnCtrlSwap = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_CtrlCapsLockSwap = new System.Windows.Forms.CheckBox();
            this.lb_message = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "TrackPoint FnLock";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "TP FnLock";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(94, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 287);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(94, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "go homepage";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "관리자권한으로 실행";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_privilege
            // 
            this.lb_privilege.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_privilege.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_privilege.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_privilege.ForeColor = System.Drawing.Color.Blue;
            this.lb_privilege.Location = new System.Drawing.Point(0, 0);
            this.lb_privilege.Name = "lb_privilege";
            this.lb_privilege.Size = new System.Drawing.Size(261, 34);
            this.lb_privilege.TabIndex = 4;
            this.lb_privilege.Text = "유저권한으로 실행 중";
            this.lb_privilege.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk_StartUp
            // 
            this.chk_StartUp.AutoSize = true;
            this.chk_StartUp.Location = new System.Drawing.Point(53, 47);
            this.chk_StartUp.Name = "chk_StartUp";
            this.chk_StartUp.Size = new System.Drawing.Size(156, 17);
            this.chk_StartUp.TabIndex = 3;
            this.chk_StartUp.Text = "Windows 시작시 실행";
            this.chk_StartUp.UseVisualStyleBackColor = true;
            this.chk_StartUp.CheckedChanged += new System.EventHandler(this.chk_StartUp_CheckedChanged);
            // 
            // chk_FnLock
            // 
            this.chk_FnLock.AutoSize = true;
            this.chk_FnLock.Location = new System.Drawing.Point(53, 75);
            this.chk_FnLock.Name = "chk_FnLock";
            this.chk_FnLock.Size = new System.Drawing.Size(104, 17);
            this.chk_FnLock.TabIndex = 6;
            this.chk_FnLock.Text = "Fn Lock 사용";
            this.chk_FnLock.UseVisualStyleBackColor = true;
            this.chk_FnLock.CheckedChanged += new System.EventHandler(this.chk_FnLock_CheckedChanged);
            // 
            // chk_FnCtrlSwap
            // 
            this.chk_FnCtrlSwap.AutoSize = true;
            this.chk_FnCtrlSwap.Location = new System.Drawing.Point(53, 195);
            this.chk_FnCtrlSwap.Name = "chk_FnCtrlSwap";
            this.chk_FnCtrlSwap.Size = new System.Drawing.Size(133, 17);
            this.chk_FnCtrlSwap.TabIndex = 0;
            this.chk_FnCtrlSwap.Text = "Fn <-> Ctrl 바꾸기";
            this.chk_FnCtrlSwap.UseVisualStyleBackColor = true;
            this.chk_FnCtrlSwap.CheckedChanged += new System.EventHandler(this.chk_FnCtrlSwap_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "------- 관리자권한 필요 -------";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk_CtrlCapsLockSwap
            // 
            this.chk_CtrlCapsLockSwap.AutoSize = true;
            this.chk_CtrlCapsLockSwap.Location = new System.Drawing.Point(53, 222);
            this.chk_CtrlCapsLockSwap.Name = "chk_CtrlCapsLockSwap";
            this.chk_CtrlCapsLockSwap.Size = new System.Drawing.Size(184, 17);
            this.chk_CtrlCapsLockSwap.TabIndex = 8;
            this.chk_CtrlCapsLockSwap.Text = "Ctrl <-> Caps Lock 바꾸기";
            this.chk_CtrlCapsLockSwap.UseVisualStyleBackColor = true;
            this.chk_CtrlCapsLockSwap.CheckedChanged += new System.EventHandler(this.chk_CtrlCapsLockSwap_CheckedChanged);
            // 
            // lb_message
            // 
            this.lb_message.Location = new System.Drawing.Point(0, 242);
            this.lb_message.Name = "lb_message";
            this.lb_message.Size = new System.Drawing.Size(261, 24);
            this.lb_message.TabIndex = 9;
            this.lb_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(262, 309);
            this.Controls.Add(this.lb_message);
            this.Controls.Add(this.chk_CtrlCapsLockSwap);
            this.Controls.Add(this.chk_FnCtrlSwap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chk_FnLock);
            this.Controls.Add(this.chk_StartUp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb_privilege);
            this.Controls.Add(this.linkLabel1);
            this.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "TrackPoint Fn Locker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_privilege;
        private System.Windows.Forms.CheckBox chk_StartUp;
        private System.Windows.Forms.CheckBox chk_FnLock;
        private System.Windows.Forms.CheckBox chk_FnCtrlSwap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_CtrlCapsLockSwap;
        private System.Windows.Forms.Label lb_message;
    }
}

