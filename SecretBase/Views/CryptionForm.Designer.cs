namespace SecretBase.Views
{
    partial class CryptionForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            encryptButton = new Button();
            decryptButton = new Button();
            filePathTextBox = new TextBox();
            selectFileButton = new Button();
            passwordTextBox = new TextBox();
            generatePasswordButton = new Button();
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // encryptButton
            // 
            encryptButton.BackColor = Color.FromArgb(255, 192, 192);
            encryptButton.Location = new Point(125, 207);
            encryptButton.Name = "encryptButton";
            encryptButton.Size = new Size(75, 34);
            encryptButton.TabIndex = 0;
            encryptButton.TabStop = false;
            encryptButton.Text = "暗号化";
            encryptButton.UseVisualStyleBackColor = false;
            encryptButton.Click += encryptButton_Click;
            // 
            // decryptButton
            // 
            decryptButton.BackColor = Color.FromArgb(192, 192, 255);
            decryptButton.Location = new Point(206, 207);
            decryptButton.Name = "decryptButton";
            decryptButton.Size = new Size(75, 34);
            decryptButton.TabIndex = 1;
            decryptButton.TabStop = false;
            decryptButton.Text = "復号化";
            decryptButton.UseVisualStyleBackColor = false;
            decryptButton.Click += decryptButton_Click;
            // 
            // filePathTextBox
            // 
            filePathTextBox.Location = new Point(37, 74);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.ReadOnly = true;
            filePathTextBox.Size = new Size(343, 23);
            filePathTextBox.TabIndex = 2;
            filePathTextBox.TabStop = false;
            // 
            // selectFileButton
            // 
            selectFileButton.Location = new Point(37, 37);
            selectFileButton.Name = "selectFileButton";
            selectFileButton.Size = new Size(75, 31);
            selectFileButton.TabIndex = 3;
            selectFileButton.TabStop = false;
            selectFileButton.Text = "ファイル選択";
            selectFileButton.UseVisualStyleBackColor = true;
            selectFileButton.Click += selectFileButton_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(37, 138);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(129, 23);
            passwordTextBox.TabIndex = 4;
            passwordTextBox.TabStop = false;
            // 
            // generatePasswordButton
            // 
            generatePasswordButton.Location = new Point(172, 134);
            generatePasswordButton.Name = "generatePasswordButton";
            generatePasswordButton.Size = new Size(75, 30);
            generatePasswordButton.TabIndex = 5;
            generatePasswordButton.TabStop = false;
            generatePasswordButton.Text = "自動生成";
            generatePasswordButton.UseVisualStyleBackColor = true;
            generatePasswordButton.Click += generatePasswordButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 120);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 6;
            label1.Text = "パスワード";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // CryptionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 272);
            Controls.Add(label1);
            Controls.Add(selectFileButton);
            Controls.Add(filePathTextBox);
            Controls.Add(generatePasswordButton);
            Controls.Add(decryptButton);
            Controls.Add(encryptButton);
            Controls.Add(passwordTextBox);
            Name = "CryptionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += CryptionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button encryptButton;
        private Button decryptButton;
        private TextBox filePathTextBox;
        private Button selectFileButton;
        private TextBox passwordTextBox;
        private Button generatePasswordButton;
        private Label label1;
        private OpenFileDialog openFileDialog1;
    }
}