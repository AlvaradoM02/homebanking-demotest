using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using HomeBankingDemoTest.Pages;

namespace HomeBankingDemoTest.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CP04_TransferenciaSaldoSuficiente : PageTest
{
    [SetUp]
    public async Task IniciarSesion()
    {
        var loginPage = new LoginPage(Page);
        var dashboardPage = new DashboardPage(Page);

        await loginPage.NavegarAsync("https://homebanking-demo-tests.netlify.app/");
        await loginPage.IniciarSesionAsync("demo", "demo123");
        await Expect(dashboardPage.NombreUsuario).ToBeVisibleAsync();
    }

    [Test]
    public async Task CP04_TransferenciaConSaldoSuficiente()
    {
        var dashboardPage = new DashboardPage(Page);
        var transferenciasPage = new TransferenciasPage(Page);

        // Paso 1: acceder a transferencias
        await dashboardPage.IrATransferenciasAsync();

        // Pasos 2-4: cuenta destino, monto y presionar "Transferir" (abre el modal)
        await transferenciasPage.RealizarTransferenciaAsync("ACC002", "100");

        // Evidencia: modal de confirmación
        await Expect(transferenciasPage.Modal).ToBeVisibleAsync();
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "capturas/CP04-modal-confirmacion.png",
            FullPage = true
        });

        // Confirmar en el modal
        await transferenciasPage.ConfirmarModalAsync();

        // Evidencia: resultado final
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "capturas/CP04-transferencia-exitosa.png",
            FullPage = true
        });

        // Resultado esperado: transferencia realizada exitosamente
        await Expect(transferenciasPage.ToastExito).ToBeVisibleAsync();
    }
}