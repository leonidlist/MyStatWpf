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

        public LoginViewModel()
        {
            LogInTextVisibility = Visibility.Visible;
            AnimVisibility = Visibility.Hidden;
        }

        public async void Login(string username, object password, int city)
        {
            try
            {
                SwitchVisibility();
                _api = new Api(username, (password as PasswordBox).Password, (Cities)Enum.ToObject(typeof(Cities), city));
                await _api.TryLoginAsync();
                if (_api.CurrentUser != null)
                {
                    SwitchVisibility();
                    StatusString = $"Logged in. Hello, {_api.CurrentUser.FullName}";
                }
                else
                {
                    SwitchVisibility();
                    StatusString = "Failed";
                }
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
