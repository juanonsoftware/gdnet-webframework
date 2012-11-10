<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AccountLogOnModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal ID="L1" runat="server" Text="<%$ Trans:GUI.LogOnPage.Title %>" />
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ym-col1">
        <div class="ym-cbox">
            <h4>
                <asp:Literal ID="L2" runat="server" Text="<%$ Trans:GUI.LogOnPage.Header %>" />
            </h4>
            <section class="box">
                <div class="ym-contain-dt site-nbg">
                    <% base.Html.BeginForm(); %>
                    <%: base.Html.ValidationSummaryTrans(true, "GUI.LogOnPage.LoginError") %>
                    <fieldset>
                        <legend>
                            <asp:Literal ID="LA" runat="server" Text="<%$ Trans:GUI.LogOnPage.AccountInformation %>" />
                        </legend>
                        <div class="editor-label">
                            <%: Html.LabelFor(m => m.UserName) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(m => m.UserName) %>
                        </div>
                        <div>
                            <%: Html.ValidationMessageFor(m => m.UserName) %>
                        </div>
                        <div class="editor-label">
                            <%: Html.LabelFor(m => m.Password) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.PasswordFor(m => m.Password) %>
                        </div>
                        <div>
                            <%: Html.ValidationMessageFor(m => m.Password) %>
                        </div>
                        <div class="editor-label">
                            <%: Html.CheckBoxFor(m => m.RememberMe) %>
                            <%: Html.LabelFor(m => m.RememberMe) %>
                        </div>
                        <p>
                            <input type="submit" value='<%: base.Html.Translate("GUI.Common.SubmitButton") %>' />
                        </p>
                    </fieldset>
                    <% base.Html.EndForm(); %>
                </div>
            </section>
            <p>
            </p>
        </div>
    </div>
    <aside class="ym-col3">
        <h4>
            &nbsp;
        </h4>
        <div class="ym-cbox">
            <%
                string registerLink = base.Html.ActionLinkTrans("GUI.LogOnPage.RegisterText", "Register", "Account", "GUI.LogOnPage.RegisterTooltip").ToHtmlString();
            %>
            <%: base.Html.Translate("GUI.LogOnPage.Description", registerLink) %>
        </div>
    </aside>
</asp:Content>
