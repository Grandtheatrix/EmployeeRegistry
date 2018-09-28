<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeRegistryMainPage.aspx.cs" Inherits="EmployeeRegistry.EmployeeRegistryMainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Employee Registry</h1>
        <h3>Enter a New Employee</h3>
        <label>First Name:</label>
        <asp:TextBox ID="txtFirstName" MaxLength="50" runat="server" placeholder="ex. Leeloo"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="reqValFName"
            ControlToValidate="txtFirstName" runat="server"
            ErrorMessage="First Name is Required"
            ForeColor="Red"
            ValidationGroup="main">
        </asp:RequiredFieldValidator>
        <br />
        <label>Last Name:</label>
        <asp:TextBox ID="txtLastName" MaxLength="50" runat="server" placeholder="ex. Dallas"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="reqValLName"
            ControlToValidate="txtLastName" runat="server"
            ErrorMessage="Last Name is Required"
            ForeColor="Red"
            ValidationGroup="main">
        </asp:RequiredFieldValidator>
        <br />
        <label>Phone Number:</label>
        <asp:TextBox ID="txtPhoneNumber" MaxLength="10" runat="server" placeholder="XXXXXXXXXX"></asp:TextBox>
        <asp:RegularExpressionValidator ID="regExValPhone"
            ControlToValidate="txtPhoneNumber" runat="server"
            ErrorMessage="Please Enter Only Digits (0-9). Valid Entry Must Be 10 Digits Long"
            ForeColor="Red"
            ValidationExpression="[0-9]{10}"
            ValidationGroup="main">
        </asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="reqValPhone"
            ControlToValidate="txtPhoneNumber" runat="server"
            ErrorMessage="Phone Number is Required"
            ForeColor="Red"
            ValidationGroup="main">
        </asp:RequiredFieldValidator>
        <br />
        <label>Zipcode:</label>
        <asp:TextBox ID="txtZipcode" MaxLength="5" runat="server" placeholder="XXXXX"></asp:TextBox>
        <asp:RegularExpressionValidator ID="regExValZip"
            ControlToValidate="txtZipcode" runat="server"
            ErrorMessage="Please Enter Only Digits (0-9). Valid Entry Must Be 5 Digits Long"
            ForeColor="Red"
            ValidationExpression="[0-9]{5}"
            ValidationGroup="main">
        </asp:RegularExpressionValidator><br />
        <asp:RequiredFieldValidator ID="reqValZip"
            ControlToValidate="txtZipcode" runat="server"
            ErrorMessage="Zipcode is Required"
            ForeColor="Red"
            ValidationGroup="main">
        </asp:RequiredFieldValidator>
        <br />
        <label>Hire Date:</label>
        <asp:TextBox ID="txtHireDate" TextMode="Date" placeholder="Hire Date" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="reqValHireDate"
            ControlToValidate="txtHireDate" runat="server"
            ErrorMessage="Hire Date is Required"
            ForeColor="Red"
            ValidationGroup="main">
        </asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnSubmitNew" Text="Submit" runat="server" ValidationGroup="main" OnClick="btnSubmitNew_Click" />
        <br />
        <h3>Search for an Employee by Phone Number or Last Name</h3>
        <asp:TextBox ID="txtSearch" MaxLength="50" runat="server"></asp:TextBox><asp:Button ID="btnSearch" ValidationGroup="search" runat="server" Text="Search" OnClick="btnSearch_Click" /><asp:Button ID="btnReset" Text="Reset" runat="server" OnClick="btnReset_Click" />
        <asp:RequiredFieldValidator ID="reqValSearch"
            ControlToValidate="txtSearch" runat="server"
            ErrorMessage="Please Enter A Search Query"
            ForeColor="Red"
            ValidationGroup="search">
        </asp:RequiredFieldValidator>
        <br />
        <br />
    </form>
    <asp:Repeater ID="rpt" runat="server" OnItemDataBound="rpt_ItemDataBound">
        <HeaderTemplate>
            <table>
                <tr>
                    <td>Id
                    </td>
                    <td>First Name
                    </td>
                    <td>Last Name
                    </td>
                    <td>Phone Number
                    </td>
                    <td>Hire Date
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="lblId" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLastName" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblHireDate" runat="server"></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</body>
</html>
