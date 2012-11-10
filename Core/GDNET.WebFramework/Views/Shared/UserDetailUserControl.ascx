<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserDetailsModel>" %>
<%@ Import Namespace="GDNET.WebInfrastructure.Models.System" %>
<div class="ym-contain-dt site-nbg">
    <div>
        <div class="normal">
            <%: base.Model.DisplayName %>
        </div>
        <div class="normal">
            <%
                if (base.Model.DisplayMode != UserDetailsMode.Search)
                {
            %>
            <%: base.Html.ActionLinkTrans("GUI.UserDetails.SearchContent", "Index", ListControllers.Search, new { by = SearchMode.Author.ToString().ToLower(), value = base.Model.Id })%>
            <%
                }
            %>
            <%
                if (base.Model.DisplayMode != UserDetailsMode.AccountWatch)
                {
            %>
            <%: base.Html.ActionLinkTrans("GUI.UserDetails.ViewAccount", "Watch", ListControllers.Account, new { id = base.Model.Id })%>
            <%
                }
            %>
        </div>
    </div>
    <div>
        <section class="box">
            <h6>
                <%: base.Html.Translate("GUI.User.CreatedDate")%>
            </h6>
            <div class="normal">
                <%: base.Model.CreatedAt.ToShortDateString() %>
            </div>
            <h6>
                <%: base.Html.LabelFor(m => m.TotalPoints) %>
            </h6>
            <div class="normal">
                <%: base.Html.Format(base.Model.TotalPoints, "GUI.User.TotalPoints.NoPoint")%>
            </div>
            <h6>
                <%: base.Html.Translate("GUI.User.Introduction")%>
            </h6>
            <%= base.Model.Introduction %>
        </section>
    </div>
</div>
