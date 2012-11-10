<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AccountWatchModel>" %>

<%@ Import Namespace="GreatApp.Infrastructure.Models" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate("GUI.Page.AccountView.Title")%>
    -
    <%: base.Model.UserDetails.DisplayName %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MetaContent" runat="server">
    <% base.Html.RenderPartial("PageMetaUserControl", base.Model.PageMeta); %>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ym-col1">
        <div class="ym-cbox">
            <h4>
                <%: base.Html.Translate("GUI.Page.AccountView.Focus")%>
            </h4>
            <div>
                <% base.Html.RenderPartial("UserDetailUserControl", base.Model.UserDetails); %>
            </div>
            <p>
            </p>
        </div>
    </div>
    <aside class="ym-col3">
        <div class="ym-cbox">
            <h4>
                <%: base.Html.Translate("GUI.Page.AccountWatch.NewsTitle")%>
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
        <script type="text/javascript">
            $(document).ready(function () {
                $('div[name=focus_items] div[name=body]').addClass('rpt_body');
                $('div[name=focus_items] div[name=body] div[name=line]').addClass('rpt_body_line');
                $('div[name=focus_items] div[name=body] div[name=line]:even').addClass('rpt_body_line_even_none_focus');
                $('div[name=focus_items] div[name=body] div[name=line]:odd').addClass('rpt_body_line_odd_none_focus');
                $('div[name=focus_items] div[name=body] div[name=line] div[name=Name]').addClass('rpt_body_cell_focus_name_focus');
            });
        </script>
    </aside>
</asp:Content>
