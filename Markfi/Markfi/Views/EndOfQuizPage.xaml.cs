using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Markfi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EndOfQuizPage : ContentPage
    {
        public EndOfQuizPage()
        {
            InitializeComponent();
            string message = "Congratulations! You have completed this quiz. Your overall score was: " + QuestionsPageButtons.CorrectCount.ToString() + " out of 5!";

            QuizMessage.Text = message;
        }

        private async void OnClick(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}