<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteAdmin.Master" Inherits="System.Web.Mvc.ViewPage<IList<ContentItemModel>>" %>

<%@ Import Namespace="GDNET.WebInfrastructure.Models.Content" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal ID="L1" runat="server" Text="<%$ Trans:GUI.ContentAdmin.List.Title %>" />
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>
        <asp:Literal ID="L2" runat="server" Text="<%$ Trans:GUI.ContentAdmin.List.Heading %>" />
    </h4>
    <p>
        <%: base.Html.ActionLinkTrans("GUI.Account.Details.AddContent", "Create", "ContentAdmin")%>
    </p>
    <div>
        <%
            Func<ContentItemModel, string> NameGenerator = (x =>
            {
                return base.Html.ActionLink(x.Name, "Details", new { id = x.Id }, new { title = x.Description }).ToHtmlString();
            });
            Func<ContentItemModel, string> ActionsGenerator = (x =>
            {
                string editLink = base.Html.ActionLink("Edit", "Edit", new { id = x.Id }).ToHtmlString();
                string viewLink = base.Html.ActionLink("Details", "Details", new { id = x.Id }).ToHtmlString();
                string deleteLink = base.Html.ActionLinkConfirmation("GUI.Common.Actions.Delete", "GUI.Common.Actions.Delete.Confirmation", "Delete", new { id = x.Id }).ToHtmlString();
                return string.Concat(editLink, " ", viewLink, " ", deleteLink);
            });
        %>
        <%= RepeaterAssistant.Create<ContentItemModel>("content_items").EnableHeader(true).AddEntities(base.Model.ToList())
                                .AddColumnWithText("Name", "GUI.ContentAdmin.List.ColumnName")
                                .AddColumnWithText("Keywords", "GUI.ContentAdmin.List.ColumnKeywords")
                                .AddColumn("Actions")
                                .AddGenerator("Name", NameGenerator).AddGenerator("Actions", ActionsGenerator).GenerateHtml()
        %>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('div[name=content_items]').addClass('rpt');
            $('div[name=content_items] div[name=header]').addClass('rpt_header');
            $('div[name=content_items] div[name=header] div').addClass('rpt_header_cell');

            $('div[name=content_items] div[name=body]').addClass('rpt_body');
            $('div[name=content_items] div[name=body] div[name=line]').addClass('rpt_body_line');
            $('div[name=content_items] div[name=body] div[name=line]:even').addClass('rpt_body_line_even');
            $('div[name=content_items] div[name=body] div[name=line]:odd').addClass('rpt_body_line_odd');
            $('div[name=content_items] div[name=body] div[name=line] div').addClass('rpt_body_cell');
        });
    </script>
</asp:Content>
