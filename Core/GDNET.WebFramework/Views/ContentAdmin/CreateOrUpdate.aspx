<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemModel>" %>

<%@ Import Namespace="GDNET.Domain.Entities.System.ReferenceData" %>
<%@ Import Namespace="GreatApp.Infrastructure.Models" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate(base.Model.IsCreation ? "GUI.ContentAdmin.ContentItem.Title.Creation" : "GUI.ContentAdmin.ContentItem.Title.Modification")%>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: base.Html.Translate(base.Model.IsCreation ? "GUI.ContentAdmin.ContentItem.Focus.Creation" : "GUI.ContentAdmin.ContentItem.Focus.Modification")%>
    </h2>
    <div>
        <% Html.BeginForm(); %>
        <%: base.Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.") %>
        <fieldset>
            <legend></legend>
            <div class="editor-line">
                <div class="editor-label">
                    <%: base.Html.LabelFor(m => m.Name) %>
                </div>
                <div class="editor-field">
                    <%: base.Html.TextBoxFor(m => m.Name, "input_name")%>
                    <%: base.Html.ValidationMessageFor(m => m.Name)%>
                </div>
            </div>
            <div class="editor-line">
                <div class="editor-label">
                    <%: base.Html.LabelFor(m => m.Description)%>
                </div>
                <div class="editor-field">
                    <%: base.Html.TextAreaFor(m => m.Description, "textarea_content")%>
                    <%: base.Html.ValidationMessageFor(m => m.Description)%>
                </div>
            </div>
            <div class="editor-line">
                <div class="editor-label">
                    <%: base.Html.LabelFor(m => m.Keywords)%>
                </div>
                <div class="editor-field">
                    <%: base.Html.TextAreaFor(m => m.Keywords, "textarea_tiny")%>
                </div>
            </div>
            <div class="clear">
                <%: base.Html.ValidationMessageFor(m => m.Keywords)%>
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
                <div class="editor-field">
                    <%: base.Html.CheckBoxFor(m => m.IsActive)%>
                    <%: base.Html.LabelFor(m => m.IsActive) %>
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
