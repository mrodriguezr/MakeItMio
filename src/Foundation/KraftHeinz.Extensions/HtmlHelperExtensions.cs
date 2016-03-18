using System.Web;
using Sitecore.Data.Items;
using Sitecore.Mvc.Helpers;

namespace KraftHeinz.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString ImageField(this SitecoreHelper helper, string fieldName, Item item, int mh = 0, int mw = 0, string cssClass = null, bool disableWebEditing = false)
        {
            return helper.Field(fieldName, item, new
            {
                mh,
                mw,
                DisableWebEdit = disableWebEditing,
                @class = cssClass ?? ""
            });
        }
    }
}
