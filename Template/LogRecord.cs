using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog.Core;
using Serilog.Events;

namespace Template
{
    public class RichTextBoxSink : ILogEventSink
    {
        private readonly RichTextBox _debugBox;
        private readonly RichTextBox _infoBox;
        private readonly RichTextBox _warnBox;
        private readonly RichTextBox _errorBox;
        private readonly TabControl _tabControl;
        private readonly IFormatProvider _formatProvider;
        private readonly bool _autoSwitchTab;

        public RichTextBoxSink(
            RichTextBox debugBox,
            RichTextBox infoBox,
            RichTextBox warnBox,
            RichTextBox errorBox,
            TabControl tabControl,
            IFormatProvider formatProvider = null,
            bool autoSwitchTab = true)
        {
            _debugBox = debugBox;
            _infoBox = infoBox;
            _warnBox = warnBox;
            _errorBox = errorBox;
            _tabControl = tabControl;
            _formatProvider = formatProvider;
            _autoSwitchTab = autoSwitchTab;
        }

        private Tuple<RichTextBox, Color> GetTarget(LogEventLevel level)
        {
            RichTextBox box;
            Color color;
            switch (level)
            {
                case LogEventLevel.Debug:
                    box = _debugBox;
                    color = Color.Gray;
                    break;
                case LogEventLevel.Information:
                    box = _infoBox;
                    color = Color.Black;
                    break;
                case LogEventLevel.Warning:
                    box = _warnBox;
                    color = Color.DarkOrange;
                    break;
                case LogEventLevel.Error:
                    box = _errorBox;
                    color = Color.Red;
                    break;
                case LogEventLevel.Fatal:
                    box = _errorBox;
                    color = Color.DarkRed;
                    break;
                default:
                    box = _infoBox;
                    color = Color.White;
                    break;
            }
            return Tuple.Create(box, color);
        }

        public void Emit(LogEvent logEvent)
        {
            string message = logEvent.RenderMessage(_formatProvider);
            string timestamp = logEvent.Timestamp.ToString("HH:mm:ss");
            string fullMessage = $"[{timestamp}] [{logEvent.Level}] {message}";

            var target = GetTarget(logEvent.Level);
            RichTextBox targetBox = target.Item1;
            Color color = target.Item2;

            if (targetBox == null) return;

            // WinForm 跨執行緒安全處理
            if (targetBox.InvokeRequired)
            {
                targetBox.BeginInvoke(new Action(() => WriteLogToUI(targetBox, fullMessage, color)));
            }
            else
            {
                WriteLogToUI(targetBox, fullMessage, color);
            }
        }

        private void WriteLogToUI(RichTextBox targetBox, string fullMessage, Color color)
        {
            // 寫入文字與顏色
            targetBox.SelectionStart = targetBox.TextLength;
            targetBox.SelectionLength = 0;
            targetBox.SelectionColor = color;
            targetBox.AppendText(fullMessage + Environment.NewLine);
            targetBox.ScrollToCaret();

            // 自動切換 TabPage 到對應的 RichTextBox 所在的頁籤
            if (_autoSwitchTab && _tabControl != null)
            {
                if (targetBox.Parent is TabPage parentTabPage)
                {
                    if (_tabControl.SelectedTab != parentTabPage)
                    {
                        _tabControl.SelectedTab = parentTabPage;
                    }
                }
            }
        }
    }

    // 擴充方法：方便在 LoggerConfiguration 中註冊
    public static class LoggerConfigurationExtensions
    {
        public static Serilog.LoggerConfiguration WinFormRichTextBox(
            this Serilog.Configuration.LoggerSinkConfiguration loggerConfiguration,
            RichTextBox debugBox, RichTextBox infoBox, RichTextBox warnBox, RichTextBox errorBox,
            TabControl tabControl = null,
            LogEventLevel restrictedToMinimumLevel = LogEventLevel.Debug)
        {
            var sink = new RichTextBoxSink(debugBox, infoBox, warnBox, errorBox, tabControl);
            return loggerConfiguration.Sink(sink, restrictedToMinimumLevel);
        }
    }
}
