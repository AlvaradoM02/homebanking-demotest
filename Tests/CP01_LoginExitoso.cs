using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using HomeBankingDemoTest.Pages;

namespace HomeBankingDemoTest.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CP01_LoginExitoso : PageTest
{
    [Test]
    public async Task CP01_InicioDeSesionExitoso()
    {
        var loginPage = new LoginPage(Page);
        var dashboardPage = new DashboardPage(Page);

        // Precondición: usuario ubicado en la pantalla de login
        await loginPage.NavegarAsync("https://homebanking-demo-tests.netlify.app/");

        // Pasos 1-3: ingresar usuario, contraseña y presionar "Iniciar sesión"
        await loginPage.IniciarSesionAsync("demo", "demo123");

        // Evidencia
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "capturas/CP01-login-exitoso.png",
            FullPage = true
        });

        // Resultado esperado: acceso exitoso, visualización del dashboard principal
        await Expect(dashboardPage.NombreUsuario).ToBeVisibleAsync();
    }
}