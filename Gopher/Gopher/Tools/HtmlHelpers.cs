using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc.Html;
using Gopher.Model.Tools;
using Gopher.Tools;

namespace System.Web.Mvc
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Translation(this HtmlHelper helper, string labelName)
        {
            var text = TranslationHelper.GetTranslation(labelName).Text;
            return new MvcHtmlString(text);
        }

        public static MvcHtmlString RadioButtonList<TModel, TEnum>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TEnum>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            var list = GetEnumValues<TEnum>();

            return new MvcHtmlString("");
        }

        private static object GetEnumValues<T>()
        {
            var t = typeof(T);
            var u = Nullable.GetUnderlyingType(t);
            if (u != null && u.IsEnum)
                return Enum.GetValues(u);
            if (t.IsEnum)
                return Enum.GetValues(u);
            return new List<object>();
        }

        private static bool IsNullableEnum(this Type t)
        {
            Type u = Nullable.GetUnderlyingType(t);
            return (u != null) && u.IsEnum;
        }

        
        public static MvcHtmlString DatePicker<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            var tb = new TagBuilder("input");
            tb.Attributes["class"] = "date-picker";
            tb.Attributes["type"] = "text";
            tb.Attributes["name"] = name;
            string value = string.Empty;
            if (metadata.ModelType == typeof(DateTime))
            {
                DateTime dt = (DateTime)metadata.Model;
                if (dt != DateTime.MinValue)
                    value = dt.ToString(GopherConfiguration.DateTimeFormat);
            }
            else if (Nullable.GetUnderlyingType(metadata.ModelType) == typeof(DateTime))
            {
                DateTime? dt = (DateTime?)metadata.Model;
                if (dt != null)
                    value = dt.Value.ToString(GopherConfiguration.DateTimeFormat);
            }
            tb.Attributes["value"] = value;
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}