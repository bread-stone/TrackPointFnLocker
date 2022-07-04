using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TrackPointFnLocker
{
    public partial class Form1 : Form
    {
        private KeybdHooker hooker;
        public Form1()
        {
            InitializeComponent();
            hooker = new KeybdHooker();
            this.Load += Form1_Load;
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hooker.Start();
        }
               
        private void rBtn_Enable_CheckedChanged(object sender, EventArgs e) {
            hooker.Resume();
        }

        private void rBtn_Disable_CheckedChanged(object sender, EventArgs e) {
            hooker.Pause();
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
            hooker.Stop();
            notifyIcon1.Visible = false;
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            goTray();
        }

        private void goTray() {
            Hide();
            notifyIcon1.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/bread-stone/TrackPointFnLocker");
        }
    }
}
