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

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    GetData();
            //}
            //catch (Exception ex)
            //{
            //    _logger.Error("エラー！！", ex);
            //}

            // どこにもキャッチされていない例外はApp.xamlに作成した
            // Application_DispatcherUnhandledException でキャッチされる
            GetData();
        }

        private void GetData()
        {
            try
            {
                var lists = new List<int>();
                var csv = lists[0];
            }
            catch (Exception ex)
            {
                // Exceptionの情報は無くしたくないが、出力されるメッセージはオリジナルのものにしたい
                throw new CsvReadException(ex);
            }
        }
    }

    // 自作の例外
    public sealed class CsvReadException : Exception
    {
        // CSVの読み込みでindexの境界外でArgumentOutOfRangeExceptionだったけれども
        // CsvExceptionとしたい場合
        // 引数にオリジナルのExceptionを指定していると、元情報のExceptionを保持しながらオリジナルのメッセージを出力する事ができる
        // つまり、オリジナルの例外を出しつつ、その情報が何でどの行のコードなのか詳細な情報（innerException）も出せる
        public CsvReadException(Exception exception)
            :base("CSVの読み込みに失敗しました", exception)
        {

        }
    }
}
