<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HomeDetailModel>" %>

<%@ Import Namespace="GreatApp.Infrastructure.Models" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate("GUI.DetailsPage.Title", base.Model.ItemModel.Name) %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MetaContent" runat="server">
    <% base.Html.RenderPartial("PageMetaUserControl", base.Model.PageMeta); %>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ym-col1">
        <div class="ym-cbox">
            <section class="box">
                <h4>
                    <%= base.Model.ItemModel.Name %>
                </h4>
                <div style="margin-top: 5px;">
                    <%= base.Html.DateModification(this.Model.ItemModel) %>
                </div>
                <p>
                    <%= base.Model.ItemModel.Description%>
                </p>
                <p>
                    <%= base.Model.ItemModel.Keywords%>
                </p>
            </section>
            <section class="ym-grid linearize-level-2">
                <%
                    Func<ContentPartModel, string> NameColumnGenerator = (x =>
                    {
                        return string.Format("<h4>{0}</h4>", x.Name);
                    });
                    Func<ContentPartModel, string> DetailsColumnGenerator = (x =>
                    {
                        return string.Format("{0}", x.Details);
                    });
                %>
                <%= RepeaterAssistant.Create<ContentPartModel>("item_parts").AddEntities(base.Model.ItemModel.Parts)
                        .AddColumns("Name", "Details").EnableHeader(false)
                        .AddGenerator("Name", NameColumnGenerator)
                        .AddGenerator("Details", DetailsColumnGenerator)
                        .GenerateHtml() %>
            </section>
        </div>
    </div>
    <aside class="ym-col3">
        <div class="ym-cbox">
            <h4>
                <%: base.Html.Translate("GUI.DetailsPage.AuthorInfo.Title")%>
            </h4>
            <div>
                <% base.Html.RenderPartial("UserDetailUserControl", base.Model.AuthorModel); %>
            </div>
            <h4>
                <%: base.Html.Translate("GUI.DetailsPage.FocusTitle")%>
            </h4>
            <div class="ym-contain-dt site-nbg">
                <%
                    Func<ContentItemModel, string> NameGenerator = x =>
                    {
                        return base.Html.ActionLink(x.Name, "Details", "Home", new { id = x.Id.ToString() }, new { title = x.Description }).ToHtmlString();
                    };
                %>
                <%= RepeaterAssistant.Create<ContentItemModel>("focus_items").AddEntities(base.Model.FocusItems)
                                    .EnableHeader(false)
                                    .AddColumns("Name")
                                    .AddGenerator("Name", NameGenerator)
                                    .GenerateHtml()%>
            </div>
        </div>
    </aside>
    <script type="text/javascript">
        $(document).ready(function () {
            $('div[name=item_parts]').addClass('rpt');
            $('div[name=item_parts] div[name=body]').addClass('rpt_body');
            $('div[name=item_parts] div[name=body] div[name=line]').addClass('rpt_body_line');
            $('div[name=item_parts] div[name=body] div[name=line]').addClass('rpt_body_line_home_details');
            $('div[name=item_parts] div[name=body] div[name=line] div[name=Name]').addClass('home-details-sub-title');
            $('div[name=item_parts] div[name=body] div[name=line] div[name=Details]').addClass('home-details-sub-content');

            $('div[name=focus_items] div[name=body]').addClass('rpt_body');
            $('div[name=focus_items] div[name=body] div[name=line]').addClass('rpt_body_line');
            $('div[name=focus_items] div[name=body] div[name=line]:even').addClass('rpt_body_line_even_none_focus');
            $('div[name=focus_items] div[name=body] div[name=line]:odd').addClass('rpt_body_line_odd_none_focus');
            $('div[name=focus_items] div[name=body] div[name=line] div[name=Name]').addClass('rpt_body_cell_focus_name_focus');
        });
    </script>
</asp:Content>
