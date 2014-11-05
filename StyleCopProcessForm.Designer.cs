namespace StyleCopProcess
{
    partial class StyleCopProcessForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._processButton = new System.Windows.Forms.Button();
            this._warningMessageTextBox = new System.Windows.Forms.TextBox();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // _processButton
            // 
            this._processButton.Location = new System.Drawing.Point(12, 256);
            this._processButton.Name = "_processButton";
            this._processButton.Size = new System.Drawing.Size(293, 31);
            this._processButton.TabIndex = 0;
            this._processButton.Text = "Process";
            this._processButton.UseVisualStyleBackColor = true;
            this._processButton.Click += new System.EventHandler(this.ClickProcessButton);
            // 
            // _warningMessageTextBox
            // 
            this._warningMessageTextBox.Location = new System.Drawing.Point(12, 12);
            this._warningMessageTextBox.Multiline = true;
            this._warningMessageTextBox.Name = "_warningMessageTextBox";
            this._warningMessageTextBox.Size = new System.Drawing.Size(293, 238);
            this._warningMessageTextBox.TabIndex = 2;
            // 
            // StyleCopProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 294);
            this.Controls.Add(this._warningMessageTextBox);
            this.Controls.Add(this._processButton);
            this.Name = "StyleCopProcessForm";
            this.Text = "StyleCopProcess";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _processButton;
        private System.Windows.Forms.TextBox _warningMessageTextBox;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
    }
}

