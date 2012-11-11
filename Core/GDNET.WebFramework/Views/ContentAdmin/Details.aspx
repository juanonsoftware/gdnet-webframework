<%@ Page Language="C#" MasterPageFile="~/Views/Shared/SiteAdmin.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemModel>" %>

<%@ Import Namespace="GreatApp.Infrastructure.Models" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate("GUI.ContentAdmin.DetailsPage.Title", base.Model.Name) %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="block">
        <div class="block-content">
            <h2>
                <%= base.Model.Name %>
            </h2>
        </div>
        <div class="actions-container">
            <%: base.Html.ActionLinkTrans("GUI.Common.Actions.View", "Details", "Home", new { id = base.Model.Id })%>
            <%: base.Html.ActionLinkTrans("GUI.Common.Actions.Edit", "Edit", new { id = base.Model.Id })%>
            <%: base.Html.ActionLinkTrans("GUI.ContentAdmin.Details.CreatePart", "CreatePart", new { id = base.Model.Id })%>
        </div>
    </div>
    <div class="block">
        <p>
            <%= base.Model.Description %>
        </p>
        <%
            Func<ContentPartModel, string> GenerateActions = (x =>
            {
                string editPart = base.Html.ActionLinkTrans("GUI.Common.Actions.Edit", "EditPart", new { id = x.Id, cid = base.Model.Id }).ToHtmlString();
                string upPart = base.Html.ActionLink("Up", "MoveUpPart", new { id = x.Id, cid = base.Model.Id }).ToHtmlString();
                string downPart = base.Html.ActionLink("Down", "MoveDownPart", new { id = x.Id, cid = base.Model.Id }).ToHtmlString();
                string deletePart = base.Html.ActionLinkConfirmation("GUI.Common.Actions.Delete", "GUI.Common.Actions.Delete.Confirmation", "DeletePart", new { id = x.Id, cid = base.Model.Id }).ToHtmlString();
                return string.Concat(editPart, " ", upPart, " ", downPart, " ", deletePart);
            });

            var repeater = RepeaterAssistant.Create<ContentPartModel>("item_parts").EnableHeader(true).AddEntities(base.Model.Parts);
            repeater.AddColumns("Name", "Actions");
            repeater.AddGenerator("Actions", GenerateActions);
        %>
        <div>
            <%= repeater.GenerateHtml() %>
            <div style="clear: both;">
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('div[name=item_parts]').addClass('rpt');
            $('div[name=item_parts] div[name=header]').addClass('rpt_header');
            $('div[name=item_parts] div[name=header] div').addClass('rpt_header_cell');

            $('div[name=item_parts] div[name=body]').addClass('rpt_body');
            $('div[name=item_parts] div[name=body] div[name=line]').addClass('rpt_body_line');
            $('div[name=item_parts] div[name=body] div[name=line]:even').addClass('rpt_body_line_even');
            $('div[name=item_parts] div[name=body] div[name=line]:odd').addClass('rpt_body_line_odd');
            $('div[name=item_parts] div[name=body] div[name=line] div').addClass('rpt_body_cell');
        });
    </script>
</asp:Content>
