using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCB.Components.Services.Shared;

namespace WCB.Components.Services.WCBPagination
{
    public class WCBApiPaginationService
    {

        public string? FirstLink { get; private set; }
        public string? PrevLink { get; private set; }
        public string? NextLink { get; private set; }
        public string? LastLink { get; private set; }

        public bool HasFirst => !string.IsNullOrEmpty(FirstLink);
        public bool HasPrev => !string.IsNullOrEmpty(PrevLink);
        public bool HasNext => !string.IsNullOrEmpty(NextLink);
        public bool HasLast => !string.IsNullOrEmpty(LastLink);

        public void UpdateLinks(LinkHeader links)
        {
            FirstLink = links.FirstLink;
            PrevLink = links.PrevLink;
            NextLink = links.NextLink;
            LastLink = links.LastLink;
        }

        public string? GetFirst() => FirstLink;
        public string? GetPrev() => PrevLink;
        public string? GetNext() => NextLink;
        public string? GetLast() => LastLink;
    }
}