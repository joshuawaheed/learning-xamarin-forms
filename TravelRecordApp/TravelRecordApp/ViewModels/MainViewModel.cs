using System;
using System.ComponentModel;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool entriesHaveText;
        private string email;
        private string password;

        public bool EntriesHaveText
        {
            get
            {
                bool isEmailEmpty = string.IsNullOrEmpty(Email);
                bool isPasswordEmpty = string.IsNullOrEmpty(Password);

                return !isEmailEmpty && !isPasswordEmpty;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged(nameof(EntriesHaveText));
            }
        }

        public Command LoginCommand { get; set; }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(EntriesHaveText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command RegisterCommand { get; set; }

        public MainViewModel()
        {
            LoginCommand = new Command<bool>(Login, CanLogin);
            RegisterCommand = new Command(Register);
        }

        private bool CanLogin(bool parameter)
        {
            return EntriesHaveText;
        }

        private void Login(bool parameter)
        {
            try
            {
                using (var conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Users>();

                    var user = conn
                        .Table<Users>()
                        .Where(u => u.Email == Email)
                        .FirstOrDefault();

                    if (user != null)
                    {
                        App.User = user;

                        if (App.User.Password == Password)
                        {
                            App.Current.MainPage.Navigation.PushAsync(new HomePage());
                        }
                        else
                        {
                            App.Current.MainPage.DisplayAlert(
                                "Error",
                                "Email or password are incorrect",
                                "Ok");
                        }
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert(
                            "Error",
                            "There was an error logging you in",
                            "Ok");
                    }
                }
            }
            catch (NullReferenceException)
            {
            }
            catch (Exception)
            {
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Register()
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
