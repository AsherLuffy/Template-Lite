using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Template
{
    public class AppSettings
    {
        public string ServerIp { get; set; }
        public int Port { get; set; }
    }

    public static class TextBoxExtensions
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        /// <summary>
        /// 為 TextBox 設定浮水印文字
        /// </summary>
        /// <param name="textBox">目標 TextBox</param>
        /// <param name="watermark">浮水印內容</param>
        /// <param name="showWhenFocused">取得焦點時是否仍顯示浮水印（預設為 false）</param>
        public static void SetWatermark(this TextBox textBox, string watermark, bool showWhenFocused = false)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, showWhenFocused ? 1 : 0, watermark);
        }
    }


}
