<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AccountRegisterModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate("GUI.RegisterPage.Title") %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MetaContent" runat="server">
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ym-col1">
        <div class="ym-cbox">
            <h4>
                <%: base.Html.Translate("GUI.RegisterPage.Header") %>
            </h4>
            <p>
                <%: base.Html.Translate("GUI.RegisterPage.Description", Membership.MinRequiredPasswordLength)%>
            </p>
            <section class="box">
                <div class="ym-contain-dt site-nbg">
                    <% Html.BeginForm(); %>
                    <%: Html.ValidationSummaryTrans(true, "GUI.RegisterPage.RegisterError")%>
                    <fieldset>
                        <legend></legend>
                        <div class="editor-label">
                            <%: Html.LabelFor(m => m.Email) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(m => m.Email) %>
                            <%: Html.ValidationMessageFor(m => m.Email) %>
                        </div>
                        <div class="editor-label">
                            <%: Html.LabelFor(m => m.Password) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.PasswordFor(m => m.Password) %>
                            <%: Html.ValidationMessageFor(m => m.Password) %>
                        </div>
                        <div class="editor-label">
                            <%: Html.LabelFor(m => m.ConfirmPassword) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                            <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                        </div>
                        <p>
                            <input type="submit" value='<%: base.Html.Translate("GUI.Common.SubmitButton") %>' />
                        </p>
                    </fieldset>
                    <% Html.EndForm(); %>
                </div>
            </section>
        </div>
        <p>
        </p>
    </div>
    <aside class="ym-col3">
        <h4>
            &nbsp;
        </h4>
        <div class="ym-cbox">
        </div>
    </aside>
</asp:Content>
