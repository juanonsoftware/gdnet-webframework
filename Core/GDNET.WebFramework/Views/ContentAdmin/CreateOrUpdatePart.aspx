<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteAdmin.Master"
    Inherits="System.Web.Mvc.ViewPage<ContentPartModel>" %>

<%@ Import Namespace="GreatApp.Infrastructure.Models" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate(base.Model.IsCreation ? "GUI.ContentAdmin.ContentPart.Title.Creation" : "GUI.ContentAdmin.ContentPart.Title.Modification")%>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MetaContent" runat="server">
    <script type="text/javascript" src="/Content/ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: base.Html.Translate(base.Model.IsCreation ? "GUI.ContentAdmin.ContentPart.Focus.Creation" : "GUI.ContentAdmin.ContentPart.Focus.Modification")%>
    </h2>
    <div>
        <% Html.BeginForm(); %>
        <%: Html.ValidationSummaryTrans(true, "GUI.ContentAdmin.ContentPart.ValidationSummary")%>
        <fieldset>
            <legend></legend>
            <div class="editor-line">
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Name) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Name, "input_name")%>
                    <%: Html.ValidationMessageFor(m => m.Name)%>
                </div>
            </div>
            <div class="editor-line">
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Details)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.Details, "ckeditor textarea_content")%>
                    <%: Html.ValidationMessageFor(m => m.Details)%>
                </div>
            </div>
            <div class="editor-line">
                <div class="editor-field">
                    <%: Html.CheckBoxFor(m => m.IsActive)%>
                    <%: Html.LabelFor(m => m.IsActive) %>
                </div>
            </div>
            <div class="editor-line">
                <p>
                    <input type="submit" value='<%: base.Html.Translate("GUI.Common.SubmitButton") %>' />
                </p>
            </div>
        </fieldset>
        <% Html.EndForm(); %>
    </div>
</asp:Content>
