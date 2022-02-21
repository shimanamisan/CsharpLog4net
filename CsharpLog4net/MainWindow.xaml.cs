using log4net; // 追加
using System.Reflection; // 追加
using System.Windows;

namespace CsharpLog4net
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        // MethodBase.GetCurrentMethod().DeclaringType でコードが実行されている namespaceからクラス名 までを取得できる
        // LogManager.GetLoggerメソッドでは、引数にコードが実行されているクラス名を指定する
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public MainWindow()
        {
            InitializeComponent();

            _logger.Info("ログを出力。");  // 2022-02-21 20:19:19,109[1] INFO - ログを出力。
            _logger.Debug("ログを出力。"); // 2022 - 02 - 21 20:21:02,624[1] DEBUG - ログを出力。
            _logger.Warn("ログを出力。");  // 2022 - 02 - 21 20:21:02,625[1] WARN - ログを出力。
            _logger.Fatal("ログを出力。"); // 2022 - 02 - 21 20:21:02,625[1] FATAL - ログを出力。
            _logger.Error("ログを出力。"); // 2022 - 02 - 21 20:21:02,625[1] ERROR - ログを出力。

            // 出力レベルを指定できる
        }
    }
}
