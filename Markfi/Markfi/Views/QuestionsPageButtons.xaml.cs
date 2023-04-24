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
using System.Threading;

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
		public static int CurrentIndex;
		public static string QuestionString;
		public static string AnswerString;

		public QuestionsPageButtons ()
		{
			InitializeComponent ();

			QuestionString = "Questions";

			// Random function to generate random indexes for questions
			Random rnd = new Random();

			if (CurrentQuiz == "Over 65s Quiz")
			{
				if (QuestionsCount == 6)
				{
					// DO NOT RUN QUESTIONS
					// SHOW SCORE /5
					// CLOSE QUESTIONSPAGE
				}
				CurrentIndex = rnd.Next(Questions.Under10s.Length);
				while (Indexes.Contains(CurrentIndex))
				{
					CurrentIndex = rnd.Next(Questions.Under10s.Length);
                }
				Indexes[QuestionsCount-1] = CurrentIndex;
				QuestionString = "Question " + QuestionsCount.ToString() + ": " + Questions.Under10s[CurrentIndex];
				AnswerString = Answers.Under10s[CurrentIndex];
				Question.Text = QuestionString;
            }
		}

        private async void CheckAnswer(object sender, EventArgs e)
        {
			QuestionsCount++;
			if (CurrentQuiz == "Over 65s Quiz")
			{
				if (Input.Text == AnswerString)
				{
                    // Display correct answer
                    await Navigation.PushAsync(new CorrectAnswer());
					Thread.Sleep(1000);
					await Navigation.PopAsync();
                }
				else
				{
					// Display incorrect answer
					await Navigation.PushAsync(new IncorrectAnswer());
					Thread.Sleep(1000);
					await Navigation.PopAsync();
				}

			}
        }
    }
}