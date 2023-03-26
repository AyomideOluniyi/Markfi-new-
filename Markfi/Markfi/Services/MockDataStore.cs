using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Markfi.Models;

namespace Markfi.Services
{
    public class MockDataStore : IDataStore<QuizListItem>
    {
        readonly List<QuizListItem> items;

        public MockDataStore()
        {
            items = new List<QuizListItem>()
            {
                new QuizListItem {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Over 65s Quiz",
                    Description="Pack designed for users over the age of 65" },

                new QuizListItem {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Under 10s Pack",
                    Description="Pack designed for users under the age of 10" },

                new QuizListItem {
                    Id = Guid.NewGuid().ToString(),
                    Text = "TV and Film Pack",
                    Description="Pack themed around TV and Film" },

                new QuizListItem {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Pop Culture and Movies Pack",
                    Description="Pack designed around Pop Culture and Movies" }
            };
        }

        public async Task<bool> AddItemAsync(QuizListItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(QuizListItem item)
        {
            var oldItem = items.Where((QuizListItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((QuizListItem arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<QuizListItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<QuizListItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}