<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Demo.Domain.Order>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Details</title>
</head>
<body>
<h2>Order details</h2>

<table>
<tr>
<td>Order #:</td>
<td><%: Model.Id %></td>
</tr>
<tr>
    <td>Total:</td>
    <td><%: Model.Total %></td>
</tr>

</table>

<h2>Customer details:</h2>

<table>
<tr>
    <td>Name:</td>
    <td><%: Model.Customer.ToString() %></td>
</tr>

</table>

<h2>Product list:</h2>
        <%: Html.Grid(Model.Products).Columns(c =>
                                                    {
                                                        c.For(x => x.Product.Id);
                                                        c.For(x => x.Product.Name);
                                                        c.For(x => x.Product.Price).Format("{0:c}");
                                                        c.For(x => x.Quantity);
                                                        c.For(x => x.Total).Format("{0:c}");
                                                        c.Custom(x => "<a href=\"/Products/Details/"+x.Product.Id+"\">details</a>");
                                                    }) %>    

</body>
</html>
