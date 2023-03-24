using Xamarin.Forms;
using System;

namespace Markfi
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            RegisterButton.Clicked += RegisterButton_Clicked;
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            string firstName = FirstNameEntry.Text;
            string lastName = LastNameEntry.Text;
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;
            string confirmPassword = ConfirmPasswordEntry.Text;

            // Check if all fields are filled
            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                await DisplayAlert("Registration Error", "All fields are required. Please fill in all the fields.", "OK");
                return;
            }

            // Checks if the passwords match
            if (password != confirmPassword)
            {
                await DisplayAlert("Registration Error", "Passwords do not match. Please re-enter your password.", "OK");
                return;
            }

            // Checks if the username is already taken
            var existingUser = await App.Database.GetUserByUsernameAsync(username);
            if (existingUser != null)
            {
                await DisplayAlert("Registration Error", "This username is already taken. Please choose a different username.", "OK");
                return;
            }

            // If validation is successful, create a new User object and save it to the database
            User newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = password 
            };

            await App.Database.SaveUserAsync(newUser);

            // Navigates back to the login page
            await DisplayAlert("Registration Successful", "Your account has been created. Please log in.", "OK");
            await Navigation.PopAsync();
        }
    }
}
