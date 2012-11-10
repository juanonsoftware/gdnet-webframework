<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<ul>
    <%
        if (base.Request.IsAuthenticated)
        {
    %>
    <li>
        <%: Html.ActionLinkTrans("GUI.LogOn.Details", "Details", "Account") %>
    </li>
    <li>
        <%: Html.ActionLinkTrans("GUI.LogOn.LogOff", "LogOff", "Account") %>
    </li>
    <%
        }
        else
        {
    %>
    <li>
        <%: Html.ActionLinkTrans("GUI.LogOn.LogOn", "LogOn", "Account")%>
    </li>
    <%
        }
    %>
    <li>
        <%: base.Html.ActionLinkTrans("GUI.UserCustomizedInformation.ChangeLanguage", "ChangeLanguage", "My")%>
    </li>
</ul>
