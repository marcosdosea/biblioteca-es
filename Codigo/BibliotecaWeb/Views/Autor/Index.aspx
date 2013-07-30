<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Models.Autor>>" %>

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
            Id
        </th>
        <th>
           Nome
        </th>
        <th>
            Data Nascimento
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
            <%: Html.DisplayFor(modelItem => item.AnoNascimento) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.Codigo }) %> |
            <%: Html.ActionLink("Details", "Details", new { id = item.Codigo })%> |
            <%: Html.ActionLink("Delete", "Delete", new { id = item.Codigo })%>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
