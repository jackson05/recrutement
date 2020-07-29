<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_employeeUI.aspx.cs" Inherits="recrutement.employer.add_employeeUI" %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
            <asp:GridView ID="GridViewemployer" runat="server" BackColor="#006666" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="77px" 
                Style="margin-left:-5px;" DataKeyNames="id_employer" OnRowCommand="GridViewemployer_RowCommand"  OnRowEditing="GridViewemployer_RowEditing" OnRowCancelingEdit="GridViewemployer_RowCancelingEdit" OnRowUpdating="GridViewemployer_RowUpdating" 
                 OnRowDeleting="GridViewemployer_RowDeleting"  Font-Size="Small">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <EditRowStyle Wrap="True" />
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#003366" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />

                <Columns>

                    <asp:TemplateField HeaderText="Matricule">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval ("matricule")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate >
                            <asp:TextBox ID="textmatricule" Text='<%# Eval ("matricule")%>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate >
                            <asp:TextBox ID="textmatriculefooter"  runat="server"></asp:TextBox>
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nom">
                        <ItemTemplate>
                            <asp:Label  Text='<%# Eval ("nom")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate >
                            <asp:TextBox ID="textnom" Text='<%# Eval ("nom")%>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate >
                            <asp:TextBox ID="textnomfooter"  runat="server"></asp:TextBox>
                        </FooterTemplate>

                    </asp:TemplateField>


                   <asp:TemplateField HeaderText="Prenom">
                        <ItemTemplate>
                            <asp:Label  Text='<%# Eval ("prenom")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate >
                            <asp:TextBox ID="textprenom" Text='<%# Eval ("prenom")%>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate >
                            <asp:TextBox ID="textprenomfooter"  runat="server"></asp:TextBox>
                        </FooterTemplate>

                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Profile">
                        <ItemTemplate>
                            <asp:Label  Text='<%# Eval ("profiles")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate >
                            <asp:TextBox ID="textprofile" Text='<%# Eval ("profiles")%>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate >
                            <asp:TextBox ID="textprofilefooter"  runat="server"></asp:TextBox>
                        </FooterTemplate>

                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="Date de naissance">
                        <ItemTemplate>
                            <asp:Label  Text='<%# Eval ("date_naissance")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate >
                            <asp:TextBox ID="textnaissance" Text='<%# Eval ("date_naissance")%>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate >
                            <asp:TextBox ID="textnaissancefooter"  runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Lieu de naissance">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval ("lieu_naissance")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate >
                            <asp:TextBox ID="textlieunaissance" Text='<%# Eval ("lieu_naissance")%>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate >
                            <asp:TextBox ID="textlieunaissancefooter"  runat="server"></asp:TextBox>
                        </FooterTemplate>

                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Mail">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval ("mail")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate >
                            <asp:TextBox ID="textmail" Text='<%# Eval ("mail")%>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate >
                            <asp:TextBox ID="textmailfooter"  runat="server"></asp:TextBox>
                        </FooterTemplate>

                    </asp:TemplateField>

                    
                     <asp:TemplateField HeaderText="Telephone">
                        <ItemTemplate>
                            <asp:Label  Text='<%# Eval ("tel")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate >
                            <asp:TextBox ID="texttelephone" Text='<%# Eval ("tel")%>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate >
                            <asp:TextBox ID="texttelephonefooter"  runat="server"></asp:TextBox>
                        </FooterTemplate>

                    </asp:TemplateField>


                    <asp:TemplateField>
                       

                        <EditItemTemplate>
                            <asp:ImageButton  ImageUrl="~/imageIcone/noir blanc/icons8_save_30px_2.png" runat="server" CommandName="Update" ToolTip="Enregistrer la modification contenu" Width="20px" Height="20px" />
                            <asp:ImageButton  ImageUrl="~/imageIcone/noir blanc/icons8_cancel_30px_4.png" runat="server" CommandName="Cancel" ToolTip="Ignorer la modification" Width="20px" Height="20px" />

                        </EditItemTemplate>

                         <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" ImageUrl="~/imageIcone/avec couleur/icons8_edit_30px_2.png" runat="server" CommandName="Edit" ToolTip="Modifier le contenu" Width="20px" Height="20px"/>

                            <asp:ImageButton ID="ImageButton1"  ImageUrl="~/imageIcone/noir blanc/icons8_delete_30px.png" runat="server" CommandName="delete" ToolTip="supprimer le contenu" Width="20px" Height="20px" />
                   
                        </ItemTemplate>

                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/imageIcone/noir blanc/icons8_add_30px.png" runat="server" CommandName="ajouternouveau" ToolTip="Ajouter nouveau" Width="20px" Height="20px"/>

                        </FooterTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
       
       
            <asp:Label ID="labsucces" runat="server" ForeColor="Green"></asp:Label>
            <asp:Label ID="error" runat="server" ForeColor="Red"></asp:Label>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           &nbsp 
        <br />
            <br />
            <asp:DropDownList ID="DropDownListAssoc"  runat="server" Font-Size="15px" Height="32px" Width="670px" BackColor="#003366" Font-Bold="false" ForeColor="White">
                
            </asp:DropDownList>
            &nbsp<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ajouter des lieu d'affectations" BackColor="Green" BorderWidth="0px" Font-Bold="True" ForeColor="White" Height="32px" ToolTip="Cliquez pour avoir la liste des affectations" Width="228px" />

            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Charger la liste des employers" BackColor="Green" BorderWidth="0px" Font-Bold="True" ForeColor="White" Height="32px" ToolTip="Cliquez pour charger la liste des employers" Width="228px" /><br />

            <asp:ImageButton ID="voir_image" ImageUrl="~/imageIcone/avec couleur/icons8_Image_Gallery_40px_1.png" runat="server" ToolTip="voir photo d'un employer" Height="30px" Width="30px" Enabled="false" OnClick="voir_image_Click"/>

            <asp:ImageButton ID="detaille" ImageUrl="~/imageIcone/avec couleur/icons8_details_popup__30px.png" ToolTip="Detail" runat="server" Height="30px" Width="30px" Enabled="false" OnClick="detaille_Click"/>

            &nbsp;<asp:Label ID="Label_valide" runat="server" ForeColor="Green"></asp:Label>
            <asp:Label ID="label_erreur" runat="server" ForeColor="Red" Text="Label"></asp:Label>

            <br /><br />

           &nbsp;&nbsp;&nbsp <asp:Image ID="Image1" runat="server" Height="161px" Width="201px"/><br />
        
         &nbsp;&nbsp<asp:FileUpload ID="FileUpload1" runat="server" BackColor="#003366" BorderWidth="0px" Font-Bold="True" Font-Underline="True" ForeColor="White" ToolTip="Choisir une image" Width="224px" Height="24px"  />
    &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Buttonvoir" runat="server" Text="voir cette image" Width="146px" BackColor="#003366" BorderWidth="0px" Font-Bold="True" ForeColor="White" OnClick="Buttonvoir_Click" Height="25px" />
    </form>
</body>
</html>
