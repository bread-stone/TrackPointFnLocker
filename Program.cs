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
            if (!IsDuplicated())
                RunApplication();
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

        private static void RunApplication() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
