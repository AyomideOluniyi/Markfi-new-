using System;
using System.Collections.Generic;
using System.Text;

namespace Markfi.Services
{
    public class QuestionsStorage
    {
        public QuestionsStorage()
        {
            var questions = new List<string[]>();
            // Store question packs here
            string[] test = { "Test 1", "Test 2", "Test 3" };
            questions.Add(test);
        }

        public int index = 0;
    }
}
