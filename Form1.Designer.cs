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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBtn_Disable = new System.Windows.Forms.RadioButton();
            this.rBtn_Enable = new System.Windows.Forms.RadioButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rBtn_FnCtrlNone = new System.Windows.Forms.RadioButton();
            this.rBtn_FnCtrlSwap = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_privilege = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBtn_Disable);
            this.groupBox1.Controls.Add(this.rBtn_Enable);
            this.groupBox1.Location = new System.Drawing.Point(30, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FN Lock";
            // 
            // rBtn_Disable
            // 
            this.rBtn_Disable.AutoSize = true;
            this.rBtn_Disable.Location = new System.Drawing.Point(94, 29);
            this.rBtn_Disable.Name = "rBtn_Disable";
            this.rBtn_Disable.Size = new System.Drawing.Size(72, 17);
            this.rBtn_Disable.TabIndex = 1;
            this.rBtn_Disable.TabStop = true;
            this.rBtn_Disable.Text = "Disable";
            this.rBtn_Disable.UseVisualStyleBackColor = true;
            this.rBtn_Disable.CheckedChanged += new System.EventHandler(this.rBtn_Disable_CheckedChanged);
            // 
            // rBtn_Enable
            // 
            this.rBtn_Enable.AutoSize = true;
            this.rBtn_Enable.Location = new System.Drawing.Point(18, 29);
            this.rBtn_Enable.Name = "rBtn_Enable";
            this.rBtn_Enable.Size = new System.Drawing.Size(68, 17);
            this.rBtn_Enable.TabIndex = 0;
            this.rBtn_Enable.TabStop = true;
            this.rBtn_Enable.Text = "Enable";
            this.rBtn_Enable.UseVisualStyleBackColor = true;
            this.rBtn_Enable.CheckedChanged += new System.EventHandler(this.rBtn_Enable_CheckedChanged);
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
            this.linkLabel1.Location = new System.Drawing.Point(12, 133);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(94, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "go homepage";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rBtn_FnCtrlNone);
            this.groupBox2.Controls.Add(this.rBtn_FnCtrlSwap);
            this.groupBox2.Location = new System.Drawing.Point(30, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 71);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FN <-> Ctrl Swap";
            this.groupBox2.Visible = false;
            // 
            // rBtn_FnCtrlNone
            // 
            this.rBtn_FnCtrlNone.AutoSize = true;
            this.rBtn_FnCtrlNone.Location = new System.Drawing.Point(94, 29);
            this.rBtn_FnCtrlNone.Name = "rBtn_FnCtrlNone";
            this.rBtn_FnCtrlNone.Size = new System.Drawing.Size(72, 17);
            this.rBtn_FnCtrlNone.TabIndex = 1;
            this.rBtn_FnCtrlNone.TabStop = true;
            this.rBtn_FnCtrlNone.Text = "Disable";
            this.rBtn_FnCtrlNone.UseVisualStyleBackColor = true;
            this.rBtn_FnCtrlNone.CheckedChanged += new System.EventHandler(this.rBtn_FnCtrlNone_CheckedChanged);
            // 
            // rBtn_FnCtrlSwap
            // 
            this.rBtn_FnCtrlSwap.AutoSize = true;
            this.rBtn_FnCtrlSwap.Location = new System.Drawing.Point(18, 29);
            this.rBtn_FnCtrlSwap.Name = "rBtn_FnCtrlSwap";
            this.rBtn_FnCtrlSwap.Size = new System.Drawing.Size(68, 17);
            this.rBtn_FnCtrlSwap.TabIndex = 0;
            this.rBtn_FnCtrlSwap.TabStop = true;
            this.rBtn_FnCtrlSwap.Text = "Enable";
            this.rBtn_FnCtrlSwap.UseVisualStyleBackColor = true;
            this.rBtn_FnCtrlSwap.CheckedChanged += new System.EventHandler(this.rBtn_FnCtrlSwap_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 40);
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
            this.lb_privilege.Size = new System.Drawing.Size(246, 34);
            this.lb_privilege.TabIndex = 4;
            this.lb_privilege.Text = "유저권한으로 실행 중";
            this.lb_privilege.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(251, 255);
            this.Controls.Add(this.lb_privilege);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBtn_Enable;
        private System.Windows.Forms.RadioButton rBtn_Disable;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rBtn_FnCtrlNone;
        private System.Windows.Forms.RadioButton rBtn_FnCtrlSwap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_privilege;
    }
}

