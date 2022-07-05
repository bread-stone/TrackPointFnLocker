using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace TrackPointFnLocker {
    //https://github.com/AlexeyBoiko/ThinkPad-Bluetooth-Keyboard-Hotkey-Switch/blob/master/main.c
    class KeybdHooker {

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int keyCode);

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
        private static bool isFnLock = true; //Fn Lock 기능 사용 여부
        private static bool isFnCtrlSwap = false;

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x02;
        const int WM_SYSKEYDOWN = 260;

        private static bool isFnEmulation = false;

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

        //public void SwapFnCtrl() {
        //    isFnCtrlSwap = true;
        //}

        //public void NormalFnCtrl() {
        //    isFnCtrlSwap = false;
        //}

        //private static bool swapPressed = false;

        private static bool ReplaceKey(byte key) {
            if (isFnEmulation) {
                isFnEmulation = false;
                return false;
            }

            isFnEmulation = true;

            keybd_event(key, 0, 0, 0);
            keybd_event(key, 0, (uint)WM_KEYUP, 0);

            return true;
        }
        private static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam) {


            if (wParam == (IntPtr)WM_SYSKEYDOWN) {
                int vkCode = Marshal.ReadInt32(lParam);
                //Console.WriteLine("SYSKEY + " + vkCode.ToString());
            }
            if (code >= 0 && (wParam == (IntPtr)WM_KEYDOWN)) {
                int vkCode = Marshal.ReadInt32(lParam);

                //if (isFnCtrlSwap) {
                //    //int vkCode = Marshal.ReadInt32(lParam);
                //    if (vkCode == (int)Keys.LControlKey) {

                //        if (!swapPressed) {
                //            Console.WriteLine("swap : ctrl -> fn");
                //            swapPressed = true;
                //            keybd_event((byte)Keys.F23, 0, (uint)wParam, 0);
                //        } else {
                //            swapPressed = false;
                //        }
                //        return (IntPtr)1;
                //    } else if (vkCode == (int)Keys.F23) {

                //        if (!swapPressed) {
                //            Console.WriteLine("swap : fn -> ctrl");
                //            swapPressed = true;
                //            keybd_event((byte)Keys.LControlKey, 0, (uint)wParam, 0);

                //        } else {
                //            swapPressed = false;
                //        }

                //        return (IntPtr)1;
                //    }
                //}
                //Console.WriteLine("" + vkCode.ToString());
                if (isFnLock) {
                    switch (vkCode) {
                        case (int)Keys.VolumeMute:
                            if (ReplaceKey((byte)Keys.F1))
                                return (IntPtr)1;
                            break;
                        case (int)Keys.F1:
                            if (ReplaceKey((byte)Keys.VolumeMute))
                                return (IntPtr)1;
                            break;

                        case (int)Keys.VolumeDown:
                            if (ReplaceKey((byte)Keys.F2))
                                return (IntPtr)1;
                            break;
                        case (int)Keys.F2:
                            if (ReplaceKey((byte)Keys.VolumeDown))
                                return (IntPtr)1;
                            break;

                        case (int)Keys.VolumeUp:
                            if (ReplaceKey((byte)Keys.F3))
                                return (IntPtr)1;
                            break;
                        case (int)Keys.F3:
                            if (ReplaceKey((byte)Keys.VolumeUp))
                                return (IntPtr)1;
                            break;

                        case (int)Keys.MediaPreviousTrack:
                            if (ReplaceKey((byte)Keys.F4))
                                return (IntPtr)1;
                            break;
                        case (int)Keys.F4:
                            if (ReplaceKey((byte)Keys.MediaPreviousTrack))
                                return (IntPtr)1;
                            break;

                        case (int)Keys.MediaPlayPause:
                            if (ReplaceKey((byte)Keys.F5))
                                return (IntPtr)1;
                            break;
                        case (int)Keys.F5:
                            if (ReplaceKey((byte)Keys.MediaPlayPause))
                                return (IntPtr)1;
                            break;

                        case (int)Keys.MediaNextTrack:
                            if (ReplaceKey((byte)Keys.F6))
                                return (IntPtr)1;
                            break;
                        case (int)Keys.F6:
                            if (ReplaceKey((byte)Keys.MediaNextTrack))
                                return (IntPtr)1;
                            break;

                        case (int)Keys.BrowserBack:
                            if (ReplaceKey((byte)Keys.F7))
                                return (IntPtr)1;
                            break;
                        case (int)Keys.F7:
                            if (ReplaceKey((byte)Keys.BrowserBack))
                                return (IntPtr)1;
                            break;

                        case (int)Keys.BrowserHome:
                            if (ReplaceKey((byte)Keys.F8))
                                return (IntPtr)1;
                            break;
                        case (int)Keys.F8:
                            if (ReplaceKey((byte)Keys.BrowserHome))
                                return (IntPtr)1;
                            break;

                        case (int)Keys.Apps:
                            if (ReplaceKey((byte)Keys.F9))
                                return (IntPtr)1;
                            break;
                        case (int)Keys.F9:
                            if (ReplaceKey((byte)Keys.Apps))
                                return (IntPtr)1;
                            break;

                        case (int)VKeys.TP_F10:
                            if (!isFnEmulation) {
                                isFnEmulation = true;

                                if ((GetKeyState((int)Keys.LWin) & 0x8000) > 0)
                                    keybd_event((int)Keys.LWin, 0, WM_KEYUP, 0);

                                if ((GetKeyState((int)Keys.LShiftKey) & 0x8000) > 0)
                                    keybd_event((int)Keys.LShiftKey, 0, WM_KEYUP, 0);

                                keybd_event((int)Keys.F10, 0, 0, 0);
                                keybd_event((int)Keys.F10, 0, WM_KEYUP, 0);

                                return (IntPtr)1;
                            } else {
                                isFnEmulation = false;
                            }
                            break;
                        case (int)Keys.F10:
                            if (!isFnEmulation) {
                                isFnEmulation = true;

                                keybd_event((byte)Keys.LShiftKey, 0, 0, 0);
                                keybd_event((byte)Keys.LWin, 0, 0, 0);

                                keybd_event((byte)Keys.F21, 0, 0, 0);
                                keybd_event((byte)Keys.F21, 0, WM_KEYUP, 0);

                                keybd_event((byte)Keys.LShiftKey, 0, WM_KEYUP, 0);
                                keybd_event((byte)Keys.LWin, 0, WM_KEYUP, 0);

                                return (IntPtr)1;
                            } else {
                                isFnEmulation = false;
                            }
                            break;
                        // F11
                        case 0x9:
                            if (((GetKeyState((int)Keys.LControlKey) & 0x8000) > 0) &&
                                (GetKeyState((int)Keys.LMenu) & 0x8000) > 0) {
                                if (!isFnEmulation) {
                                    isFnEmulation = true;

                                    keybd_event((byte)Keys.LControlKey, 0, WM_KEYUP, 0);
                                    keybd_event((byte)Keys.LMenu, 0, WM_KEYUP, 0);

                                    keybd_event((byte)Keys.F11, 0, 0, 0);
                                    keybd_event((byte)Keys.F11, 0, WM_KEYUP, 0);

                                    return (IntPtr)1;
                                } else {
                                    isFnEmulation = false;
                                }
                            }
                            break;
                        case (int)Keys.F11:
                            if (!isFnEmulation) {
                                isFnEmulation = true;

                                keybd_event((byte)Keys.LControlKey, 0, 0, 0);
                                keybd_event((byte)Keys.LMenu, 0, 0, 0);

                                keybd_event(0x9, 0, 0, 0);
                                keybd_event(0x9, 0, WM_KEYUP, 0);

                                keybd_event((byte)Keys.LControlKey, 0, WM_KEYUP, 0);
                                keybd_event((byte)Keys.LMenu, 0, WM_KEYUP, 0);

                                return (IntPtr)1;
                            } else {
                                isFnEmulation = false;
                            }
                            break;
                    }
                }
            }

            return CallNextHookEx(hhook, code, (int)wParam, lParam);
        }
    }
}

