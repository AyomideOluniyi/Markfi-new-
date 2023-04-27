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
		public IncorrectAnswer ()
		{
			InitializeComponent ();
			Random rnd = new Random ();
			Message.Text = MotivationalMessages.IncorrectMessages[rnd.Next(0, MotivationalMessages.IncorrectMessages.Length)];
			Message.Text += "Unfortunately, the correct answer was: " +QuestionsPageButtons.AnswerString;
		}
        private async void OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuestionsPageButtons());
        }
    }
}