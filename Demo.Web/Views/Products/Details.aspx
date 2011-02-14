<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Demo.Domain.Product>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Details</title>
</head>
<body>

<h2>Product details</h2>

<table>
<tr>
    <td>Product #:</td>
    <td><%: Model.Id %></td>
</tr>
<tr>
    <td>Name:</td>
    <td><%: Model.Name %></td>
</tr>
<tr>
    <td>Price:</td>
    <td><%: Model.Price.ToString("c") %></td>
</tr>

</table>
    
</body>
</html>
