using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void LoginButton_Clicked(System.Object sender, System.EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isEmailEmpty || isPasswordEmpty)
            {

            }
            else
            {
                try
                {
                    using (var conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                        conn.CreateTable<Users>();

                        var user = conn
                            .Table<Users>()
                            .Where(u => u.Email == emailEntry.Text)
                            .FirstOrDefault();

                        if (user != null)
                        {
                            App.User = user;

                            if (App.User.Password == passwordEntry.Text)
                            {
                                Navigation.PushAsync(new HomePage());
                            }
                            else
                            {
                                DisplayAlert("Error", "Email or password are incorrect", "Ok");
                            }
                        }
                        else
                        {
                            DisplayAlert("Error", "There was an error logging you in", "Ok");
                        }
                    }
                }
                catch(NullReferenceException)
                {
                }
                catch(Exception)
                {
                }
            }
        }

        void RegisterUserButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
