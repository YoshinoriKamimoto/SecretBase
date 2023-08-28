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

        // �t�@�C���I���{�^��
        private void selectFileButton_Click(object sender, EventArgs e)
        {
            // �_�C�A���O�����ݒ�
            string openFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.InitialDirectory = openFolder;
            openFileDialog1.Filter = "���ׂẴt�@�C�� (*.*)|*.*";
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.RestoreDirectory = true;

            // �_�C�A���O�\��
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                filePathTextBox.Text = filePath;
            }
        }

        // ���������{�^��
        private void generatePasswordButton_Click(object sender, EventArgs e)
        {
            try
            {
                passwordTextBox.Text = GeneratePassword.Generate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"�p�X���[�h�����G���[\n{ex}");
                MessageBox.Show($"�p�X���[�h�����G���[\n\n{ex.Message}", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // �Í����{�^��
        private void encryptButton_Click(object sender, EventArgs e)
        {
            // �t�@�C���p�X�E�p�X���[�h�擾
            string filePath = filePathTextBox.Text;
            string password = passwordTextBox.Text;

            // �o���f�[�V�����`�F�b�N
            if (ValidateInputData(filePath, password) == false)
            {
                return;
            }

            // �Í���
            try
            {
                FileCryption.EncryptFile(filePath, password);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"�Í����G���[\n{ex}");
                MessageBox.Show($"�Í����G���[\n\n{ex.Message}", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("�Í�������", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // �������{�^��
        private void decryptButton_Click(object sender, EventArgs e)
        {
            // �t�@�C���p�X�E�p�X���[�h�擾
            string filePath = filePathTextBox.Text;
            string password = passwordTextBox.Text;

            // �o���f�[�V�����`�F�b�N
            if (ValidateInputData(filePath, password) == false)
            {
                return;
            }

            // ������
            try
            {
                FileCryption.DecryptFile(filePath, password);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"�������G���[\n{ex}");
                MessageBox.Show($"�������G���[\n\n{ex.Message}", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("����������", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ���̓f�[�^�̃o���f�[�V�����`�F�b�N
        private bool ValidateInputData(string filePath, string password)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("�t�@�C�����I������Ă��܂���", "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("�p�X���[�h�����͂���Ă��܂���", "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CryptionForm_Load(object sender, EventArgs e)
        {
            // �A�v����(�A�Z���u����)���^�C�g���ɐݒ�
            try
            {
                this.Text = Assembly.GetExecutingAssembly().GetName().Name;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"�A�Z���u�����擾�G���[\n{ex}");
                MessageBox.Show($"�A�Z���u�����擾�G���[\n\n{ex.Message}", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}