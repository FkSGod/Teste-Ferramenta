using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAutomation.Modules
{
    public class GroupModule
    {
        public static async Task Groups(List<string> urls, IPage page, string href)
        {
            await page.GotoAsync("https://www.facebook.com/groups/joins/?nav_source=tab");

            var links = await page.QuerySelectorAllAsync("xpath=//a[@aria-label='Ver grupo']/@href");

            foreach (var link in links)
            {
                var href = await link.GetAttributeAsync("href");
                Console.WriteLine(href);
            }
            return null;

        }
    }
}
