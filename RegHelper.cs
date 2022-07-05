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
                return (int)GetValue("restart");
            } catch(Exception e) {
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
                return (int)GetValue("admin");
            } catch (Exception e) {
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
            return Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("TPFnLock");
        }
    }
}
