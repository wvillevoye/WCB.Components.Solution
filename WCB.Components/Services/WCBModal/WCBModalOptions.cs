using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCB.Components.Services.WCBModal
{
    public class WCBModalOptions
    {
        public string Title { get; set; } = "Modal Titel";
        public RenderFragment? BodyContent { get; set; }
        public string Size { get; set; } = "modal-md"; // Standaard middelgroot
    }
}
