using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCB.Components.Services.Shared
{
    public static class MenuHelper
    {
        public static List<MenuItem> BuildTree(List<MenuItem> flatList, bool sort = false)
        {
            var listToProcess = sort
                ? flatList.OrderBy(m => m.Label, StringComparer.OrdinalIgnoreCase).ToList()
                : new List<MenuItem>(flatList);

            var lookup = listToProcess.ToDictionary(item => item.Id);
            var roots = new List<MenuItem>();

            foreach (var item in listToProcess)
            {
                if (item.ParentId.HasValue && lookup.ContainsKey(item.ParentId.Value))
                {
                    lookup[item.ParentId.Value].Children.Add(item);
                }
                else
                {
                    roots.Add(item);
                }
            }

            if (sort)
                SortChildren(roots);

            return roots;
        }

        private static void SortChildren(List<MenuItem> nodes)
        {
            nodes.Sort((a, b) => string.Compare(a.Label, b.Label, StringComparison.OrdinalIgnoreCase));

            foreach (var node in nodes)
            {
                if (node.Children.Any())
                {
                    SortChildren(node.Children);
                }
            }
        }
    }
}
