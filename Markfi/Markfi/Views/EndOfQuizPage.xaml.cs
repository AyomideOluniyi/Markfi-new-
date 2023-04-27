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
        /*  EndOfQuizPage is loaded once the user has finished their quiz. They are then presented with their score out of 5 which is tracked under
         *  QuestionsPageButtons in a global variable. This information is then presented to the user using the label QuizMessage's text attribute. */
        public EndOfQuizPage()
        {
            InitializeComponent();
            string message = "Your overall score was: " + QuestionsPageButtons.CorrectCount.ToString() + " out of 5!";
            QuizMessage.Text = message;
        }

        /*  OnClick is a procedure that links to the button in EndOfQuiz.xaml. The code attached to this tells the program to go back to the list of
         *  all the user's quiz packs.  */
        private async void OnClick(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}