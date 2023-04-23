using Markfi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markfi.ViewModels
{
    public class QuestionsPageViewModel : BaseViewModel
    {
        public string Question
        {
            get; set;
        }
        public QuestionsPageViewModel()
        {
            try
            {
                Random rnd = new Random();
                int index = rnd.Next(0, 2);
                string[] temp = QuestionsStorage.Questions[0];
                Question = temp[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
