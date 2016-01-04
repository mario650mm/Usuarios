<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Usuarios.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Usuarios</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css" />
</head>
<body>
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
                <li class="active"><a href="#"><i class="fa fa-users"></i> Usuarios</a></li>
            </ul>
        </div>
    <form id="formulario" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-6">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="val1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Nombre requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="col-lg-6">
                    <asp:Label ID="lblApellidos" runat="server" Text="Apellidos"></asp:Label>
                    <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" placeholder="Apellidos"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="val2" runat="server" ControlToValidate="txtApellidos" ErrorMessage="Apellidos requeridos" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label ID="lblCalle" runat="server" Text="Calle"></asp:Label>
                    <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" placeholder="Calle"></asp:TextBox>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="lblNoExt" runat="server" Text="No.Exterior"></asp:Label>
                    <asp:TextBox  ID="txtNoExt" runat="server" CssClass="form-control" placeholder="Número de exterior"/>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="lblNoInt" runat="server" Text="No.Interior"></asp:Label>
                    <asp:TextBox ID="txtNoInt" runat="server" CssClass="form-control" placeholder="Número de interior"/>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Teléfono"/>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="lblMovil" runat="server" Text="Móvil"></asp:Label>
                    <asp:TextBox ID="txtMovil" runat="server" CssClass="form-control" placeholder="Móvil"/>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="lblCP" runat="server" Text="Código Postal"></asp:Label>
                    <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" placeholder="Código Postal"/>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
                    <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control" placeholder="Estado"/>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="lblCiudad" runat="server" Text="Ciudad"></asp:Label>
                    <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" placeholder="Ciudad"/>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-3">
                    <asp:ImageButton ID="btnnew" runat="server" CssClass="btn btn-info fa fa-file-text" AlternateText=" " OnClick="btnnew_Click"/> 
                </div>
                <div class="col-lg-3">
                    <asp:ImageButton ID="btnadd" runat="server" CssClass="btn btn-success fa fa-plus" AlternateText=" " OnClick="btnadd_Click"/> 
                </div>
                <div class="col-lg-3">
                    <asp:ImageButton ID="btnupdate" runat="server" CssClass="btn btn-primary fa fa-pencil-square-o" AlternateText=" " OnClick="btnupdate_Click"/> 
                </div>
                <div class="col-lg-3">
                    <asp:ImageButton ID="btndelete" runat="server" CssClass="btn btn-danger fa fa-trash" AlternateText=" " OnClick="btndelete_Click" /> 
                </div>
            </div>
            <br /><br />
            <div class="row">
                <div class="col-lg-6">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
            </div>
            <br />
            <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="false" HorizontalAlign="center" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Nombre" />
                    <asp:BoundField DataField="lastName" HeaderText="Apellidos" />
                    <asp:BoundField DataField="street" HeaderText="Calle" />
                    <asp:BoundField DataField="noExt" HeaderText="NoExt" />
                    <asp:BoundField DataField="noInt" HeaderText="NoInt" />
                    <asp:BoundField DataField="phone" HeaderText="Phone" />
                    <asp:BoundField DataField="movil" HeaderText="movil" />
                    <asp:BoundField DataField="cp" HeaderText="CP" />
                    <asp:BoundField DataField="state" HeaderText="Estado" />
                    <asp:BoundField DataField="city" HeaderText="Ciudad" /> 
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Modificar
                        </HeaderTemplate>
                        <ItemTemplate>
                             <asp:ImageButton ID="btnSelect" runat="server" AlternateText=" " CssClass="btn btn-primary fa fa-check-circle" CommandArgument='<%#Eval("id").ToString() %>'  OnClick="btnSelect_Click"></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>  
                </Columns>
            </asp:GridView>
        </div> <!--End of conatiner--> 
    </form>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</body>
</html>
