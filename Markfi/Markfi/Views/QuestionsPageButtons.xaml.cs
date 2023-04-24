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
		 *	QuestionsCount stores the question number so that the quiz produces exactly 5 questions
		 *	Indexes[] stores the index of each question asked so that the same question is not asked more than once in each quiz
		 *	CurrentIndex stores the index of the question and answer currently being asked
		 *	QuestionString and AnswerString store the question and answer string currently being asked
		 *	QuestionsList and AnswerList store the entire set of questions currently in use
		 */

		public static string CurrentQuiz;
		public static int QuestionsCount;
		public static int[] Indexes = new int[5];
		public static int CurrentIndex;
		public static string QuestionString = "Questions";
		public static string AnswerString;
		public static List<String> QuestionsList = new List<String> ();
		public static List<String> AnswersList = new List<String> ();

		public QuestionsPageButtons ()
		{
			InitializeComponent ();

			/*
			 *	This section of if statements make sure that the appropriate QuestionsList and AnswersList are loaded.
			 *	For example, if the name of the quiz selected is film and tv, this is the QuestionsList and AnswersList that should be loaded.
			 *	Quiz packs are stored under the files Questions.cs and Answers.cs (as of 24.04.2023) because file handling is not going to plan.
			 */
			if (CurrentQuiz == "Over 65s Quiz")
			{
				for (int i = 0; i < Questions.Under10s.Length; i++)
				{
					QuestionsList.Add(Questions.Under10s[i]);
					AnswersList.Add(Answers.Under10s[i]);
				}
            }
			GenerateQuestions(QuestionsList, AnswersList);
		}

		/*
		*	The process of CheckAnswer is as follows:
		*	1. Increment QuestionsCount so that the quiz isn't repeated forever (or hypothetically until the user runs out of questions)
		*	2. Compare Input.Text (this is the input provided by the user in the Entry under QuestionsPageButtons.xaml) with the GLOBAL variable
		*	   AnswerString. AnswerString and QuestionString are global so that they can be used here.
		*	3. a. If the input is the correct answer: Display the CorrectAnswer page
		*	3. b. Else: Display the IncorrectAnswer page
		*	4. Regardless of whether or not the user answered the question right, wait 1000ms (1 second) then pop the page. This will take the user
		*	   back to the questions.
		*	5. Generate the next question using the GenerateQuestions() function.
		*/
        private async void CheckAnswer(object sender, EventArgs e)
        {
			QuestionsCount++;
			if (Input.Text == AnswerString)
			{
				await Navigation.PushAsync(new CorrectAnswer());
			}
			else
			{
				await Navigation.PushAsync(new IncorrectAnswer());
			}

			Thread.Sleep(1000);
			await Navigation.PopAsync();
			GenerateQuestions(QuestionsList, AnswersList);
        }

		public void GenerateQuestions(List<string> questions, List<string> answers)
		{
			// Random function to generate random indexes for questions
			Random rnd = new Random();

			do {
				CurrentIndex = rnd.Next(questions.Count);
			} while (Indexes.Contains(CurrentIndex));

            Indexes[QuestionsCount - 1] = CurrentIndex;
            QuestionString = "Question " + QuestionsCount.ToString() + ": " + questions[CurrentIndex];
            AnswerString = answers[CurrentIndex];
            Question.Text = QuestionString;
        }
    }
}