using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCB.Components.Services.Shared
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }

        public string Label { get; set; } = "";
        public string IconClass { get; set; } = "";
        public string Href { get; set; } = "";
        public List<MenuItem> Children { get; set; } = new();
    }
}
