using Microsoft.Playwright;

class Program
{
    public static async Task Main()
    {
        // Inicializa Playwright
        using var playwright = await Playwright.CreateAsync();

        // Abre o navegador Chromium
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false, // Deixe "false" para ver o navegador e fazer login
            Args = new[] { "--disable-blink-features=AutomationControlled" }
        });

        // Cria um novo contexto (janela anônima com cookies separados)
        var context = await browser.NewContextAsync();

        // Cria uma nova aba
        var page = await context.NewPageAsync();

        // Injeta JS para "camuflar" o navegador automatizado
        await page.AddInitScriptAsync("Object.defineProperty(navigator, 'webdriver', { get: () => undefined });");

        // Vai para a página do Facebook
        await page.GotoAsync("https://www.facebook.com");

        // Espera o usuário logar manualmente
        Console.WriteLine("🔐 Faça login manualmente e pressione ENTER aqui no console...");
        Console.ReadLine();

        // Espera o feed aparecer na tela
        await page.WaitForSelectorAsync("div[role='feed']");

        Console.WriteLine("📃 Extraindo textos do feed...");

        // Seleciona os posts com texto do feed
        var posts = await page.QuerySelectorAllAsync("div[role='feed'] div[data-ad-preview='message']");

        int count = 1;
        foreach (var post in posts)
        {
            var text = await post.InnerTextAsync();
            Console.WriteLine($"\n📌 Post {count++}:\n{text}\n---------------------");
        }

        Console.WriteLine("✅ Extração finalizada. Pressione ENTER para sair.");
        Console.ReadLine();

        // Fecha o navegador
        await browser.CloseAsync();
    }
}
