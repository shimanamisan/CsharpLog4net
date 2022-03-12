using log4net; // 追加
using System;
using System.Collections.Generic;
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
       
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            _logger.Info("ログを出力。");
            _logger.Debug("ログを出力。");
            _logger.Warn("ログを出力。");
            _logger.Fatal("ログを出力。");
            _logger.Error("ログを出力。");
            // 出力レベルを指定できる

            _logger.Info("世代管理確認用のログ。世代管理確認用のログ。世代管理確認用のログ。" +
                "世代管理確認用のログ。世代管理確認用のログ。世代管理確認用のログ。世代管理確認用のログ。" +
                "世代管理確認用のログ。世代管理確認用のログ。世代管理確認用のログ。世代管理確認用のログ。" +
                "世代管理確認用のログ。世代管理確認用のログ。世代管理確認用のログ。世代管理確認用のログ。" +
                "世代管理確認用のログ。世代管理確認用のログ。世代管理確認用のログ。世代管理確認用のログ。");
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                var lists = new List<int>();

                // リストの中身が無いので必ず例外が発生
                var lsit = lists[0];
            }
            catch (Exception ex)
            {
                _logger.Error("例外が発生：", ex);
            }
        }
    }
}
