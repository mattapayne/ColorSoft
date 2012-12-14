using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ColorSoft.Web.Lib;

namespace ColorSoft.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        private const string EmptyJavascriptHash = "{ }";

        public static bool HasMessages(this HtmlHelper helper)
        {
            var messageGroups = helper.GetMessages();
            return messageGroups != null && messageGroups.Any();
        }

        public static IHtmlString RenderMessages(this HtmlHelper helper)
        {
            var messageGroups = helper.GetMessages();

            if(messageGroups.Any())
            {
                var sb = new StringBuilder();

                foreach(var messageGroup in messageGroups)
                {
                    var divTag = new TagBuilder("div");
                    divTag.AddCssClass("alert");
                    divTag.AddCssClass(TranslateMessageTypeToAlertClass(messageGroup.Key));

                    sb.AppendLine(divTag.ToString(TagRenderMode.StartTag));

                    var closeButtonTag = new TagBuilder("button") { InnerHtml = "x" };
                    closeButtonTag.Attributes.Add("type", "button");
                    closeButtonTag.AddCssClass("close");
                    closeButtonTag.Attributes.Add("data-dismiss", "alert");

                    sb.AppendLine(closeButtonTag.ToString(TagRenderMode.Normal));

                    var h4Tag = new TagBuilder("h4") {InnerHtml = TranslatemessageTypeToAlertTitle(messageGroup.Key)};

                    sb.AppendLine(h4Tag.ToString(TagRenderMode.Normal));

                    var ulTag = new TagBuilder("ul");

                    sb.AppendLine(ulTag.ToString(TagRenderMode.StartTag));

                    var groupMessages = messageGroup.SelectMany(x => x.Messages).Distinct();

                    foreach (var groupMessage in groupMessages)
                    {
                        var liTag = new TagBuilder("li") {InnerHtml = groupMessage};

                        sb.AppendLine(liTag.ToString(TagRenderMode.Normal));
                    }

                    sb.AppendLine(ulTag.ToString(TagRenderMode.EndTag));
                    sb.AppendLine(divTag.ToString(TagRenderMode.EndTag));
                }

                return MvcHtmlString.Create(sb.ToString());
            }

            return MvcHtmlString.Empty;
        }

        private static IGrouping<MessageType, MessageCollection>[] GetMessages(this HtmlHelper helper)
        {
            var viewDataMessages = helper.ViewData.Where(x => x.Key == MessageCollection.MessagesKey).Select(x => x.Value as MessageCollection);
            var tempDataMessages = helper.ViewContext.TempData.Where(x => x.Key == MessageCollection.MessagesKey).Select(x => x.Value as MessageCollection);
            var messages = viewDataMessages.Concat(tempDataMessages).Where(x => x != null).GroupBy(x => x.Type);

            return messages as IGrouping<MessageType, MessageCollection>[] ?? messages.ToArray();
        }

        private static string TranslatemessageTypeToAlertTitle(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Success:
                    return "Success!";
                case MessageType.Information:
                    return "Information";
                case MessageType.Warning:
                    return "Warning!";
                case MessageType.Error:
                    return "Error!";
            }

            return String.Empty;
        }

        private static string TranslateMessageTypeToAlertClass(MessageType messageType)
        {
            switch(messageType)
            {
                case MessageType.Success:
                    return "alert-success";
                case MessageType.Information:
                    return "alert-info";
                case MessageType.Warning:
                    return "alert";
                case MessageType.Error:
                    return "alert-error";
            }

            return String.Empty;
        }

        public static IHtmlString BootstrapValidationSummary(this HtmlHelper helper, string text)
        {
            if(helper.ViewData.ModelState.IsValid)
            {
                return MvcHtmlString.Empty;
            }

            var validationHtml = new StringBuilder(String.Format("<h4>Whoops!</h4>{0}<ul>", text));

            foreach(var error in helper.ViewData.ModelState.Where(ms => ms.Value.Errors.Any()))
            {
                foreach(var modelError in error.Value.Errors)
                {
                    validationHtml.AppendLine(
                        String.Format(
                            "<li class='validation-error-indicator' data-invalid-field='{0}' title='Click to locate the error'>{1}</li>",
                            error.Key, modelError.ErrorMessage));
                }
            }

            validationHtml.AppendLine("</ul>");

            var html = String.Format(@"<div class='alert alert-block alert-error'>
                            <button type='button' class='close' data-dismiss='alert'>x</button>
                            {0}
            </div>", validationHtml);
            return MvcHtmlString.Create(html);
        }

        public static IHtmlString RenderColorSoftApplication(this HtmlHelper helper)
        {
            return
                new[] {helper.RegisterColorSoftApplicationUrls(), Scripts.Render("~/scripts/applications/colorsoft")}.
                    Concat();
        }

        public static IHtmlString RenderMessagingApplication(this HtmlHelper helper)
        {
            return
                new[] { helper.RegisterMessagingApplicationUrls(), Scripts.Render("~/scripts/applications/messaging") }.
                    Concat();
        }

        public static IHtmlString CommonJsSetup(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"
                    <script type='text/javascript'>
                        window.ColorSoft = window.ColorSoft || {};
                        window.ColorSoft.TopNavigation = window.ColorSoft.TopNavigation || {};
                        window.ColorSoft.TopNavigation.SelectedMenuItem = '<SELECTED_NAVIGATION_ITEM>';
                    </script>".
                                            Replace("<SELECTED_NAVIGATION_ITEM>", helper.ViewBag.SelectedNavigationItem));
        }

        private static IHtmlString Concat(this IEnumerable<IHtmlString> items)
        {
            var sb = new StringBuilder();

            foreach (IHtmlString item in items.Where(i => i != null && !String.IsNullOrEmpty(i.ToHtmlString())))
            {
                sb.Append(item.ToHtmlString());
            }

            return MvcHtmlString.Create(sb.ToString());
        }

        private static UrlHelper CreateUrlHelper(this HtmlHelper helper)
        {
            return new UrlHelper(helper.ViewContext.RequestContext);
        }

        private static IHtmlString RegisterApplicationUrls(string appName, object urls)
        {
            string script = @"<script type='text/javascript'>
                                window.<APP_NAME> = window.<APP_NAME> || {};
                                window.<APP_NAME>.Urls = <URLS>;
                           </script>".
                Replace("<APP_NAME>", appName).
                Replace("<URLS>", GetUrls(urls));

            return MvcHtmlString.Create(script);
        }

        private static IHtmlString RegisterColorSoftApplicationUrls(this HtmlHelper helper)
        {
            var url = helper.CreateUrlHelper();

            return RegisterApplicationUrls("ColorSoft", new
                {
                    ListUsers = url.Action("", "Api/Users"),
                    ListMessages = url.Action("", "Api/Messages"),
                    DeleteMessage = url.Action("Delete", "Api/Messages"),
                    DeleteMessages = url.Action("DeleteAll", "Api/Messages"),
                    DeleteUser = url.Action("Delete", "Api/Users"),
                    DeleteUsers = url.Action("DeleteAll", "Apit/Users")
                });
        }

        private static IHtmlString RegisterMessagingApplicationUrls(this HtmlHelper helper)
        {
            var url = helper.CreateUrlHelper();

            return RegisterApplicationUrls("Messaging", new
            {

            });
        }

        private static string GetUrls(object urls)
        {
            if (urls == null)
            {
                return EmptyJavascriptHash;
            }
            var dictionary = new RouteValueDictionary(urls);

            var entries =
                dictionary.Where(entry => !String.IsNullOrEmpty(entry.Key) && entry.Value != null).Select(
                    entry => new
                        {
                            UrlName = entry.Key.Trim(),
                            Url = entry.Value.ToString().Trim()
                        });

            if (!entries.Any())
            {
                return EmptyJavascriptHash;
            }

            return "{ " + String.Join(", ", entries.Select(e => String.Format("{0}: '{1}'", e.UrlName, e.Url))) + " }";
        }
    }
}