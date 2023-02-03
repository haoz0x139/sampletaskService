using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;

namespace sampletaskService
{
    public partial class sampletaskService : Form
    {
        private static AutoFun objTask = new AutoFun();

        private Thread MainThread;       
        private Thread SubThread;  

        private string isAuto = "";
        private static bool bSetStop;
        private static bool bStarted;
        private static readonly string sysPath = AppDomain.CurrentDomain.BaseDirectory;

        public sampletaskService()
        {
            InitializeComponent();

            MainThread = new Thread(new ThreadStart(delegate() { ThreadFunc("task1"); }));
            MainThread.Priority = ThreadPriority.Highest;

            SubThread = new Thread(new ThreadStart(delegate() { ThreadFunc("task2"); }));
            SubThread.Priority = ThreadPriority.Highest;
        }

        private void sampletaskService_Load(object sender, EventArgs e)
        {
            isAuto = ConfigurationManager.AppSettings["isAuto"].Trim();
            notifyIcon.BalloonTipText = "sampletaskService start";
            notifyIcon.BalloonTipTitle = "sampletaskService";
            notifyIcon.ShowBalloonTip(2);
            this.Visible = false;
            if (isAuto == "1")
            {
                btnStart_Click(sender, e);
            }          
        }


        public static void ThreadFunc(string threadType)
        {
            ///	<summary>
            ///	对象初始化
            ///	</summary>
            //	标记服务开始	*/
            bStarted = true;
            /*	系统服务心跳，单位：秒	*/
            double setHeart = 1;
            /*	任务调用默认间隔，单位：分钟	*/
            int setTaskTimeDefault = 30;
            int setTaskTime;

            ///	<summary>
            /// 获取本地配置信息,ini文件读取
            /// </summary> 
            string TaskRunTime = "";
            string thEx = threadType + "Time";
            TaskRunTime = ConfigurationManager.AppSettings[thEx].Trim();
            try
            {
                int nTaskRunTime = int.Parse(TaskRunTime);
                // 判断读取的任务运行间隔时间是否大于一天或者小于1
                if (nTaskRunTime < 1 || nTaskRunTime > 1440)
                    setTaskTime = setTaskTimeDefault;
                else
                    setTaskTime = nTaskRunTime;
            }
            catch
            {
                // 异常情况使用默认值
                setTaskTime = setTaskTimeDefault;
            }

            DateTime dtLast = System.DateTime.Now;
            DateTime dtNow = System.DateTime.Now;
            TimeSpan ts;

            bool bFistRun = true;
            bool bTaskTime = false;
            // string logNameEx = logName + threadType;
            /// <summary>
            /// 主循环
            /// </summary>
            while (true)
            {
                /*	检查是否终止服务	*/
                if (bSetStop)
                    break;

                /*	心跳	*/
                System.Threading.Thread.Sleep((int)(setHeart * 1000));

                /*	检测所有模块列表，确认是否有定时任务需要下发	*/
                dtNow = System.DateTime.Now;
                ts = dtNow - dtLast;
                bTaskTime = (ts.Minutes >= setTaskTime) ? true : false;

                if (bFistRun || bTaskTime)
                {
                    dtLast = dtNow;
                    bFistRun = false;
                    objTask.TaskRun(threadType);
                }
            }
            // 结束服务
            bStarted = false;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            bSetStop = false;
            if (MainThread.ThreadState == ThreadState.Unstarted)
            {
                MainThread.Start();
            }
            if (SubThread.ThreadState == ThreadState.Unstarted)
            {
                SubThread.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SetStop();
            MainThread.Abort();
            SubThread.Abort();
        }

        private void SetStop()
        {
            bSetStop = true;
            System.DateTime TimeMarkStart = System.DateTime.Now;
            DateTime TimeMark = TimeMarkStart.AddSeconds(5);
            while (true)
            {
                System.Threading.Thread.Sleep(2000);
                if (!bStarted)
                {
                    break;
                }
                System.DateTime CurrentTime = System.DateTime.Now;
                if (CurrentTime > TimeMark)
                {
                    break;
                }
            }
        }

        private void btnOpenPath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(sysPath);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnStop_Click(sender, e);
            System.Environment.Exit(0); 
        }
    }
}
