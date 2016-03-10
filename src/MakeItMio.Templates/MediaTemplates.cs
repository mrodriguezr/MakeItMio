using System;
using Sitecore.Data;

namespace MakeItMio.Templates
{
    public struct MediaTemplates
    {
        public struct HasMedia
        {
            public static readonly ID ID = new ID("{D1C46BBC-E086-4B4B-8066-CD41B16B1BF0}");

            public struct Fields
            {
                public static readonly ID Title = new ID("{DDE4D0EF-2763-4D11-A8EC-356E87FEED26}");
                public static readonly ID Image = new ID("{63ABB450-8F5E-441E-9349-797892FC2097}");
                public static readonly ID Destination = new ID("{17CB820D-307B-4B86-80FF-66B7C6033CE8}");
            }
        }

        public struct HasMediaDescription
        {
            public static readonly ID ID = new ID("{7C05004F-737F-4AF3-B444-D4F25978AF3C}");

            public struct Fields
            {
                public static readonly ID Description = new ID("{38C642A8-4519-4923-AFA5-75850EB2836A}");
            }
        }

        public struct HasMediaDestination
        {
            public static readonly ID ID = new ID("{2A813C2F-7E6F-4E6C-AF3C-BCC412279AFB}");

            public struct Fields
            {
                public static readonly ID Destination = new ID("{7D9E634D-69E6-420C-883B-039FF37B2BC9}");
            }
        }
    }
}
