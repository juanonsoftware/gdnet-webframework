<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MyChangeLanguageModel>" %>

<%@ Import Namespace="GDNET.Domain.Entities.System.ReferenceData" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal ID="L1" runat="server" Text="<%$ Trans:GUI.My.ChangeLanguage.Title %>" />
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MetaContent" runat="server">
    <% base.Html.RenderPartial("PageMetaUserControl", base.Model.PageMeta); %>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ym-col1">
        <div class="ym-cbox">
            <h4>
                <asp:Literal ID="LA" runat="server" Text="<%$ Trans:GUI.My.ChangeLanguage.Legend %>" />
            </h4>
            <section class="box">
                <div class="ym-contain-dt site-nbg">
                    <% Html.BeginForm(); %>
                    <fieldset>
                        <legend></legend>
                        <div class="editor-label">
                            <%: base.Html.Translate("GUI.My.ChangeLanguage.LanguageUI")%>
                        </div>
                        <div class="editor-field">
                            <%: base.Html.DropDownListFor(m => m.UserCustomizedInformation.LanguageUI, SystemCatalogs.Languages)%>
                        </div>
                        <div class="editor-label">
                            <%: base.Html.Translate("GUI.My.ChangeLanguage.Language")%>
                        </div>
                        <div class="editor-field">
                            <%: base.Html.DropDownListFor(m => m.UserCustomizedInformation.Language, SystemCatalogs.Languages, true, true)%>
                        </div>
                        <p>
                            <input type="submit" value='<%: base.Html.Translate("GUI.Common.SubmitButton") %>' />
                        </p>
                    </fieldset>
                    <% Html.EndForm(); %>
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
        </div>
    </aside>
</asp:Content>
