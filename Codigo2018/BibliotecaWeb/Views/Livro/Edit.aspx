<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Models.Livro>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Livro</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Isbn) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Isbn) %>
            <%: Html.ValidationMessageFor(model => model.Isbn) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.NomeEditora) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("IdEditora") %>
            <%: Html.ValidationMessageFor(model => model.IdEditora) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Nome) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Nome) %>
            <%: Html.ValidationMessageFor(model => model.Nome) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.DataPublicacao) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.DataPublicacao) %>
            <%: Html.ValidationMessageFor(model => model.DataPublicacao) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Resumo) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Resumo) %>
            <%: Html.ValidationMessageFor(model => model.Resumo) %>
        </div>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
<% } %>

<% Html.RenderPartial("ListarAutores", Model.ListaAutores);%>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
