using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Markfi.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IncorrectAnswer : ContentPage
	{
		/*	IncorrectAnswer is loaded when the user answers a question incorrectly. The page features a message saying that the user has not answered the
		 *	question correctly, but also features a randomly generated motivational message (this is what rnd is for). */
		public IncorrectAnswer ()
		{
			InitializeComponent ();
			Random rnd = new Random ();
			Message.Text = MotivationalMessages.IncorrectMessages[rnd.Next(0, MotivationalMessages.IncorrectMessages.Length)];
			Message.Text += "Unfortunately, the correct answer was: " +QuestionsPageButtons.AnswerString;
		}

		//	OnClick is the procedure linked to the next question button on IncorrectAnswer.xaml. It tells the program to load the next question.
        private async void OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuestionsPageButtons());
        }
    }
}