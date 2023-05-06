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
			QuestionsList.Clear();
			AnswersList.Clear();

			/*  This section of if statements make sure that the appropriate QuestionsList and AnswersList are loaded.
			 *	For example, if the name of the quiz selected is Film and TV, this is the QuestionsList and AnswersList that should be loaded.
			 *	Quiz packs are stored under the files Questions.cs and Answers.cs (as of 24.04.2023) because file handling is not going to plan */
			if (CurrentQuiz == "Over 65s Pack")
			{
                for (int i = 0; i < Questions.Over65s.Length; i++)
                {
                    QuestionsList.Add(Questions.Over65s[i]);
                    AnswersList.Add(Answers.Over65s[i]);
                }
            }

			if (CurrentQuiz == "Under 10s Pack")
			{
				for (int i = 0; i < Questions.Under10s.Length; i++)
				{
					QuestionsList.Add(Questions.Under10s[i]);
					AnswersList.Add(Answers.Under10s[i]);
				}
			}

			if (CurrentQuiz == "TV and Film Pack")
			{
                for (int i = 0; i < Questions.TVFilm.Length; i++)
                {
                    QuestionsList.Add(Questions.TVFilm[i]);
                    AnswersList.Add(Answers.TVFilm[i]);
                }
            }

			if (CurrentQuiz == "Pop Culture and Movies Pack")
			{
				for (int i = 0; i < Questions.PopCulture.Length; i++)
				{
					QuestionsList.Add(Questions.PopCulture[i]);
					AnswersList.Add(Answers.PopCulture[i]);
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
			if (ConvertAnswer(Input.Text) == AnswerString.ToUpper())
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

		/* GenerateQuestions() is a function that takes a list of questions and answers as parameters. The process of GenerateQuestions() is
		 * as follows:
		 * 1. a. If the user has answered a total of 5 questions:
		 *			Call the EndQuiz() function to end the quiz
		 * 1. b. Else:
		 *			Generate a random index
		 *			If this index has already been used in this quiz, generate a new index until one is generated that hasn't already been used.
		 *			Store the generated index under the global integer array Indexes
		 *			Display the question alongside the question number by storing it under the string QuestionString and updating Question.Text
		 *			with this string's data
		 *			Store the answer to this question in the string AnswerString to be used with the function CheckAnswer() */
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

		/* ConvertAnswer() is a function that takes a string input and formats it correctly to be checked against an answer string. This method stops
		 * correct answers being marked as incorrect if they have a space at the end of the string, for example. The process of ConvertAnswer() is as
		 * follows:
		 * 1. If the answer is empty, return the empty answer as there is not a string to work with.
		 * 2. Else, trim the string of extra space and convert the entire answer to uppercase, then remove all punctuation from the string so if they
		 *    forget a comma, for example, they still get the correct answer message.
		 * 3. Return the new string */
		public string ConvertAnswer(string answer)
		{
			if (String.IsNullOrEmpty(answer)) { return ""; }
			answer = answer.Trim();
			answer = answer.ToUpper();

			string returnvalue = String.Empty;

			// Checking if the input is an integer and not removing non-characters if so
			if (Int32.TryParse(answer, out int number) == true) { return answer; }

			foreach (char c in answer)
			{
				if (!char.IsPunctuation(c)) { returnvalue += c;}
			}

			return ConvertToInt(returnvalue);
		}


		/* ConvertToInt converts a string from a worded number to an integer. It has only been implemented for the given answers.
		 * For example, "seven" will return "7" which is the correct answer in the answer class. */
		public string ConvertToInt(string answer)
		{
			if (answer == "SEVEN") { return "7"; }
            if (answer == "TWENTY FOUR") { return "24"; }
			if (answer == "THOUSAND" || answer == "ONE THOUSAND") { return "1000"; }
			if (answer == "THREE") { return "3"; }
			if (answer == "THIRTEEN") { return "13"; }
			if (answer == "EIGHT") { return "8"; }
			if (answer == "2" && QuestionString.Contains("What is the name of Walter and Skylar's second child in Breaking Bad?")) { return "2 YEARS"; }
			return answer;
        }
    }
}