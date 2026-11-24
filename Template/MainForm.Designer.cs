namespace Template
{
    partial class Template
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LogRecord = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.richTextBoxGeneral = new System.Windows.Forms.RichTextBox();
            this.tabPageWarning = new System.Windows.Forms.TabPage();
            this.richTextBoxWarning = new System.Windows.Forms.RichTextBox();
            this.tabPageError = new System.Windows.Forms.TabPage();
            this.richTextBoxError = new System.Windows.Forms.RichTextBox();
            this.tabPageDebug = new System.Windows.Forms.TabPage();
            this.richTextBoxDebug = new System.Windows.Forms.RichTextBox();
            this.ServeIP = new System.Windows.Forms.TextBox();
            this.Port = new System.Windows.Forms.TextBox();
            this.Demo = new System.Windows.Forms.Button();
            this.LogRecord.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tabPageWarning.SuspendLayout();
            this.tabPageError.SuspendLayout();
            this.tabPageDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogRecord
            // 
            this.LogRecord.Controls.Add(this.tabPageGeneral);
            this.LogRecord.Controls.Add(this.tabPageWarning);
            this.LogRecord.Controls.Add(this.tabPageError);
            this.LogRecord.Controls.Add(this.tabPageDebug);
            this.LogRecord.Location = new System.Drawing.Point(0, 315);
            this.LogRecord.Name = "LogRecord";
            this.LogRecord.SelectedIndex = 0;
            this.LogRecord.Size = new System.Drawing.Size(799, 135);
            this.LogRecord.TabIndex = 5;
            this.LogRecord.Tag = "";
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.richTextBoxGeneral);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(791, 109);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // richTextBoxGeneral
            // 
            this.richTextBoxGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxGeneral.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxGeneral.Name = "richTextBoxGeneral";
            this.richTextBoxGeneral.Size = new System.Drawing.Size(785, 103);
            this.richTextBoxGeneral.TabIndex = 0;
            this.richTextBoxGeneral.Text = "";
            // 
            // tabPageWarning
            // 
            this.tabPageWarning.Controls.Add(this.richTextBoxWarning);
            this.tabPageWarning.Location = new System.Drawing.Point(4, 22);
            this.tabPageWarning.Name = "tabPageWarning";
            this.tabPageWarning.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWarning.Size = new System.Drawing.Size(791, 109);
            this.tabPageWarning.TabIndex = 1;
            this.tabPageWarning.Text = "Warning";
            this.tabPageWarning.UseVisualStyleBackColor = true;
            // 
            // richTextBoxWarning
            // 
            this.richTextBoxWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxWarning.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxWarning.Name = "richTextBoxWarning";
            this.richTextBoxWarning.Size = new System.Drawing.Size(785, 103);
            this.richTextBoxWarning.TabIndex = 0;
            this.richTextBoxWarning.Text = "";
            // 
            // tabPageError
            // 
            this.tabPageError.Controls.Add(this.richTextBoxError);
            this.tabPageError.Location = new System.Drawing.Point(4, 22);
            this.tabPageError.Name = "tabPageError";
            this.tabPageError.Size = new System.Drawing.Size(791, 109);
            this.tabPageError.TabIndex = 2;
            this.tabPageError.Text = "Error";
            this.tabPageError.UseVisualStyleBackColor = true;
            // 
            // richTextBoxError
            // 
            this.richTextBoxError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxError.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxError.Name = "richTextBoxError";
            this.richTextBoxError.Size = new System.Drawing.Size(791, 109);
            this.richTextBoxError.TabIndex = 0;
            this.richTextBoxError.Text = "";
            // 
            // tabPageDebug
            // 
            this.tabPageDebug.Controls.Add(this.richTextBoxDebug);
            this.tabPageDebug.Location = new System.Drawing.Point(4, 22);
            this.tabPageDebug.Name = "tabPageDebug";
            this.tabPageDebug.Size = new System.Drawing.Size(791, 109);
            this.tabPageDebug.TabIndex = 3;
            this.tabPageDebug.Text = "Debug";
            this.tabPageDebug.UseVisualStyleBackColor = true;
            // 
            // richTextBoxDebug
            // 
            this.richTextBoxDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxDebug.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxDebug.Name = "richTextBoxDebug";
            this.richTextBoxDebug.Size = new System.Drawing.Size(791, 109);
            this.richTextBoxDebug.TabIndex = 0;
            this.richTextBoxDebug.Text = "";
            // 
            // ServeIP
            // 
            this.ServeIP.Location = new System.Drawing.Point(628, 183);
            this.ServeIP.Name = "ServeIP";
            this.ServeIP.Size = new System.Drawing.Size(100, 22);
            this.ServeIP.TabIndex = 7;
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(628, 241);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(100, 22);
            this.Port.TabIndex = 8;
            // 
            // Demo
            // 
            this.Demo.Location = new System.Drawing.Point(641, 126);
            this.Demo.Name = "Demo";
            this.Demo.Size = new System.Drawing.Size(75, 23);
            this.Demo.TabIndex = 6;
            this.Demo.Text = "Demo";
            this.Demo.UseVisualStyleBackColor = true;
            this.Demo.Click += new System.EventHandler(this.MainBtn_Click);
            // 
            // Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.ServeIP);
            this.Controls.Add(this.Demo);
            this.Controls.Add(this.LogRecord);
            this.Name = "Template";
            this.Text = "Template";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LogRecord.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageWarning.ResumeLayout(false);
            this.tabPageError.ResumeLayout(false);
            this.tabPageDebug.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl LogRecord;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageWarning;
        private System.Windows.Forms.TabPage tabPageError;
        private System.Windows.Forms.TabPage tabPageDebug;
        private System.Windows.Forms.RichTextBox richTextBoxGeneral;
        private System.Windows.Forms.RichTextBox richTextBoxWarning;
        private System.Windows.Forms.RichTextBox richTextBoxError;
        private System.Windows.Forms.RichTextBox richTextBoxDebug;
        private System.Windows.Forms.TextBox ServeIP;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Button Demo;
    }
}

