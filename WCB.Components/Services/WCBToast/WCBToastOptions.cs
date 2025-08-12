using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCB.Components.Services.Shared;

namespace WCB.Components.Services.WCBToast
{
    public class WCBToastOptions
    {
        public string Message { get; set; } = string.Empty;
        public string? Title { get; set; }
        public AlertType Type { get; set; } = AlertType.Info;
        public int Delay { get; set; } = 5000; // Vertraging in milliseconden
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now; // Nieuw: Tijdstempel van de toast
        public WCBToastPosition Position { get; set; } = WCBToastPosition.BottomRight; // Nieuw: Positie van de toast
        public string? IconClass { get; set; }
    }
}
