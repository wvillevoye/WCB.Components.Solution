using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCB.Components.Services.WCBOffcanvas
{
    public class WCBOffcanvasOptions
    {
        public string Title { get; set; } = string.Empty;
        public RenderFragment BodyContent { get; set; } = (builder) => { };
        public WCBOffcanvasPosition Position { get; set; } = WCBOffcanvasPosition.Start;
        public WCBOffcanvasSize Size { get; set; } = WCBOffcanvasSize.Default;
    }
}
