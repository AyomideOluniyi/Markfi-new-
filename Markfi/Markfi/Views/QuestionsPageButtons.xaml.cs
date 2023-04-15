using Markfi.Services;
using Markfi.ViewModels;
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
	public partial class QuestionsPageButtons : ContentPage
	{
		public QuestionsPageButtons ()
		{
			InitializeComponent ();
			BindingContext = new QuestionsPageButtons();
		}

		public string Question
		{
			get { return Question; }
			set
			{
				Random rnd = new Random ();
				int index = rnd.Next(0,3);
				var temp = QuestionsStorage.Questions[0];
				Question = temp[index];
			}
		}
	}
}