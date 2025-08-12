using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCB.Components.Services.WCBModal
{
    public class WCBModalService
    {
        // Event dat wordt geactiveerd wanneer een modal getoond moet worden.
        public event Action<WCBModalOptions>? OnShow;

        // Event dat wordt geactiveerd wanneer een modal verborgen moet worden.
        public event Action? OnHide;

        /// <summary>
        /// Toont een nieuwe modal met de opgegeven opties.
        /// </summary>
        /// <param name="options">De opties voor de modal, inclusief titel, inhoud en ID.</param>
        public void Show(WCBModalOptions options)
        {
            OnShow?.Invoke(options);
        }

        /// <summary>
        /// Verbergt de momenteel getoonde modal.
        /// </summary>
        public void Hide()
        {
            OnHide?.Invoke();
        }
    }

}
