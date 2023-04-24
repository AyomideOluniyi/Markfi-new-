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
		/*
		 *	Global variables are as follows:
		 *	CurrentQuiz stores the loaded quiz so that the relevant quiz pack is loaded
		 *	CorrectCount and IncorrectCount store number of correctly and incorrectly answered questions respectively
		 *	Indexes[] stores the index of each question asked so that the same question is not asked more than once in each quiz
		 *	CurrentIndex stores the index of the question and answer currently being asked
		 *	QuestionString and AnswerString store the question and answer string currently being asked
		 *	QuestionsList and AnswerList store the entire set of questions currently in use
		 */

		public static string CurrentQuiz;
		public static int CorrectCount = 0, IncorrectCount = 0;
		public static int[] Indexes = new int[5];
		public static int CurrentIndex;
		public static string QuestionString;
		public static string AnswerString;
		public static List<String> QuestionsList = new List<String> ();
		public static List<String> AnswersList = new List<String> ();

		public QuestionsPageButtons ()
		{
			InitializeComponent ();

			/*  This section of if statements make sure that the appropriate QuestionsList and AnswersList are loaded.
			 *	For example, if the name of the quiz selected is Film and TV, this is the QuestionsList and AnswersList that should be loaded.
			 *	Quiz packs are stored under the files Questions.cs and Answers.cs (as of 24.04.2023) because file handling is not going to plan */
			if (CurrentQuiz == "Over 65s Quiz")
			{

            }

			if (CurrentQuiz == "Under 10s Pack")
			{
				for (int i = 0; i < Questions.Under10s.Length; i++)
				{
					QuestionsList.Add(Questions.Under10s[i]);
					AnswersList.Add(Answers.Under10s[i]);
				}
			}
			GenerateQuestions(QuestionsList, AnswersList);
		}

		/*  The process of CheckAnswer is as follows:
		 *	1. Increment QuestionsCount so that the quiz isn't repeated forever (or hypothetically until the user runs out of questions)
		 *	2. Compare Input.Text (this is the input provided by the user in the Entry under QuestionsPageButtons.xaml) with the GLOBAL variable
		 *	   AnswerString. AnswerString and QuestionString are global so that they can be used here.
		 *	3. a. If the input is the correct answer: Display the CorrectAnswer page
		 *	3. b. Else: Display the IncorrectAnswer page
		 *	4. From the CorrectAnswer or IncorrectAnswer page, the user selects a button to continue to the next question. This allows the user to
		 *	   progress at their own pace. */
        private async void CheckAnswer(object sender, EventArgs e)
        {
			if (Input.Text == AnswerString)
			{
				await Navigation.PushAsync(new CorrectAnswer());
				CorrectCount++;
			}
			else
			{
				await Navigation.PushAsync(new IncorrectAnswer());
				IncorrectCount++;
			}
        }

		public void GenerateQuestions(List<string> questions, List<string> answers)
		{
			if (CorrectCount + IncorrectCount == 5)
			{
				EndQuiz();
			}
			else
			{
				Random rnd = new Random();

				do {
					CurrentIndex = rnd.Next(questions.Count);
				} while (Indexes.Contains(CurrentIndex));

				int QuestionsCount = CorrectCount + IncorrectCount + 1;
				Indexes[QuestionsCount - 1] = CurrentIndex;
				QuestionString = "Question " + QuestionsCount.ToString() + ": " + questions[CurrentIndex];
				AnswerString = answers[CurrentIndex];
				Question.Text = QuestionString;
			}
        }

		private async void EndQuiz()
		{
			await Navigation.PushAsync(new EndOfQuizPage());
		}
    }
}