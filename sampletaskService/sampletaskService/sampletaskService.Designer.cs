namespace sampletaskService
{
    partial class sampletaskService
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sampletaskService));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cms_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnStart = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStop = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenPath = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.cms_Menu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "sampletaskService";
            this.notifyIcon.Visible = true;
            // 
            // cms_Menu
            // 
            this.cms_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStart,
            this.btnStop,
            this.btnOpenPath,
            this.btnExit});
            this.cms_Menu.Name = "cms_Menu";
            this.cms_Menu.Size = new System.Drawing.Size(153, 114);
            // 
            // btnStart
            // 
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(152, 22);
            this.btnStart.Text = "开启服务";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(152, 22);
            this.btnStop.Text = "关闭服务";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnOpenPath
            // 
            this.btnOpenPath.Name = "btnOpenPath";
            this.btnOpenPath.Size = new System.Drawing.Size(152, 22);
            this.btnOpenPath.Text = "系统目录";
            this.btnOpenPath.Click += new System.EventHandler(this.btnOpenPath_Click);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(152, 22);
            this.btnExit.Text = "退出系统";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // sampletaskService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 203);
            this.Name = "sampletaskService";
            this.Text = "sampletaskService";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.sampletaskService_Load);
            this.cms_Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cms_Menu;
        private System.Windows.Forms.ToolStripMenuItem btnStart;
        private System.Windows.Forms.ToolStripMenuItem btnStop;
        private System.Windows.Forms.ToolStripMenuItem btnOpenPath;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
    }
}

