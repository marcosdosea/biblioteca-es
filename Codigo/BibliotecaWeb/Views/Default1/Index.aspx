<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<BibliotecaWeb.tb_autor>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            nome
        </th>
        <th>
            anoNascimento
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.nome) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.anoNascimento) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.idAutor }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.idAutor }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.idAutor }) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
