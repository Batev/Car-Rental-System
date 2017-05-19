namespace GUI
{
    using System.Windows;
    using Client.Context;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static int LoggedUserId;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            HttpClientContext.InitializeHttpClient();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            HttpClientContext.DisposeHttpClient();
        }
    }
}
