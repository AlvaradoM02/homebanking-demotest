using Microsoft.Playwright;

namespace HomeBankingDemoTest.Pages;

public class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }

    public async Task NavegarAsync(string url)
    {
        await _page.GotoAsync(url);
    }

    public async Task IniciarSesionAsync(string usuario, string contrasena)
    {
        await _page.GetByLabel("Usuario").FillAsync(usuario);
        await _page.GetByLabel("Contraseña").FillAsync(contrasena);
        await _page.GetByRole(AriaRole.Button, new() { Name = "Ingresar" }).ClickAsync();
    }

    public ILocator MensajeError => _page.Locator("#login-error");
}