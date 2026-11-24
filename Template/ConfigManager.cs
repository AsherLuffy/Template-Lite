using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Template
{
    public class ConfigManager<T> where T : new()
    {
        private string relativeFilePath;
        private bool isBackup;

        public ConfigManager(string _relativeFilePath, bool _isBackup)
        {
            relativeFilePath = _relativeFilePath;
            isBackup = _isBackup;
        }

        private void Backup(string filePath)
        {
            // 如果檔案已存在，先進行備份
            if (File.Exists(filePath))
            {
                try
                {
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);

                    // 取得原本檔案所在的完整相對資料夾路徑 (例如: "ConfigLot\Config")
                    string directoryName = Path.GetDirectoryName(filePath) ?? string.Empty;

                    // 組合出包含時間戳記的備份檔名
                    string backupFileName = $"{fileNameWithoutExt}_{DateTime.Now:yyyyMMdd_HHmmss}.json";

                    // 結合基礎目錄與相對資料夾，備份檔會正確放在 ConfigLot\Config 底下
                    string backupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryName, backupFileName);

                    // 確保目標資料夾存在 (以防萬一 ConfigLot\Config 尚未被建立)
                    Directory.CreateDirectory(Path.GetDirectoryName(backupPath) ?? string.Empty);

                    File.Copy(filePath, backupPath, true); // true 表示允許覆蓋舊的備份檔
                }
                catch (Exception backupEx)
                {
                    MessageBox.Show($"儲存前備份設定檔失敗: {backupEx.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Save(T data)
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

                if (isBackup)
                    Backup(filePath);

                // 確保目標資料夾存在
                string directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var settings = new JsonSerializerSettings
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore
                };

                string json = JsonConvert.SerializeObject(data, settings);
                File.WriteAllText(filePath, json, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"儲存失敗︰{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public T Load()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

            try
            {
                // 如果檔案不存在，直接建立一個預設物件並存檔
                if (!File.Exists(filePath))
                {
                    T defaultConfig = new T();
                    Save(defaultConfig);
                    return defaultConfig;
                }

                string json = File.ReadAllText(filePath, Encoding.UTF8);
                T config = JsonConvert.DeserializeObject<T>(json);

                if (config == null)
                {
                    return new T();
                }

                return config;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取失敗︰{ex.Message}，將載入預設設定。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new T();
            }
        }
    }
}
