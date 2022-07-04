using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TrackPointFnLocker {

    class KeybdHooker {

        [DllImport("user32.dll")]
        static extern bool keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private LowLevelKeyboardProc _proc = hookProc;
        private static IntPtr hhook = IntPtr.Zero;
        private static bool isFnLock = true;
        private static bool isFnCtrlSwap = false;

                const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x02;
        const int WM_SYSKEYDOWN = 260;

        public void Start() {
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
        }

        public void Stop() {
            UnhookWindowsHookEx(hhook);
        }

        public void PauseFnLock() {
            isFnLock = false;
        }

        public void ResumeFnLock() {
            isFnLock = true;
        }

        public void SwapFnCtrl() {
            isFnCtrlSwap = true;
        }

        public void NormalFnCtrl() {
            isFnCtrlSwap = false;
        }

        private static bool swapPressed = false;
        private static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam) {


            if (wParam == (IntPtr)WM_SYSKEYDOWN) {
                int vkCode = Marshal.ReadInt32(lParam);
                Console.WriteLine("SYSKEY + " + vkCode.ToString());
            }
            if (code >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_KEYUP)) {
                int vkCode = Marshal.ReadInt32(lParam);
                
                if (isFnCtrlSwap) {
                    //int vkCode = Marshal.ReadInt32(lParam);
                    if (vkCode == (int)Keys.LControlKey) {
                        
                        if (!swapPressed) {
                            Console.WriteLine("swap : ctrl -> fn");
                            swapPressed = true;
                            keybd_event((byte)Keys.F23, 0, (uint)wParam, 0);
                        } else {
                            swapPressed = false;
                        }
                        return (IntPtr)1;
                    } else if (vkCode == (int)Keys.F23) {
                       
                        if (!swapPressed) {
                            Console.WriteLine("swap : fn -> ctrl");
                            swapPressed = true;
                            keybd_event((byte)Keys.LControlKey, 0, (uint)wParam, 0);

                        } else {
                            swapPressed = false;
                        }
                        
                        return (IntPtr)1;
                    }
                }
                //Console.WriteLine("" + vkCode.ToString());
                if (isFnLock) {
                    if (vkCode == (int)VKeys.VOLUME_MUTE) {
                        keybd_event((byte)Keys.F1, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)VKeys.VOLUME_DOWN) {
                        keybd_event((byte)Keys.F2, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)VKeys.VOLUME_UP) {
                        keybd_event((byte)Keys.F3, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)VKeys.MEDIA_PREV_TRACK) {
                        keybd_event((byte)Keys.F4, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)VKeys.MEDIA_PLAY_PAUSE) {
                        keybd_event((byte)Keys.F5, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)VKeys.MEDIA_NEXT_TRACK) {
                        keybd_event((byte)Keys.F6, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)VKeys.BROWSER_BACK) {
                        keybd_event((byte)Keys.F7, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)VKeys.BROWSER_HOME) {
                        keybd_event((byte)Keys.F8, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)VKeys.APPS) {
                        keybd_event((byte)Keys.F9, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)VKeys.TP_F10) {
                        keybd_event((byte)Keys.F10, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)Keys.F1) {
                        keybd_event((byte)VKeys.VOLUME_MUTE, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)Keys.F2) {
                        keybd_event((byte)VKeys.VOLUME_DOWN, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)Keys.F3) {
                        keybd_event((byte)VKeys.VOLUME_UP, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)Keys.F4) {
                        keybd_event((byte)VKeys.MEDIA_PREV_TRACK, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)Keys.F5) {
                        keybd_event((byte)VKeys.MEDIA_PLAY_PAUSE, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)Keys.F6) {
                        keybd_event((byte)VKeys.MEDIA_NEXT_TRACK, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)Keys.F7) {
                        keybd_event((byte)VKeys.BROWSER_BACK, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)Keys.F8) {
                        keybd_event((byte)VKeys.BROWSER_HOME, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)Keys.F9) {
                        keybd_event((byte)VKeys.APPS, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)Keys.F10) {
                        keybd_event((byte)Keys.LShiftKey, 0, (uint)wParam, 0);
                        keybd_event((byte)Keys.LWin, 0, (uint)wParam, 0);
                        keybd_event((byte)VKeys.TP_F10, 0, (uint)wParam, 0);
                    } else if (vkCode == (int)Keys.F11) {
                        keybd_event((byte)VKeys.TP_F11, 0, (uint)wParam, 0);
                    } else {
                        return CallNextHookEx(hhook, code, (int)wParam, lParam);
                    }
                    return (IntPtr)1;
                }
            }

            return CallNextHookEx(hhook, code, (int)wParam, lParam);
        }
    }
}