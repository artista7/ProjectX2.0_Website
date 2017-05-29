using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Project_X_2._0.Models.ExtensionMethods
{
    public static class LinkExtensions
    {

        public static MvcHtmlString If(this MvcHtmlString value, bool evaluation, MvcHtmlString falseValue = default(MvcHtmlString))
        {
            return evaluation ? value : falseValue;
        }
    }
}