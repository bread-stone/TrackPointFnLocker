using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace TrackPointFnLocker {
    public partial class Form1 : Form {
        private KeybdHooker hooker;
        private bool hasAdmin = false;
        public Form1() {
            InitializeComponent();
            hooker = new KeybdHooker();
            this.Load += Form1_Load;
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
        }

        private void enableAdminGroup(bool enabled) {
            chk_FnCtrlSwap.Enabled = enabled;
            chk_CtrlCapsLockSwap.Enabled = enabled;
        }

        private void Form1_Load(object sender, EventArgs e) {
            hooker.Start();
            hasAdmin = Admin.hasPrivilege();
            if (hasAdmin) {
                lb_privilege.Text = "관리자권한으로 실행 중";
                lb_privilege.ForeColor = System.Drawing.Color.Red;
                button1.Enabled = false;
                enableAdminGroup(true);
            } else {
                lb_privilege.Text = "유저권한으로 실행 중";
                lb_privilege.ForeColor = System.Drawing.Color.Blue;
                button1.Text = "관리자권한으로 실행";
                enableAdminGroup(false);
            }

            if (RegHelper.getFnLock() == 1) {
                chk_FnLock.Checked = true;
            }                
            else {
                chk_FnLock.Checked = false;
            }

            byte[] value = RegHelper.GetScanCodeMap();
            if (isSameValue(value, fnCtrlSwapValue)) {
                chk_FnCtrlSwap.Checked = true;
                chk_CtrlCapsLockSwap.Enabled = hasAdmin && false;
            } else if (isSameValue(value, ctrlCapsLockSwapValue)) {
                chk_CtrlCapsLockSwap.Checked = true;
                chk_FnCtrlSwap.Enabled = hasAdmin && false;
            }
        }

        byte[] ctrlCapsLockSwapValue = new byte[] { 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x03, 0x00, 0x00, 0x00, 0x1d, 0x00, 0x3a, 0x00,
            0x3a, 0x00, 0x1d, 0x00, 0x00, 0x00, 0x00, 0x00,
        };

        byte[] fnCtrlSwapValue = new byte[] {
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x03, 0x00, 0x00, 0x00, 0x1d, 0x00, 0x6e, 0x00,
            0x6e, 0x00, 0x1d, 0x00, 0x00, 0x00, 0x00, 0x00,
        };
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
        
        private bool isSameValue(byte[] v1, byte[] v2) {
            if (v1.Length != v2.Length)
                return false;

            for (int i = 0; i < v1.Length; i++)
                if (v1[i] != v2[i])
                    return false;

            return true;
        }

        private void chk_FnCtrlSwap_CheckedChanged(object sender, EventArgs e) {
            if (chk_FnCtrlSwap.Checked) {
                if (chk_CtrlCapsLockSwap.Checked) {
                    lb_message.Text = "둘 중 하나만 사용 가능합니다";
                    chk_FnCtrlSwap.Checked = false;
                } else {
                    chk_CtrlCapsLockSwap.Enabled = false;
                    if (hasAdmin) {
                        RegHelper.SetScanCodeMap(fnCtrlSwapValue);
                        lb_message.Text = "재부팅 또는 로그아웃 후 적용됩니다";
                    }
                }
            } else {
                chk_CtrlCapsLockSwap.Enabled = true;
                if (hasAdmin) {
                    RegHelper.ResetScanCodeMap();
                }
            }
        }

        private void chk_CtrlCapsLockSwap_CheckedChanged(object sender, EventArgs e) {
            if (chk_CtrlCapsLockSwap.Checked) {
                if (chk_FnCtrlSwap.Checked) {
                    lb_message.Text = "둘 중 하나만 사용 가능합니다";
                    chk_CtrlCapsLockSwap.Checked = false;
                } else {
                    chk_FnCtrlSwap.Enabled = false;
                    if (hasAdmin) {
                        RegHelper.SetScanCodeMap(ctrlCapsLockSwapValue);
                        lb_message.Text = "재부팅 또는 로그아웃 후 적용됩니다";
                    }
                }
            } else {
                chk_FnCtrlSwap.Enabled = true;
                if (hasAdmin) {
                    RegHelper.ResetScanCodeMap();
                }
            }
        }
    }
}
