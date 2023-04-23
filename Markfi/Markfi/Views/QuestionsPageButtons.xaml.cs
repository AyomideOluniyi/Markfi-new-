using Markfi.Services;
using Markfi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Markfi.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuestionsPageButtons : ContentPage
	{
		public QuestionsPageButtons ()
		{
			InitializeComponent ();
			string QuestionString = "Test";
			string OptionOneString = "Option x";

			Question.Text = QuestionString;
			Option1.Text = OptionOneString;
		}
    }
}