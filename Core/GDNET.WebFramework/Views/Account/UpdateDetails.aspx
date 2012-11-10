<%@ Page Language="C#" MasterPageFile="~/Views/Shared/SiteAdmin.Master" Inherits="System.Web.Mvc.ViewPage<AccountUpdateDetailsModel>" %>

<%@ Import Namespace="GDNET.Domain.Entities.System.ReferenceData" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate("GUI.Account.UpdateDetailPage.Title") %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MetaContent" runat="server">
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: base.Html.Translate("GUI.Account.UpdateDetailPage.Focus") %>
    </h2>
    <div>
        <% Html.BeginForm(); %>
        <%: Html.ValidationSummary(true, "Account modification was unsuccessful. Please correct the errors and try again.") %>
        <fieldset>
            <legend></legend>
            <div class="editor-line">
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.DisplayName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.DisplayName, "input_name")%>
                    <%: Html.ValidationMessageFor(m => m.DisplayName)%>
                </div>
            </div>
            <div class="editor-line">
                <div class="editor-label">
                    <%: base.Html.LabelFor(m => m.Language)%>
                </div>
                <div class="editor-field">
                    <%: base.Html.DropDownListFor(m => m.Language, SystemCatalogs.Languages)%>
                </div>
            </div>
            <div class="editor-line">
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Introduction) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.Introduction, "textarea_content")%>
                    <%: Html.ValidationMessageFor(m => m.Introduction)%>
                </div>
            </div>
            <div class="editor-line">
                <div class="editor-field">
                    <%: Html.CheckBoxFor(m => m.IsActive)%>
                    <%: Html.LabelFor(m => m.IsActive) %>
                </div>
            </div>
        </fieldset>
        <p>
            <input type="submit" value='<%: base.Html.Translate("GUI.Common.SubmitButton") %>' />
        </p>
        <% Html.EndForm(); %>
    </div>
</asp:Content>
