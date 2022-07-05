using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace TrackPointFnLocker
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!IsDuplicated()) {
                if (CheckAdminMode()) {
                    RegHelper.ResetAdmin();
                    RunAsAdmin();
                } else {
                    RunApplication();
                }
            }
        }

        private static bool IsDuplicated() {
            try {
                int processCount = 0;

                System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();

                foreach (System.Diagnostics.Process p in processes) {
                    // 중복 프로세스 찾기
                    // 주의 : 프로세스 이름은 응용프로그램 파일 이름(이름.exe)으로 실행됨!!
                    if (AppDomain.CurrentDomain.FriendlyName.Equals(p.ProcessName + ".exe"))
                        processCount++;

                    // 중복 프로세스 탐지함
                    if (processCount > 1) {
                        return true;
                    }
                }

                // 중복 프로세스 없음
                return false;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception");
                return true;
            }
        }

        private static bool CheckAdminMode() {
            return (RegHelper.getAdmin() == 1);
        }

        private static void RunAsAdmin() {
            try {
                ProcessStartInfo procInfo = new ProcessStartInfo();
                procInfo.UseShellExecute = true;
                procInfo.FileName = Application.ExecutablePath;
                procInfo.WorkingDirectory = Environment.CurrentDirectory;
                procInfo.Verb = "runas";
                Process.Start(procInfo);
            } catch (Exception ex) {
                // 사용자가 프로그램을 관리자 권한으로 실행하기를 원하지 않을 경우에 대한 처리
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private static void RunApplication() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
