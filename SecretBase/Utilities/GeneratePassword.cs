using System.Text;

namespace SecretBase.Utilities
{
    // パスワード生成機能を提供するクラス
    internal static class GeneratePassword
    {
        public static string Generate()
        {
            // パスワード生成情報を取得
            int length = Constants.Constants.passwordLength; // パスワードの長さ
            string[] passwordsArray = Constants.Constants.passwordsArray; // パスワードに使用する文字

            // ランダムなパスワードを生成
            StringBuilder passwordBuilder = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int n = random.Next(passwordsArray.Length);
                passwordBuilder.Append(passwordsArray[n]);
            }

            return passwordBuilder.ToString();
        }
    }
}
