<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Demo.Domain.Customer>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer details</title>
</head>
<body>

<h2>Customer details</h2>

<table>
<tr>
    <td>Customer #:</td>
    <td><%: Model.Id %></td>
</tr>
<tr>
    <td>First name:</td>
    <td><%: Model.FirstName %></td>
</tr>
<tr>
    <td>Last name:</td>
    <td><%: Model.FirstName%></td>
</tr>

</table>

<div><a href="/Orders/ByUser/<%= Model.Id %>">orders</a></div>
    
</body>
</html>
