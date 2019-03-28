using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MyStatAPI.Full;
using Caliburn.Micro;

namespace MyStatWpf
{
    public class LoginViewModel:PropertyChangedBase
    {
        private IWindowManager _windowManager;
        private Api _api;
        private string _statusString;
        private Visibility _loginTextVisibility;
        private Visibility _animVisibility;
        public Visibility LogInTextVisibility
        {
            get => _loginTextVisibility;
            set
            {
                _loginTextVisibility = value;
                NotifyOfPropertyChange();
            }
        }
        public Visibility AnimVisibility
        {
            get => _animVisibility;
            set
            {
                _animVisibility = value;
                NotifyOfPropertyChange();
            }
        }
        public string[] Cities => Enum.GetNames(typeof(Cities));
        public string StatusString
        {
            get => _statusString;
            set
            {
                _statusString = value;
                NotifyOfPropertyChange();
            }
        }

        public LoginViewModel(IWindowManager wndManager)
        {
            LogInTextVisibility = Visibility.Visible;
            AnimVisibility = Visibility.Hidden;
            _windowManager = wndManager;
        }

        public async void Login(string username, object password, int city, Window wnd)
        {
            username = "Kove_z5xl";
            (password as PasswordBox).Password = "K4us3U20";
            try
            {
                SwitchVisibility();
                _api = new Api(username, (password as PasswordBox).Password, (Cities)Enum.ToObject(typeof(Cities), city));
                _api.TryLogin();
                if(_api.CurrentUser == null)
                {
                    SwitchVisibility();
                    StatusString = "Failed";
                    return;
                }

                _windowManager.ShowWindow(new MainViewModel());
                wnd.Close();
            }
            catch (Exception e)
            {
                StatusString = e.Message;
            }
        }

        private void SwitchVisibility()
        {
            if (LogInTextVisibility == Visibility.Visible)
            {
                LogInTextVisibility = Visibility.Hidden;
                AnimVisibility = Visibility.Visible;
            }
            else
            {
                LogInTextVisibility = Visibility.Visible;
                AnimVisibility = Visibility.Hidden;
            }
        }
    }
}
