using Microsoft.Playwright;

namespace FacebookAutomation.Modules
{
    public static class LoginModule
    {
        public static async Task LoginAsync(IPage page, string email, string senha)
        {
            //vai para a pag de login
            await page.GotoAsync("https://www.facebook.com/login");

            // Preenche email e senha via XPath
            await page.FillAsync("xpath=//input [@id = 'email']", email);
            await Task.Delay(5000);

            await page.FillAsync("xpath=//input [@id = 'pass']", senha);
            await Task.Delay(5000);

            // Clica no botão de login
            await page.ClickAsync("button[name='login']");

            // Espera o feed carregar
            await page.WaitForSelectorAsync("div[role='feed']");

        }
    }
}