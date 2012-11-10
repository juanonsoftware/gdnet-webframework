<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PageMetaModel>" %>
<%@ Import Namespace="GDNET.Framework.Models" %>
<meta name="description" content="<%: base.Model.Description %>" />
<meta name="keywords" content="<%: base.Model.Keywords %>" />
<meta name="author" content="<%: base.Model.Author %>" />
