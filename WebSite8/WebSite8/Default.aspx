<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:pawel2ConnectionString %>" DeleteCommand="DELETE FROM [Etaty] WHERE [id] = @id" InsertCommand="INSERT INTO [Etaty] ([nazwa], [placa_od], [placa_do]) VALUES (@nazwa, @placa_od, @placa_do)" SelectCommand="SELECT * FROM [Etaty]" UpdateCommand="UPDATE [Etaty] SET [nazwa] = @nazwa, [placa_od] = @placa_od, [placa_do] = @placa_do WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="nazwa" Type="String" />
                    <asp:Parameter Name="placa_od" Type="Int32" />
                    <asp:Parameter Name="placa_do" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="nazwa" Type="String" />
                    <asp:Parameter Name="placa_od" Type="Int32" />
                    <asp:Parameter Name="placa_do" Type="Int32" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="nazwa" HeaderText="nazwa" SortExpression="nazwa" />
                    <asp:BoundField DataField="placa_od" HeaderText="placa_od" SortExpression="placa_od" />
                    <asp:BoundField DataField="placa_do" HeaderText="placa_do" SortExpression="placa_do" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="id" DataSourceID="SqlDataSource1">
            <EditItemTemplate>
                id:
                <asp:Label ID="idLabel1" runat="server" Text='<%# Eval("id") %>' />
                <br />
                nazwa:
                <asp:TextBox ID="nazwaTextBox" runat="server" Text='<%# Bind("nazwa") %>' />
                <br />
                placa_od:
                <asp:TextBox ID="placa_odTextBox" runat="server" Text='<%# Bind("placa_od") %>' />
                <br />
                placa_do:
                <asp:TextBox ID="placa_doTextBox" runat="server" Text='<%# Bind("placa_do") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                nazwa:
                <asp:TextBox ID="nazwaTextBox" runat="server" Text='<%# Bind("nazwa") %>' />
                <br />
                placa_od:
                <asp:TextBox ID="placa_odTextBox" runat="server" Text='<%# Bind("placa_od") %>' />
                <br />
                placa_do:
                <asp:TextBox ID="placa_doTextBox" runat="server" Text='<%# Bind("placa_do") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                id:
                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                <br />
                nazwa:
                <asp:Label ID="nazwaLabel" runat="server" Text='<%# Bind("nazwa") %>' />
                <br />
                placa_od:
                <asp:Label ID="placa_odLabel" runat="server" Text='<%# Bind("placa_od") %>' />
                <br />
                placa_do:
                <asp:Label ID="placa_doLabel" runat="server" Text='<%# Bind("placa_do") %>' />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
            </ItemTemplate>
        </asp:FormView>
    </form>
</body>
</html>
