using System;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (passwordEntry.Text == confirmPasswordEntry.Text)
            {
                try
                {
                    Users user = new Users()
                    {
                        Email = emailEntry.Text,
                        Password = passwordEntry.Text
                    };

                    using (var conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                        conn.CreateTable<Users>();

                        int rows = conn.Insert(user);

                        if (rows > 0)
                        {
                            await DisplayAlert("Success", "User successfully registered", "Ok");
                        }
                        else
                        {
                            await DisplayAlert("Failure", "Failed to register user", "Ok");
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
            else
            {
                await DisplayAlert("Error", "Passwords don't match", "Ok");
            }
        }
    }
}
