using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraftHeinz.Templates
{
    public struct NavigationTemplates
    {
        public struct NavigationRoot
        {
            public static readonly ID ID = new ID("{A193EC8A-4259-4D50-ACAA-0699C220665B}");
        }

        public struct Navigable
        {
            public static readonly ID ID = new ID("{A41B037F-767C-42B4-8952-43C3DC211E7A}");

            public struct Fields
            {
                public static readonly ID Title = new ID("{7E616172-68A8-4B2D-80E1-236A74B691CC}");
                public static readonly ID ShowInNavigation = new ID("{F6FEA62B-12B3-45F7-B203-C0BD55FFAB52}");
                public static readonly ID IsSecundary = new ID("{0D974F4F-C322-4015-8EAF-83B11EB29C9E}");
            }
        }

        public struct LinkMenuItem
        {
            public static readonly ID ID = new ID("{F08808F3-4A15-47A1-BBCB-1E54D84545E4}");

            public struct Fields
            {
                public static readonly ID Link = new ID("{4438399A-61DF-4B70-94AD-CCDD9CD2AAFD}");
                public static readonly ID Icon = new ID("{503230C6-167D-4534-B8DA-F91A981517FC}");
            }
        }

    }
}
