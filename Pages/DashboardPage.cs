using Microsoft.Playwright;

namespace HomeBankingDemoTest.Pages;

public class DashboardPage
{
    private readonly IPage _page;

    public DashboardPage(IPage page)
    {
        _page = page;
    }

    public ILocator NombreUsuario => _page.GetByText("Juan Pérez");

    private ILocator CuentaCorriente =>
        _page.Locator(".account-card").Filter(new() { HasText = "Cuenta Corriente" });

    public ILocator EtiquetaSaldoDisponibleCuentaCorriente => CuentaCorriente.GetByText("Saldo disponible");
    public ILocator MontoSaldoCuentaCorriente => CuentaCorriente.Locator(".balance-amount");
    public ILocator BotonOjoCuentaCorriente => CuentaCorriente.Locator(".toggle-balance");

    public async Task IrATransferenciasAsync()
    {
        await _page.Locator("li[data-view='transfer']").ClickAsync();
    }
}