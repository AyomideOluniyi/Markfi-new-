using Markfi.Services;
using Markfi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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

			string QuestionString;

			// Get generic file path for Over 65s Quiz Question file
			string FilePath = Directory.GetCurrentDirectory();

			// Random function to generate random indexes for questions
			Random rnd = new Random();

			if (CurrentQuiz == "Over 65s Quiz")
			{
				try
				{
					// Combine the current directory with the relevant file
					FilePath = Path.Combine(FilePath, "Over65Questions.txt");

					// Read file contents
					string[] Questions = File.ReadAllLines(FilePath);

					// Set question in .xaml
					QuestionString = Questions[rnd.Next(Questions.Length)];
					Question.Text = QuestionString;


					// Open files
					// Load data to arrays
					// close files
					// use random function to generate random question
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
				}
            }
		}

        private void CheckAnswer(object sender, EventArgs e)
        {

        }
    }
}