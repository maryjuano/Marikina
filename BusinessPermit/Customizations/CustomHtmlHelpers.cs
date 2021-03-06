﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace BusinessPermit
{
    public static class CustomHtmlHelpers
    {
        public static System.Web.Mvc.SelectList ToSelectList<TEnum>(this TEnum obj)
          where TEnum : struct, IComparable, IFormattable, IConvertible
        {

            return new SelectList(Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                .Select(x =>
                    new SelectListItem
                    {
                        Text =  x.GetEnumDescription(),
                        Value = (Convert.ToInt32(x)).ToString()
                    }), "Value", "Text");
        }

        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static IHtmlString DisplayForBoolean(this HtmlHelper html, bool value)
        {
            string htmlString = String.Format("<span class='fa fa-flag fa-fw text-success'></span>");

            if (!value)
            {
                htmlString = String.Format("<span class='fa fa-flag fa-fw text-danger'></span>");
            }
            return new HtmlString(htmlString);
        }

        public static IHtmlString DisplayForCurrency(this HtmlHelper html, float value)
        {
            string htmlString = String.Format("P{0}", value);
            return new HtmlString(htmlString);
        }

        public static IHtmlString DisplayForCheckbox(this HtmlHelper html, bool value)
        {
            string htmlString = String.Format("<span class='fa fa-check fa-fw text-success'></span>");

            if (!value)
            {
                htmlString = String.Format("<span class='fa fa-remove fa-fw text-danger'></span>");
            }
            return new HtmlString(htmlString);
        }

        public static IHtmlString DeleteAction(this HtmlHelper html, string controller, string action, int id)
        {
            return new HtmlString(String.Format("<a class='text-red' href='/{0}/{1}/{2}'><span class='fa fa-trash'></span></a>", controller, action, id));
        }

        public static IHtmlString LinkWithIcon(this HtmlHelper html, string controller, string action, int id, string classIcon)
        {
            return new HtmlString(String.Format("<a href='/{0}/{1}/{2}'><span class='{3}'></span></a>", controller, action, id, classIcon));
        }

        public static void ActionLinkWithBootstrap(this AjaxHelper ajaxHelper, string linkText, string actionName, AjaxOptions ajaxOptions)
        {

        }
    }
}