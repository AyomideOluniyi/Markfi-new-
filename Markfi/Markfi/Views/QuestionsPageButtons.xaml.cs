using Markfi.Services;
using Markfi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
		public static string CurrentQuiz;
		public static int QuestionsCount;
		public static int[] Indexes = new int[5];
		public QuestionsPageButtons ()
		{
			InitializeComponent ();

			string QuestionString = "Test";

			Random rnd = new Random ();

			try
			{
				if (CurrentQuiz == "Over 65s Quiz")
				{
					// Open files
					// Load data to arrays
					// close files
					// use random function to generate random question
					QuestionString = "Over 65s";
				}
			} catch (Exception ex)
			{
				Debug.Write(ex.Message);
			}


			Question.Text = QuestionString;
		}
    }
}