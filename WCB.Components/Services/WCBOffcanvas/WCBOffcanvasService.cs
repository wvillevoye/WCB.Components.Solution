using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCB.Components.Services.WCBOffcanvas
{
    /// <summary>
    /// Service voor het beheren van de offcanvas-componenten.
    /// </summary>
    public class WCBOffcanvasService
    {
        // Event dat wordt geactiveerd wanneer een offcanvas moet worden getoond
        public event Func<WCBOffcanvasOptions, Task>? OnShow;

        /// <summary>
        /// Toont een nieuwe offcanvas-component met de opgegeven opties.
        /// </summary>
        /// <param name="options">De opties voor de offcanvas.</param>
        public async Task ShowOffcanvas(WCBOffcanvasOptions options)
        {
            if (OnShow != null)
            {
                await OnShow.Invoke(options);
            }
        }
    }
}
