using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAutomation.Modules
{
    public class Facebook
    {
        public static async Task Groups(List<string> urls, IPage page)
        {
            await page.GotoAsync("https://www.facebook.com/groups/joins/?nav_source=tab");


        }
    }
}
