using Microsoft.Playwright;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace FacebookAutomation.Modules
{
    public static class ScraperModule
    {
        public static async Task<List<string>> ScrapePostsAsync(IPage page)
        {
            var posts = await page.QuerySelectorAllAsync("div[role='feed'] div[data-ad-preview='message']");

            var postList = new List<string>();

            foreach (var post in posts)
            {
                var text = await post.InnerTextAsync();
                postList.Add(text);
            }

            // Salvar posts em JSON
            var json = JsonSerializer.Serialize(postList, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync("posts.json", json);

            return postList;
        }
    }
}