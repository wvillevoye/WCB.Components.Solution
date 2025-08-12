
using WCB.Components.Services.Shared;

namespace WCB.Components.Services.WCBToast;
public class WCBToastService
{
    // Event dat wordt geactiveerd wanneer een nieuwe toast moet worden getoond.
    public event Action<WCBToastOptions>? OnShow;

    // Event dat wordt geactiveerd wanneer alle toasts moeten worden verborgen.
    public event Action? OnClearAll;

    /// <summary>
    /// Toont een nieuwe toast-melding.
    /// </summary>
    /// <param name="message">De tekst van de toast.</param>
    /// <param name="title">De titel van de toast (optioneel).</param>
    /// <param name="type">Het type toast (bijv. Info, Success, Warning, Error).</param>
    /// <param name="delay">De vertraging in milliseconden voordat de toast verdwijnt (standaard 5000ms).</param>
    /// <param name="timestamp">De tijdstempel van de toast (standaard DateTimeOffset.Now).</param>
    /// <param name="position">De positie van de toast (standaard BottomRight).</param>
    // De 'iconClass' parameter is verwijderd, deze wordt nu automatisch bepaald.
    public void ShowToast(string message, string? title = null, AlertType type = AlertType.Info, int delay = 5000, DateTimeOffset? timestamp = null, WCBToastPosition position = WCBToastPosition.BottomRight)
    {
        try
        {
            OnShow?.Invoke(new WCBToastOptions
            {
                Message = message,
                Title = title,
                Type = type,
                Delay = delay,
                Timestamp = timestamp ?? DateTimeOffset.Now, // Gebruik huidige tijd als geen timestamp is opgegeven
                Position = position, // Stel de positie in
                IconClass = GetIconClassForToastType(type) // Icoonklasse wordt nu automatisch bepaald
            });
        }
        catch (Exception ex)
        {
            // Log de uitzondering of handel deze af zoals nodig.
            // Voor nu printen we het naar de console.
            Console.WriteLine($"Fout bij het tonen van toast: {ex.Message}");
            // Overweeg hier een extra foutmelding te tonen of te loggen naar een monitoringdienst.
        }
    }

    /// <summary>
    /// Verbergt alle actieve toast-meldingen.
    /// </summary>
    public void ClearAllToasts()
    {
        try
        {
            OnClearAll?.Invoke();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fout bij het wissen van alle toasts: {ex.Message}");
        }
    }

    /// <summary>
    /// Bepaalt de Bootstrap Icon klasse op basis van het ToastType.
    /// </summary>
    /// <param name="type">Het type toast.</param>
    /// <returns>De corresponderende Bootstrap Icon klasse string.</returns>
    private static string? GetIconClassForToastType(AlertType type)
    {
        return type switch
        {
            AlertType.Info => "bi bi-info-circle",
            AlertType.Success => "bi bi-check-circle-fill",
            AlertType.Warning => "bi bi-exclamation-triangle-fill",
            AlertType.Error => "bi bi-x-circle-fill",
            _ => null // Geen icoon voor onbekende types
        };
    }
}

