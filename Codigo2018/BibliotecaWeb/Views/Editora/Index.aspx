<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Models.Editora>>" %>

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
            Codigo
        </th>
        <th>
            Nome
        </th>
        <th>
            Rua
        </th>
        <th>
            Bairro
        </th>
        <th>
            Cidade
        </th>
        <th>
            Numero
        </th>
        <th>
            Estado
        </th>
        <th>
            Cep
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Codigo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Nome) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Rua) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Bairro) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Cidade) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Numero) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Estado) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Cep) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new {  id=item.Codigo  }) %> |
            <%: Html.ActionLink("Details", "Details", new { id = item.Codigo })%> |
            <%: Html.ActionLink("Delete", "Delete", new { id = item.Codigo })%>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
