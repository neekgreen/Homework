namespace WebHost.Conventions.Html
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using HtmlTags;
    using HtmlTags.Conventions;
    using HtmlTags.Reflection;

    public class FormHtmlConventions : HtmlConventionRegistry
    {
        public FormHtmlConventions()
        {
            SetDateTimeHtmlConventions();
            SetLabelHtmlCoonventions();
            SetHiddenHtmlConventions();
            SetEmailHtmlConventions();
            SetNumberHtmlConventions();
            SetTelephoneHtmlConventions();
        }

        private void SetDateTimeHtmlConventions()
        {
            Editors.IfPropertyIs<DateTime?>()
                .ModifyWith(m => m.CurrentTag
                    .AddPattern("9{1,2}/9{1,2}/9999")
                    .AddClass("calendar")
                    .AddPlaceholder("MM/DD/YYYY")
                    .Value(m.Value<DateTime?>() != null ? m.Value<DateTime>().ToShortDateString() : string.Empty));

            Displays.IfPropertyIs<DateTime?>()
                .ModifyWith(m => m.CurrentTag.Text(m.Value<DateTime?>() == null ? null : m.Value<DateTime?>().Value.ToShortDateString()));
        }

        private void SetHiddenHtmlConventions()
        {
            Editors.IfPropertyIs<Guid>().Attr("type", "hidden");
            Editors.IfPropertyIs<Guid?>().Attr("type", "hidden");
            Editors.IfPropertyHasAttribute<HiddenInputAttribute>().Attr("type", "hidden");

            Editors.If(er => er.Accessor.Name.EndsWith("id", StringComparison.OrdinalIgnoreCase))
                .BuildBy(a => new HiddenTag().Value(a.StringValue()));
        }

        private void SetLabelHtmlCoonventions()
        {
            Labels.ModifyForAttribute<RequiredAttribute>((t, a) =>
                { 
                    t.Attr("required");
                    t.AddClass("required");
                });

            Labels.ModifyForAttribute<DisplayAttribute>((t, a) => t.Text(a.Name));

            Labels.IfPropertyIs<bool>()
                .ModifyWith(er => er.CurrentTag.Text(er.OriginalTag.Text() + "?"));
        }

        private void SetEmailHtmlConventions()
        {
            Editors.If(er =>
                er.Accessor.Name.Contains("Email"))
                .ModifyWith(t=> t.CurrentTag.AddClass("email").Attr("type", "email"));
        }

        private void SetNumberHtmlConventions()
        {
            Editors.IfPropertyIs<decimal?>()
                .ModifyWith(m =>
                    m.CurrentTag
                        .Data("pattern", "9{1,9}.99")
                        .Data("placeholder", "0.00"));

            Displays.IfPropertyIs<decimal>().ModifyWith(m => m.CurrentTag.Text(m.Value<decimal>().ToString("C")));
        }

        private void SetTelephoneHtmlConventions()
        {
            Editors.If(er =>
                er.Accessor.Name.Contains("Phone"))
                    .ModifyWith(t=> t.CurrentTag.AddClass("phone").Attr("type", "tel"));
                    //.Attr("type", "tel");

            Editors.If(er =>
            {
                var attr = er.Accessor.GetAttribute<DataTypeAttribute>();
                return attr != null && attr.DataType == DataType.PhoneNumber;
            }).ModifyWith(t=> t.CurrentTag.AddClass("phone").Attr("type", "tel"));
        }
    }
}