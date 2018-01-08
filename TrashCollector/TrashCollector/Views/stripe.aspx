<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stripe.aspx.cs" Inherits="TrashCollector.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    <form action="/Charge" method="POST">
    <script
        src="https://checkout.stripe.com/checkout.js" class="stripe-button"
        data-key="&lt;%= stripePublishableKey %&gt;"
        data-amount="500"
        data-name="Stripe.com"
        data-description="Sample Charge"
        data-locale="auto"
        data-zip-code="true">
    </script>
</form>
</body>
</html>
