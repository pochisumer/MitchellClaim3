<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MitchellClaim.aspx.cs" Inherits="MitchellClaim.MClaims" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload" runat="server" />
            <asp:Label ID="lblErrorFileUpload" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Import" runat="server" Text="Import" OnClick="Import_Click" />
        </div>
        <asp:Label ID="CreateClaimlbl" runat="server"></asp:Label><br />
        <br />
        Enter Claim Number to read a claim: 
        <asp:TextBox ID="readClaimtxtbx" runat="server"></asp:TextBox><br />
        <asp:Button ID="readclaimbtn" ValidationGroup="ClaimOperationRead" runat="server" Text="Find" OnClick="readclaimbtn_Click" /><asp:RequiredFieldValidator ID="rfvReadClaim" runat="server" ControlToValidate="readClaimtxtbx" ValidationGroup="ClaimOperationRead" ErrorMessage="Please enter Claim Number"></asp:RequiredFieldValidator>
        <asp:Label ID="nodatafounlblreadclaim" runat="server"></asp:Label>
        <asp:GridView ID="gvreadClaims" AutoGenerateColumns="False" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="ClaimNumber">
                    <EditItemTemplate>
                        <asp:TextBox ID="ClaimNumberetxtbx" runat="server" Text='<%# Bind("ClaimNumber") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="ClaimNumberlbl" runat="server" Text='<%# Bind("ClaimNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ClaimantFirstName">
                    <EditItemTemplate>
                        <asp:TextBox ID="ClaimantFirstNametxtbx" runat="server" Text='<%# Bind("ClaimantFirstName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="ClaimantFirstNamelbl" runat="server" Text='<%# Bind("ClaimantFirstName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ClaimantLastName">
                    <EditItemTemplate>
                        <asp:TextBox ID="ClaimantLastNametxtbx" runat="server" Text='<%# Bind("ClaimantLastName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="ClaimantLastNamelbl" runat="server" Text='<%# Bind("ClaimantLastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <EditItemTemplate>
                        <asp:TextBox ID="Statustxtbx" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Statuslbl" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LossDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="LossDatetxtbx" runat="server" Text='<%# Bind("LossDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LossDatelbl" runat="server" Text='<%# Bind("LossDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AssignedAdjusterID">
                    <EditItemTemplate>
                        <asp:TextBox ID="AssignedAdjusterIDtxtbx" runat="server" Text='<%# Bind("AssignedAdjusterID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="AssignedAdjusterIDlbl" runat="server" Text='<%# Bind("AssignedAdjusterID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="CauseOfLoss">
                    <EditItemTemplate>
                        <asp:TextBox ID="CauseOfLosstxtbx" runat="server" Text='<%# Bind("LossInfo.CauseOfLoss") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="CauseOfLosslbl" runat="server" Text='<%# Bind("LossInfo.CauseOfLoss") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ReportedDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="ReportedDatetxtbx" runat="server" Text='<%# Bind("LossInfo.ReportedDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="ReportedDatelbl" runat="server" Text='<%# Bind("LossInfo.ReportedDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LossDescription">
                    <EditItemTemplate>
                        <asp:TextBox ID="LossDescriptiontxtbx" runat="server" Text='<%# Bind("LossInfo.LossDescription") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LossDescriptionlbl" runat="server" Text='<%# Bind("LossInfo.LossDescription") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Vin">
                    <EditItemTemplate>
                        <asp:TextBox ID="Vintxtbx" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].Vin") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Vinlbl" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].Vin") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ModelYear">
                    <EditItemTemplate>
                        <asp:TextBox ID="ModelYeartxtbx" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].ModelYear") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="ModelYearlbl" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].ModelYear") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MakeDescription">
                    <EditItemTemplate>
                        <asp:TextBox ID="MakeDescriptiontxtbx" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].MakeDescription") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="MakeDescriptionlbl" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].MakeDescription") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ModelDescription">
                    <EditItemTemplate>
                        <asp:TextBox ID="ModelDescriptiontxtbx" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].ModelDescription") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="ModelDescriptionlbl" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].ModelDescription") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EngineDescription">
                    <EditItemTemplate>
                        <asp:TextBox ID="EngineDescriptiontxtbx" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].EngineDescription") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="EngineDescriptionlbl" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].EngineDescription") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExteriorColor">
                    <EditItemTemplate>
                        <asp:TextBox ID="ExteriorColortxtbx" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].ExteriorColor") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="ExteriorColorlbl" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].ExteriorColor") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LicPlate">
                    <EditItemTemplate>
                        <asp:TextBox ID="LicPlatetxtbx" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].LicPlate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LicPlatelbl" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].LicPlate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LicPlateState">
                    <EditItemTemplate>
                        <asp:TextBox ID="LicPlateStatetxtbx" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].LicPlateState") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LicPlateStatelbl" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].LicPlateState") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LicPlateExpDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="LicPlateExpDatetxtbx" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].LicPlateExpDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LicPlateExpDatelbl" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].LicPlateExpDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DamageDescription">
                    <EditItemTemplate>
                        <asp:TextBox ID="DamageDescriptiontxtbx" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].DamageDescription") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="DamageDescriptionlbl" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].DamageDescription") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mileage">
                    <EditItemTemplate>
                        <asp:TextBox ID="Mileagetxtbx" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].Mileage") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Mileagelbl" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Vehicles[0].Mileage") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        <br />

        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        list of claims in the backing store by date range of the LossDate starting from
        <asp:TextBox ID="startingDatetxtbx" ValidationGroup="dateRangeValidation" runat="server"></asp:TextBox>
        &nbsp; to&nbsp;&nbsp;
        <asp:TextBox ID="enddatetxtbx" ValidationGroup="dateRangeValidation" runat="server"></asp:TextBox>
        <cc1:CalendarExtender ID="cestartingDate" runat="server" TargetControlID="startingDatetxtbx" Format="MM/dd/yyyy" />
        <cc1:CalendarExtender ID="ceendDate" TargetControlID="enddatetxtbx" runat="server" Format="MM/dd/yyyy" />
        &nbsp;<asp:Button ID="submitbtn" runat="server" Text="Submit" OnClick="dateRangeCheck_Click" /><asp:Label ID="noDateFoundlbldaterange" runat="server"></asp:Label><br />
        <br />
        &nbsp; 
        <br />

        Please enter Claim Number to read specific Vehicle:
        <asp:TextBox ID="specificVehicletxtbx" runat="server"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="readSpecificVehiclebtn" ValidationGroup="ClaimOperationReadSpecificVehicle" runat="server" Text="Read Specific Vehicle" OnClick="readSpecificVehiclebtn_Click" />
        <asp:Label ID="nodatafoundreadspecificvehiclelbl" runat="server"></asp:Label>
        <br />
        <asp:RequiredFieldValidator ID="rfvReadVehicle" runat="server" ControlToValidate="specificVehicletxtbx" ValidationGroup="ClaimOperationReadSpecificVehicle" ErrorMessage="Enter  Claim Number"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <asp:Repeater ID="repeater" runat="server">
            <HeaderTemplate>

                <table border="1">


                    <tr>
                        <th>VIN
                        </th>
                        <th>MODEL YEAR 
                        </th>
                        <th>MAKE DESCRIPTION
                        </th>
                        <th>MODEL DESCRIPTION
                        </th>
                        <th>ENGINE DESCRIPTION
                        </th>
                        <th>EXTERIOR COLOR
                        </th>
                        <th>LIC PLATE
                        </th>
                        <th>LIC PLATE STATE
                        </th>
                        <th>LIC PLATE EXP DATE
                        </th>
                        <th>DAMAGE DESCRIPTION
                        </th>
                        <th>MILEAGE
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>


                <tr>
                    <td>
                        <%#Eval("Vin") %>
                    </td>
                    <td>
                        <%#Eval("ModelYear") %>                   
                    </td>
                    <td>
                        <%#Eval("MakeDescription") %>                    
                    </td>
                    <td>
                        <%#Eval("ModelDescription") %>
                    </td>
                    <td>
                        <%#Eval("EngineDescription") %>
                    </td>
                    <td>
                        <%#Eval("ExteriorColor") %>
                    </td>
                    <td>
                        <%#Eval("LicPlate") %>
                    </td>
                    <td>
                        <%#Eval("LicPlateState") %>
                    </td>
                    <td>
                        <%#Eval("LicPlateExpDate") %>
                    </td>
                    <td>
                        <%#Eval("DamageDescription") %>
                    </td>
                    <td>
                        <%#Eval("Mileage") %>
                    </td>


                </tr>

            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>

        <br />
        <br />
        <br />
        <div>
            Please enter the Claim Number to delete a claim:
            <asp:TextBox ID="deleteClaimtxtbx" runat="server"></asp:TextBox><asp:Button ID="deleteClaim" runat="server" Text="Delete Claim" ValidationGroup="ClaimOperationDelete" OnClick="deleteClaim_Click" /><br />
            <asp:Label ID="claimDeleted" runat="server"></asp:Label><asp:RequiredFieldValidator ID="rfvdeleteClaim" runat="server" ControlToValidate="deleteClaimtxtbx" ValidationGroup="ClaimOperationDelete" ErrorMessage="Please enter Claim Number"></asp:RequiredFieldValidator>
            <br />
            <br />
            <br />
        </div>

        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Label ID="lblupdateClaimerror" runat="server"></asp:Label>


        <br />
        <asp:Button ID="updateClaimbtn" runat="server" Text="Update Claim" OnClick="updateClaimbtn_Click" /><br />
        <asp:Label ID="updateClaimSuccessful" runat="server"></asp:Label>
    </form>
</body>
</html>
