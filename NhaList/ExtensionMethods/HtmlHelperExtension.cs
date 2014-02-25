using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace NhaList.ExtensionMethods
{
    public static class HtmlHelperExtension
    {
        public static IHtmlString CssFor(this HtmlHelper html, string path)
        {
            return Styles.Render(AppendVersionTo(path));
        }

        public static string AppendVersionTo(string path)
        {
            var appender = ObjectFactory.Resolve<IVersionAppender>();
            return appender.Append(path);
        }

        public static IHtmlString JsFor(this HtmlHelper html, string path)
        {
            return Scripts.Render(AppendVersionTo(path));
        }
    }
}