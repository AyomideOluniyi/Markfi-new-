using Markfi.Views;
using Xamarin.Forms;

namespace Markfi
{
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private async void StartQuizButton_Clicked(object sender, System.EventArgs e)
        {
            // Navigate to the Quiz list
            await Navigation.PushAsync(new Quizzes_list());
        }

        private async void LogoutButton_Clicked(object sender, System.EventArgs e)
        {
            // Navigates back to the login page
            await Navigation.PopToRootAsync();
        }
    }
}
