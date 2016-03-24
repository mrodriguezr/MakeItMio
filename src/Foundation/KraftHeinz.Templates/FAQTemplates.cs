using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraftHeinz.Templates
{
    public struct FAQTemplates
    {
        public struct FAQ
        {
            public static readonly ID ID = new ID("{2342085A-97A3-4769-9333-6DCE5E681846}");

            public struct Fields
            {
                public static readonly ID Title = new ID("{0B12A7FD-C330-4B12-83DB-BA920430ABCB}");
                public static readonly ID Description = new ID("{D4922322-68FF-4AAC-A70F-1014F3011F76}");
            }
        }

        public struct FAQTab
        {
            public static readonly ID ID = new ID("{0BEAC27E-9538-446E-97FE-00B73EB5927F}");

            public struct Fields
            {
                public static readonly ID TabName = new ID("{42B143C2-0EB1-4B24-9373-363434E31E49}");
            }
        }

        public struct FAQItem
        {
            public static readonly ID ID = new ID("{7C2A7E80-4ABA-45F0-BB5E-9E23672830A1}");

            public struct Fields
            {
                public static readonly ID Question = new ID("{7C2A7E80-4ABA-45F0-BB5E-9E23672830A1}");
                public static readonly ID Answer = new ID("{CD44CD06-3E23-42C1-B536-0C1AABCCF5A2}");
            }
        }
    }
}
