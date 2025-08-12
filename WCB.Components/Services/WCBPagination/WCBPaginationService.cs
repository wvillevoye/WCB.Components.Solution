using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCB.Components.Services.WCBPagination
{
    public class WCBPaginationService
    {
        public event Action<string, int>? OnPageChanged;

        public void SetPage(string listId, int page)
        {
            OnPageChanged?.Invoke(listId, page);
        }
    }
}
