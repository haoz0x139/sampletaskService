using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace sampletaskService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);         

            if (RunningInstance() == null)
                Application.Run(new sampletaskService());
            else
                MessageBox.Show("sampletaskService已经启动，请不要重复启动!", "sampletaskService 1.0", MessageBoxButtons.OK);
        }

        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历当前进程，查看是否有相同的名称
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //返回已经启动的程序例程
                        return process;
                    }
                }
            }
            //没有找到和当前系统相同的例程，则返回Null
            return null;
        }

       
    }
}
