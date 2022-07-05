using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrackPointFnLocker {
    internal class RegHelper {

        

        public static void SetRestart() {
            SetValue("restart", 1);
        }
        public static void ResetRestart() {
            SetValue("restart", 0);
        }

        public static int getRestart() {
            try {
                object obj = GetValue("restart");
                if (obj != null)
                    return (int)obj;
                else
                    return 0;
            } catch(NullReferenceException e) {
                return 0;
            }            
        }
        public static void SetAdmin() {
            SetValue("admin", 1);
        }

        public static void ResetAdmin() {
            SetValue("admin", 0);
        }

        public static int getAdmin() {
            try {
                object obj = GetValue("admin");
                if (obj != null)
                    return (int)obj;
                else
                    return 0;
            } catch (NullReferenceException e) {
                return 0;
            }
        }

        public static void SetFnLock() {
            SetValue("fnlock", 1);
        }

        public static void ResetFnLock() {
            SetValue("fnlock", 0);
        }

        public static int getFnLock() {
            try {
                object obj = GetValue("fnlock");
                if (obj != null)
                    return (int)obj;
                else
                    return 0;
            } catch (NullReferenceException e) {
                return 0;
            }
        }

        private static void SetValue(String key, object value) {
            getSubKey().SetValue(key, value);
        }

        private static object GetValue(String key) {
            return getSubKey().GetValue(key);
        }

        private static RegistryKey getSubKey() {
            return Registry.CurrentUser.CreateSubKey("SOFTWARE").CreateSubKey("TPFnLock");
        }


        public static void AddStartUp(String executablePath) {
            using (var regKey = GetRegKey(_startupRegPath, true)) {
                try {
                    // 키가 이미 등록돼 있지 않을때만 등록
                    if (regKey.GetValue("TPFnLock") == null)
                        regKey.SetValue("TPFnLock", executablePath);

                    regKey.Close();
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void RemoveStartup() {
            using (var regKey = GetRegKey(_startupRegPath, true)) {
                try {
                    // 키가 이미 존재할때만 제거
                    if (regKey.GetValue("TPFnLock") != null)
                        regKey.DeleteValue("TPFnLock", false);

                    regKey.Close();
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static readonly string _startupRegPath =
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private static RegistryKey GetRegKey(string regPath, bool writable) {
            return Registry.CurrentUser.OpenSubKey(regPath, writable);
        }
    }
}
