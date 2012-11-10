<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HomeIndexModel>" %>

<%@ Import Namespace="GreatApp.Infrastructure.Models" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal ID="L1" runat="server" Text="<%$ Trans:GUI.HomePage.Title %>" />
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MetaContent" runat="server">
    <% base.Html.RenderPartial("PageMetaUserControl", base.Model.PageMeta); %>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="MainContent" runat="server">
    <%  
        Func<ContentItemModel, string> NameColumnGenerator = (x =>
        {
            return base.Html.ActionLink(x.Name, "Details", "Home", new { id = x.Id.ToString() }, null).ToHtmlString();
        });
        Func<ContentItemModel, string> NameColumnGeneratorWithTitle = (x =>
        {
            return base.Html.ActionLink(x.Name, "Details", "Home", new { id = x.Id.ToString() }, new { title = x.Description }).ToHtmlString();
        });
        Func<ContentItemModel, string> DateColumnGenerator = (x =>
        {
            return base.Html.DateModification(x).ToHtmlString();
        });
    %>
    <div class="ym-col1">
        <div class="ym-cbox">
            <section class="ym-grid linearize-level-2">
                <%= RepeaterAssistant.Create<ContentItemModel>("home_content_items").EnableHeader(false)
                                .AddEntities(base.Model.NewItems.ToList())
                                .AddColumns("Name").AddGenerator("Name", NameColumnGenerator)
                                .AddColumns("Date").AddGenerator("Date", DateColumnGenerator)
                                .AddColumns("Description")
                                .GenerateHtml()
                %>
            </section>
        </div>
    </div>
    <aside class="ym-col3">
        <div class="ym-cbox">
            <h4>
                <%: base.Html.Translate("GUI.DetailsPage.FocusTitle")%>
            </h4>
            <div class="ym-contain-dt site-nbg">
                <%= RepeaterAssistant.Create<ContentItemModel>("focus_items").AddEntities(base.Model.FocusItems).EnableHeader(false)
                        .AddColumns("Name").AddGenerator("Name", NameColumnGeneratorWithTitle)
                        .AddColumns("Date").AddGenerator("Date", DateColumnGenerator)
                        .GenerateHtml()
                %>
            </div>
        </div>
    </aside>
    <script type="text/javascript">
        $(document).ready(function () {
            $('div[name=home_content_items] div[name=body]').addClass('rpt_body');
            $('div[name=home_content_items] div[name=body] div[name=line]').addClass('rpt_body_line');
            //            $('div[name=home_content_items] div[name=body] div[name=line]:even').addClass('rpt_body_line_even_none');
            //            $('div[name=home_content_items] div[name=body] div[name=line]:odd').addClass('rpt_body_line_odd_none');
            $('div[name=home_content_items] div[name=body] div[name=line] div[name=Name]').addClass('rpt_body_cell_home_name');
            $('div[name=home_content_items] div[name=body] div[name=line] div[name=Description]').addClass('rpt_body_cell_home_desc');

            $('div[name=focus_items] div[name=body]').addClass('rpt_body');
            $('div[name=focus_items] div[name=body] div[name=line]').addClass('rpt_body_line');
            $('div[name=focus_items] div[name=body] div[name=line]:even').addClass('rpt_body_line_even_none_focus');
            $('div[name=focus_items] div[name=body] div[name=line]:odd').addClass('rpt_body_line_odd_none_focus');
            $('div[name=focus_items] div[name=body] div[name=line] div[name=Name]').addClass('rpt_body_cell_focus_name_focus');
        });
    </script>
</asp:Content>
