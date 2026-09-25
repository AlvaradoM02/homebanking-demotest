using Microsoft.Playwright;

namespace HomeBankingDemoTest.Pages;

public class TransferenciasPage
{
    private readonly IPage _page;

    public TransferenciasPage(IPage page)
    {
        _page = page;
    }

    public async Task RealizarTransferenciaAsync(string cuentaDestino, string monto)
    {
        await _page.Locator("#destination-own-account").SelectOptionAsync(cuentaDestino);
        await _page.Locator("#transfer-amount").FillAsync(monto);
        await _page.GetByRole(AriaRole.Button, new() { Name = "Transferir" }).ClickAsync();
    }

    public ILocator Modal => _page.Locator("#modal");
    public ILocator ToastExito => _page.Locator(".toast.success");

    public async Task ConfirmarModalAsync()
    {
        await _page.Locator("#modal-confirm").ClickAsync();
    }
}