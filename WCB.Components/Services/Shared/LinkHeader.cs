using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WCB.Components.Services.Shared
{
    public class LinkHeader
    {
        public string? FirstLink { get; set; }
        public string? PrevLink { get; set; }
        public string? NextLink { get; set; }
        public string? LastLink { get; set; }

        public static LinkHeader FromHeader(string? header)
        {
            var linkHeader = new LinkHeader();
            if (string.IsNullOrWhiteSpace(header)) return linkHeader;

            var linkStrings = header.Split(',');

            foreach (var linkString in linkStrings)
            {
                var relMatch = Regex.Match(linkString, @"(?<=rel="").+?(?="")", RegexOptions.IgnoreCase);
                var linkMatch = Regex.Match(linkString, @"(?<=<).+?(?=>)", RegexOptions.IgnoreCase);

                if (relMatch.Success && linkMatch.Success)
                {
                    var rel = relMatch.Value.ToUpper();
                    var link = linkMatch.Value;

                    switch (rel)
                    {
                        case "FIRST":
                            linkHeader.FirstLink = link;
                            break;
                        case "PREV":
                            linkHeader.PrevLink = link;
                            break;
                        case "NEXT":
                            linkHeader.NextLink = link;
                            break;
                        case "LAST":
                            linkHeader.LastLink = link;
                            break;
                    }
                }
            }

            return linkHeader;
        }
    }

}
