using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Text.RegularExpressions;
using HomeBankingDemoTest.Pages;

namespace HomeBankingDemoTest.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CP03_ValidacionSaldos : PageTest
{
    private DashboardPage _dashboardPage = null!;

    [SetUp]
    public async Task IniciarSesion()
    {
        var loginPage = new LoginPage(Page);
        _dashboardPage = new DashboardPage(Page);

        await loginPage.NavegarAsync("https://homebanking-demo-tests.netlify.app/");
        await loginPage.IniciarSesionAsync("demo", "demo123");
        await Expect(_dashboardPage.NombreUsuario).ToBeVisibleAsync();
    }

    [Test]
    public async Task CP03_SeVisualizanLosSaldosDisponibles()
    {
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "capturas/CP03-saldos-visibles.png",
            FullPage = true
        });

        await Expect(_dashboardPage.EtiquetaSaldoDisponibleCuentaCorriente).ToBeVisibleAsync();
        await Expect(_dashboardPage.MontoSaldoCuentaCorriente).ToBeVisibleAsync();
        await Expect(_dashboardPage.MontoSaldoCuentaCorriente).ToContainTextAsync("$");
    }

    [Test]
    public async Task CP03_OcultarYMostrarSaldo()
    {
        var monto = _dashboardPage.MontoSaldoCuentaCorriente;
        var botonOjo = _dashboardPage.BotonOjoCuentaCorriente;

        await Expect(monto).Not.ToHaveClassAsync(new Regex(".*hidden-balance.*"));

        await botonOjo.ClickAsync();
        await Expect(monto).ToHaveClassAsync(new Regex(".*hidden-balance.*"));

        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "capturas/CP03-saldo-oculto.png",
            FullPage = true
        });

        await botonOjo.ClickAsync();
        await Expect(monto).Not.ToHaveClassAsync(new Regex(".*hidden-balance.*"));
    }
}