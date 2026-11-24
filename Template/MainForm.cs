using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Template
{
    public partial class Template : Form
    {
        public Template()
        {
            InitializeComponent();
        }

        #region Function
        #region LoadConfig
        private void LoadConfig()
        {
            AppSettings currentSettings = configMgr.Load();
            if (currentSettings == null) return;
            ServeIP.Text = currentSettings.ServerIp;
            Port.Text = currentSettings.Port.ToString();
        }
        #endregion

        #region SaveConfig
        private AppSettings CurrentSettings()
        {
            AppSettings _currentSettings = new AppSettings
            {
                ServerIp = ServeIP.Text,
                Port = Convert.ToInt32(Port.Text)
            };
            return _currentSettings;
        }

        private void SaveConfig()
        {
            configMgr.Save(CurrentSettings());
        }
        #endregion

        private void InitUI()
        {
            ServeIP.SetWatermark("請輸入IP");
            Port.SetWatermark("請輸入Port");
        }

        /// <summary>
        /// Usage:Log.Information("Info!");
        /// </summary>
        private void LogInit()
        {
            // 初始化 Serilog 並註冊你的 UI 控制項
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug() // 設定最低記錄層級
            // 同時寫入實體檔案（每天會自動產生一個新檔案）
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logger", "log-.txt"), rollingInterval: RollingInterval.Day)
            // 透過我們寫的擴充方法綁定控制項（依序對應：一般、警告、錯誤、除錯）
            .WriteTo.WinFormRichTextBox(richTextBoxDebug, richTextBoxGeneral, richTextBoxWarning, richTextBoxError, tabControl: LogRecord)
            .CreateLogger();
        }
        #endregion

        #region Initialization and parameter
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitUI();
            LoadConfig();
            LogInit();
        }
        private ConfigManager<AppSettings> configMgr = new ConfigManager<AppSettings>(@"Config\config.json", true);
        #endregion

        private void MainBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case nameof(Demo):

                    break;
            }
        }

       
    }
}
