<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Models.Livro>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Livro</legend>

    <div class="display-label">Isbn</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Isbn) %>
    </div>

    <div class="display-label">IdEditora</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.IdEditora) %>
    </div>

    <div class="display-label">NomeEditora</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.NomeEditora) %>
    </div>

    <div class="display-label">Nome</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Nome) %>
    </div>

    <div class="display-label">DataPublicacao</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.DataPublicacao) %>
    </div>

    <div class="display-label">Resumo</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Resumo) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
