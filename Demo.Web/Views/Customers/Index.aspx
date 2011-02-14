<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.List<Customer>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customers</title>
</head>
<body>

<p>
<%: Html.ActionLink("Products", "Index", "Products")%>
</p>

<h1>Customers</h1>

<%: Html.Grid(Model).Columns(c =>
                                                    {
                                                        c.For(x => x.Id);
                                                        c.For(x => x.FirstName);
                                                        c.For(x => x.LastName);
                                                        c.For(x => x.Type);
                                                        c.Custom(x => "<a href=\"/Customers/Details/" + x.Id + "\">details</a>");
                                                        c.Custom(x => "<a href=\"/Orders/ByUser/" + x.Id + "\">orders</a>");
                                                    }) %>    
</body>
</html>
