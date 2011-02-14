<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.IList<Demo.Domain.Order>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Orders</title>
</head>
<body>
    
    <%: Html.Grid(Model).Columns(c =>
                                                    {
                                                        c.For(x => x.Id);
                                                        c.For(x => x.Customer);
                                                        c.For(x => x.Total).Format("{0:c}");
                                                        c.Custom(x => "<a href=\"/Orders/Details/"+x.Id+"\">details</a>");
                                                    }) %>    

</body>
</html>
