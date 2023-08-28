using SecretBase.Utilities;
using System.Diagnostics;
using System.Reflection;

namespace SecretBase.Views
{
    public partial class CryptionForm : Form
    {
        public CryptionForm()
        {
            InitializeComponent();
        }

        // ファイル選択ボタン
        private void selectFileButton_Click(object sender, EventArgs e)
        {
            // ダイアログ初期設定
            string openFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.InitialDirectory = openFolder;
            openFileDialog1.Filter = "すべてのファイル (*.*)|*.*";
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.RestoreDirectory = true;

            // ダイアログ表示
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                filePathTextBox.Text = filePath;
            }
        }

        // 自動生成ボタン
        private void generatePasswordButton_Click(object sender, EventArgs e)
        {
            try
            {
                passwordTextBox.Text = GeneratePassword.Generate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"パスワード生成エラー\n{ex}");
                MessageBox.Show($"パスワード生成エラー\n\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // 暗号化ボタン
        private void encryptButton_Click(object sender, EventArgs e)
        {
            // ファイルパス・パスワード取得
            string filePath = filePathTextBox.Text;
            string password = passwordTextBox.Text;

            // バリデーションチェック
            if (ValidateInputData(filePath, password) == false)
            {
                return;
            }

            // 暗号化
            try
            {
                FileCryption.EncryptFile(filePath, password);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"暗号化エラー\n{ex}");
                MessageBox.Show($"暗号化エラー\n\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("暗号化完了", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 復号化ボタン
        private void decryptButton_Click(object sender, EventArgs e)
        {
            // ファイルパス・パスワード取得
            string filePath = filePathTextBox.Text;
            string password = passwordTextBox.Text;

            // バリデーションチェック
            if (ValidateInputData(filePath, password) == false)
            {
                return;
            }

            // 復号化
            try
            {
                FileCryption.DecryptFile(filePath, password);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"復号化エラー\n{ex}");
                MessageBox.Show($"復号化エラー\n\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("復号化完了", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 入力データのバリデーションチェック
        private bool ValidateInputData(string filePath, string password)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("ファイルが選択されていません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("パスワードが入力されていません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CryptionForm_Load(object sender, EventArgs e)
        {
            // アプリ名(アセンブリ名)をタイトルに設定
            try
            {
                this.Text = Assembly.GetExecutingAssembly().GetName().Name;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"アセンブリ名取得エラー\n{ex}");
                MessageBox.Show($"アセンブリ名取得エラー\n\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}