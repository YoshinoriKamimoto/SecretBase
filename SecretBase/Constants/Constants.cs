namespace SecretBase.Constants
{
    // 定数クラス
    internal static class Constants
    {
        public const int saltLength = 32; // 暗号化・復号化で使用するソルトの長さ
        public const int passwordLength = 8; // パスワード自動生成で使用するパスワードの長さ
        public static string[] passwordsArray = { // パスワード自動生成で使用する文字
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "_", "!", "&", "%", "?", "$"
        };
    }
}
