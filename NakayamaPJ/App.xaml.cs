using NakayamaPJ.View;
using System.Configuration;
using System.Data;
using System.Windows;

namespace NakayamaPJ
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void Application_Startup(object sender, StartupEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var mainView = new MainView();
                    mainView.Show();
                    loginView.Hide();
                }
            };

        }
    }

}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       