using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace TrackPointFnLocker {
    public partial class Form1 : Form {
        private KeybdHooker hooker;
        public Form1() {
            InitializeComponent();
            hooker = new KeybdHooker();
            
            rBtn_FnCtrlNone.Checked = true;
            this.Load += Form1_Load;
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
        }

        private void Form1_Load(object sender, EventArgs e) {
            hooker.Start();
            if (Admin.hasPrivilege()) {
                lb_privilege.Text = "관리자권한으로 실행 중";
                lb_privilege.ForeColor = System.Drawing.Color.Red;
                button1.Enabled = false;
                gBox_Admin.Enabled = true;
            } else {
                lb_privilege.Text = "유저권한으로 실행 중";
                lb_privilege.ForeColor = System.Drawing.Color.Blue;
                button1.Text = "관리자권한으로 실행";
                gBox_Admin.Enabled = false;
            }

            if (RegHelper.getFnLock() == 1) {
                chk_FnLock.Checked = true;
            }                
            else {
                chk_FnLock.Checked = false;
            }
                

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            this.Activate();
        }

        private void Form1_Resize(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                goTray();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
            } else if (e.Button == MouseButtons.Right) {
                contextMenuStrip1.Show();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            if (Visible)
                Visible = false;
            hooker.Stop();
            notifyIcon1.Visible = false;
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (RegHelper.getRestart() == 0) {
                e.Cancel = true;
                goTray();
            } else {
                RegHelper.ResetRestart();
                hooker.Stop();
                notifyIcon1.Visible = false;
                Application.Exit();
                System.Diagnostics.Process.Start(Application.ExecutablePath);
            }
        }

        private void goTray() {
            Hide();
            notifyIcon1.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/bread-stone/TrackPointFnLocker");
        }

        private void rBtn_FnCtrlSwap_CheckedChanged(object sender, EventArgs e) {
            hooker.SwapFnCtrl();
        }

        private void rBtn_FnCtrlNone_CheckedChanged(object sender, EventArgs e) {
            hooker.NormalFnCtrl();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (!Admin.hasPrivilege()) {
                RegHelper.SetRestart();
                RegHelper.SetAdmin();
                this.Close();
            }
        }
        private void chk_StartUp_CheckedChanged(object sender, EventArgs e) {
            if (chk_StartUp.Checked) {
                RegHelper.AddStartUp(Application.ExecutablePath);
            } else {
                RegHelper.RemoveStartup();
            }
        }

        private void chk_FnLock_CheckedChanged(object sender, EventArgs e) {
            if (chk_FnLock.Checked) {
                RegHelper.SetFnLock();
                hooker.ResumeFnLock();
            } else {
                RegHelper.ResetFnLock();
                hooker.PauseFnLock();
            }
        }
    }
}
