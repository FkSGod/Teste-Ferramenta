using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using FacebookAutomation.Modules;

class Program
{
    static async Task Main(string[] args)
    {
        // Credenciais (educacional)
        string email = "bethercallsaul@gmail.com";
        string senha = "08930893Ju";

        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        // Stealth básico
        await page.AddInitScriptAsync("Object.defineProperty(navigator, 'webdriver', { get: () => undefined });");

        // Login
        Console.WriteLine("Fazendo login...");
        await LoginModule.LoginAsync(page, email, senha);
        Console.WriteLine("Login feito!");

        //Entrar nos Grupos
        Console.WriteLine("Entrando nos Grupos!");
        await GroupModule.JoinGroupsAsync(page, href);

        // Scrape
        Console.WriteLine("Extraindo posts...");
        var posts = await ScraperModule.ScrapePostsAsync(page);
        Console.WriteLine($"Extraídos {posts.Count} posts.");

        await browser.CloseAsync();
    }
}