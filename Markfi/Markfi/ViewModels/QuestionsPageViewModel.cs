using Markfi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markfi.ViewModels
{
    public class QuestionsPageViewModel : BaseViewModel
    {
        private string question;
        public string Question
        {
            get { return question; }
            set
            {
                Random rnd = new Random();
                int index = rnd.Next(0, 3);
                var temp = QuestionsStorage.Questions[0];
                question = temp[index];
            }
        }
    }
}
