using System;
using System.Collections.Generic;
using System.Text;

namespace Markfi.Services
{
    public class QuestionsStorage
    {
        public static List<string[]> Questions = new List<string[]>();
        public QuestionsStorage()
        {
            // Store question packs here
            string[] test = { "Test 1", "Test 2", "Test 3" };
            Questions.Add(test);
        }

        public int index = 0;
    }
}
