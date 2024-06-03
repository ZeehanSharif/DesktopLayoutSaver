using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DesktopLayoutSaver
{
    public class WindowInfo
    {
        public string Title { get; set; } = string.Empty;
        public string ProcessName { get; set; } = string.Empty;
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public static List<WindowInfo> GetOpenWindows()
        {
            List<WindowInfo> windows = new List<WindowInfo>();

            EnumWindows((hWnd, lParam) =>
            {
                if (IsWindowVisible(hWnd) && GetWindowTextLength(hWnd) > 0)
                {
                    var window = new WindowInfo();
                    window.Title = GetWindowText(hWnd);
                    GetWindowRect(hWnd, out RECT rect);
                    window.X = rect.Left;
                    window.Y = rect.Top;
                    window.Width = rect.Right - rect.Left;
                    window.Height = rect.Bottom - rect.Top;

                    uint pid;
                    GetWindowThreadProcessId(hWnd, out pid);
                    Process proc = Process.GetProcessById((int)pid);
                    window.ProcessName = proc.ProcessName;

                    windows.Add(window);
                }
                return true;
            }, IntPtr.Zero);

            return windows;
        }

        public void Restore()
        {
            Process[] processes = Process.GetProcessesByName(ProcessName);
            foreach (Process proc in processes)
            {
                if (proc.MainWindowTitle == Title)
                {
                    IntPtr hWnd = proc.MainWindowHandle;
                    SetWindowPos(hWnd, IntPtr.Zero, X, Y, Width, Height, SWP_NOZORDER | SWP_NOACTIVATE);
                }
            }
        }

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWP_NOACTIVATE = 0x0010;

        private static string GetWindowText(IntPtr hWnd)
        {
            int length = GetWindowTextLength(hWnd);
            System.Text.StringBuilder sb = new System.Text.StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
}
