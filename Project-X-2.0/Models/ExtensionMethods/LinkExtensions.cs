using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Project_X_2._0.Models.ExtensionMethods
{
    public static class LinkExtensions
    {
        public static IHtmlString ActionLinkIfInRole(
            this HtmlHelper htmlhelper,
            string roles,
            string linkText,
            string action,
            string controller,
            object routeValues,
            object htmlAttributes)
        {
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            if (!System.Web.Security.Roles.IsUserInRole(roles))
            {
                return MvcHtmlString.Empty;
            }
            return htmlhelper.ActionLink(linkText, action, controller, routeValues, htmlAttributes);
        }
    }
}