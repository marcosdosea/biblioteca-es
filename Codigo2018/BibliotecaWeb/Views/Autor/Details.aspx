﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Models.Autor>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>tb_autor</legend>

    <div class="display-label"><%: Html.LabelFor(model => model.Nome) %></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Nome) %>
    </div>

    <div class="display-label"><%: Html.LabelFor(model => model.AnoNascimento) %></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.AnoNascimento) %>
    </div>
</fieldset>
<p>

    <%: Html.ActionLink("Edit", "Edit", new { id=Model.Codigo }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
