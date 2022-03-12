using log4net;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace CsharpLog4net
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {

        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public App()
        {

        }

        private void Application_DispatcherUnhandledException(object sender,
            DispatcherUnhandledExceptionEventArgs e)
        {
            _logger.Error(e.Exception.Message, e.Exception);
            MessageBox.Show(e.Exception.Message);

            // ハンドルされない例外を処理済みにするためにtrueを指定
            e.Handled = true;
        }
    }
}
