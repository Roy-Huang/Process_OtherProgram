using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Process_OtherProgram
{
    public partial class Form1 : Form
    {
        public const int BM_CLICK = 0xF5;
        public Form1()
        {
            InitializeComponent();
            OpenOtherProgram_ClickButton("Process_test.exe", "Process_test", "test_button");
        }
        //---button---
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hwnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        //------------
        void OpenOtherProgram_ClickButton(string exefile, string process_name, string autoClickbtnName)
        {
            //string OpenPath = @"D:\Code\Git\StreameReader_read_ini\StreameReader_read_ini\bin\Debug";
            Process.Start(exefile);
            Process[] processes = Process.GetProcessesByName(process_name);
            //wait 500 ms
            Thread.Sleep(500);
            foreach (Process p in processes)
            {               
                IntPtr ButtonHandle = FindWindowEx(p.MainWindowHandle, IntPtr.Zero, null, autoClickbtnName);
                SendMessage(ButtonHandle, BM_CLICK, 0, 0);
            }

            //---Find Process Name---
            //foreach (Process pr in Process.GetProcesses())
            //{
            //    try
            //    {
            //        Console.WriteLine("App Name: {0}, Process Name: {1}", Path.GetFileName(pr.MainModule.FileName), pr.ProcessName);
            //    }
            //    catch { }
            //}
            //-----------------------
        }
    }
}
