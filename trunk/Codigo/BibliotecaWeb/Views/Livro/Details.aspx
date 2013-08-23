<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Models.Livro>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

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
<p>
    <%: Html.ActionLink("Edit", "Edit", new {  id=Model.Isbn }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
