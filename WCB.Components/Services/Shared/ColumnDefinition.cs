using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace WCB.Components.Services.Shared
{
    public class ColumnDefinition<TItem>
    {
        public string Header { get; set; } = string.Empty;
        public RenderFragment<TItem> CellTemplate { get; set; } = default!;
        public Func<TItem, object>? SortKeySelector { get; set; }
    }

    public static class ColumnBuilder
    {
        public static ColumnDefinition<TItem> CreateColumn<TItem, TValue>(
            string header,
            Func<TItem, TValue> valueSelector,
            bool sortable = true)
        {
            return new ColumnDefinition<TItem>
            {
                Header = header,
                CellTemplate = item => builder =>
                {
                    builder.AddContent(0, valueSelector(item)?.ToString());
                },
                SortKeySelector = sortable ? item => valueSelector(item) : null
            };
        }
    }
}
