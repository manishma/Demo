<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.List<Demo.Domain.Product>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>
</head>
<body>

<%: Html.Grid(Model).Columns(c =>
                                                    {
                                                        c.For(x => x.Id);
                                                        c.For(x => x.Name);
                                                        c.For(x => x.Price).Format("{0:c}");
                                                        c.Custom(x => "<a href=\"/Products/Details/" + x.Id + "\">details</a>");
                                                    }) %>    
    
</body>
</html>
