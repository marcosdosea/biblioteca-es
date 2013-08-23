<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Models.Livro>>" %>

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
            Isbn
        </th>
        <th>
            IdEditora
        </th>
        <th>
            NomeEditora
        </th>
        <th>
            Nome
        </th>
        <th>
            DataPublicacao
        </th>
        <th>
            Resumo
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Isbn) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.IdEditora) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.NomeEditora) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Nome) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.DataPublicacao) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Resumo) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.Isbn }) %> |
            <%: Html.ActionLink("Details", "Details", new { id = item.Isbn })%> |
            <%: Html.ActionLink("Delete", "Delete", new { id = item.Isbn })%>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
