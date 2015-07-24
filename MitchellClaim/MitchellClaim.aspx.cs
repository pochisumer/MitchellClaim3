using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using DO;
using BLLFactory;
using IType;
using System.Xml.Schema;
using System.Xml.Linq;
using System.ComponentModel;

namespace MitchellClaim
{
    public partial class MClaims : System.Web.UI.Page
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        //IMitchellClaimBLL objMitchellClaimBLL = MitchellClaimBLLFactory.getMitchellClaimBLLObject();        
        MitchellClaimType ClaimType = new MitchellClaimType();
        LossInfoType lossInfo = new LossInfoType();
        VehicleInfoType vehicleDetails = new VehicleInfoType();
        DataSet ds = new DataSet();
        List<MitchellClaimType> mitchellClaimTypeList = new List<MitchellClaimType>();
        List<LossInfoType> lossInfoTypeList = new List<LossInfoType>();
        List<VehicleInfoType> vehicleInfoTypeList = new List<VehicleInfoType>();

        protected void Page_Load(object sender, EventArgs e)
        {
            gvreadClaims.DataBind();
            repeater.DataBind();
        }

        protected int validXML(Label lbl, FileUpload fileupload)
        {
            int result = 0;
            string[] validFileTypes = { "xml" };
            string ext = System.IO.Path.GetExtension(fileupload.PostedFile.FileName);
            bool isValidFile = false;
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile)
            {
                lbl.Visible = true;

                lbl.ForeColor = System.Drawing.Color.Red;

                lbl.Text = "Invalid File. Please upload a File with extension " +

                string.Join(",", validFileTypes);
                result = 0;

            }
            else
            {
                result = 1;
            }
            return result;
        }

        protected void Import_Click(object sender, EventArgs e)
        {
            int isValid = validXML(lblErrorFileUpload, FileUpload);
            if (isValid == 1)
            {
                lblupdateClaimerror.Visible = false;
                string xmlFilePath = Path.GetFullPath(FileUpload.PostedFile.FileName);
                ds.ReadXml(xmlFilePath);
                for (int j = 0; j <= ds.Tables.Count - 1; j++)
                {
                    for (int i = 0; i <= ds.Tables[j].Rows.Count - 1; i++)
                    {
                        foreach (DataColumn column in ds.Tables[j].Columns)
                        {
                            ClaimType.ClaimNumber = ds.Tables[0].Rows[i]["ClaimNumber"].ToString();
                            ClaimType.ClaimantFirstName = ds.Tables[0].Rows[i]["ClaimantFirstName"].ToString();
                            ClaimType.ClaimantLastName = ds.Tables[0].Rows[i]["ClaimantLastName"].ToString();
                            string status = ds.Tables[0].Rows[i]["Status"].ToString();
                            ClaimType.Status = (StatusCode)Enum.Parse(typeof(StatusCode), status);
                            ClaimType.LossDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["LossDate"].ToString());
                            ClaimType.AssignedAdjusterID = Convert.ToInt64(ds.Tables[0].Rows[i]["AssignedAdjusterID"].ToString());

                            string causeOfLoss = ds.Tables[1].Rows[i]["CauseOfLoss"].ToString();
                            lossInfo.CauseOfLoss = (CauseOfLossCode)Enum.Parse(typeof(CauseOfLossCode), causeOfLoss);
                            lossInfo.ReportedDate = Convert.ToDateTime(ds.Tables[1].Rows[i]["ReportedDate"].ToString());
                            lossInfo.LossDescription = ds.Tables[1].Rows[i]["LossDescription"].ToString();
                            ClaimType.LossInfo = lossInfo;

                            vehicleDetails.Vin = ds.Tables[3].Rows[i]["Vin"].ToString();
                            vehicleDetails.ModelYear = Convert.ToInt32(ds.Tables[3].Rows[i]["ModelYear"].ToString());
                            vehicleDetails.MakeDescription = ds.Tables[3].Rows[i]["MakeDescription"].ToString();
                            vehicleDetails.ModelDescription = ds.Tables[3].Rows[i]["ModelDescription"].ToString();
                            vehicleDetails.EngineDescription = ds.Tables[3].Rows[i]["EngineDescription"].ToString();
                            vehicleDetails.ExteriorColor = ds.Tables[3].Rows[i]["ExteriorColor"].ToString();
                            vehicleDetails.LicPlate = ds.Tables[3].Rows[i]["LicPlate"].ToString();
                            vehicleDetails.LicPlateState = ds.Tables[3].Rows[i]["LicPlateState"].ToString();
                            vehicleDetails.LicPlateExpDate = Convert.ToDateTime(ds.Tables[3].Rows[i]["LicPlateExpDate"].ToString());
                            vehicleDetails.DamageDescription = ds.Tables[3].Rows[i]["DamageDescription"].ToString();
                            vehicleDetails.Mileage = Convert.ToInt32(ds.Tables[3].Rows[i]["Mileage"].ToString());
                        }
                    }
                }
                vehicleInfoTypeList.Add(vehicleDetails);
                ClaimType.Vehicles = vehicleInfoTypeList.ToArray();
                mitchellClaimTypeList.Add(ClaimType);
                int result = client.createClaim(mitchellClaimTypeList);

                if (result >= 1)
                {
                    lblErrorFileUpload.Visible = false;
                    CreateClaimlbl.Visible = true;
                    CreateClaimlbl.ForeColor = System.Drawing.Color.Green;
                    CreateClaimlbl.Text = "Claim Created Successfuly";
                }
                else
                {
                    CreateClaimlbl.Visible = false;
                    lblErrorFileUpload.Visible = true;
                    lblErrorFileUpload.ForeColor = System.Drawing.Color.Green;
                    lblErrorFileUpload.Text = "Claim Number already exists.";
                }
            }
        }

        protected void readclaimbtn_Click(object sender, EventArgs e)
        {
            ClaimType.ClaimNumber = readClaimtxtbx.Text;
            mitchellClaimTypeList = client.readClaim(ClaimType);
            gvreadClaims.Columns[0].Visible = false;
            if (mitchellClaimTypeList.Count >= 1)
            {
                nodatafounlblreadclaim.Visible = false;
                gvreadClaims.DataSource = mitchellClaimTypeList;
                gvreadClaims.DataBind();
            }
            else
            {
                nodatafounlblreadclaim.Visible = true;
                nodatafounlblreadclaim.Text = "No data found for the Claim Number entered";
            }

        }

        protected void dateRangeCheck_Click(object sender, EventArgs e)
        {
            gvreadClaims.Columns[0].Visible = true;
            DateTime startDate = Convert.ToDateTime(startingDatetxtbx.Text);
            DateTime endDate = Convert.ToDateTime(enddatetxtbx.Text);
            mitchellClaimTypeList = client.findClaimByDateRangeOfLossDate(startDate, endDate);
            if (mitchellClaimTypeList.Count >= 1)
            {
                noDateFoundlbldaterange.Visible = false;
                gvreadClaims.DataSource = mitchellClaimTypeList;
                gvreadClaims.DataBind();
            }
            else
            {
                noDateFoundlbldaterange.Visible = true;
                noDateFoundlbldaterange.Text = "No Data found within specific Date Range.";
            }
        }

        protected void readSpecificVehiclebtn_Click(object sender, EventArgs e)
        {
            ClaimType.ClaimNumber = specificVehicletxtbx.Text;
            vehicleInfoTypeList = client.readSpecificVehicle(ClaimType);
            if (vehicleInfoTypeList.Count >= 1)
            {
                nodatafoundreadspecificvehiclelbl.Visible = false;
                repeater.DataSource = vehicleInfoTypeList;
                repeater.DataBind();
            }
            else
            {
                nodatafoundreadspecificvehiclelbl.Visible = true;
                nodatafoundreadspecificvehiclelbl.Text = "No data found for the Claim Number entered";
            }

        }


        protected void deleteClaim_Click(object sender, EventArgs e)
        {
            claimDeleted.Visible = false;
            ClaimType.ClaimNumber = deleteClaimtxtbx.Text;
            int result = client.deleteClaim(ClaimType);
            if (result >= 1)
            {
                claimDeleted.ForeColor = System.Drawing.Color.Green;
                claimDeleted.Visible = true;
                claimDeleted.Text = "Specific claim has been deleted.";
            }
            else
            {
                claimDeleted.Visible = true;
                claimDeleted.Text = "No Claim Number Found.";
            }
        }

        protected void updateClaimbtn_Click(object sender, EventArgs e)
        {
            int isValidXML = validXML(lblupdateClaimerror, FileUpload1);
            if (isValidXML == 1)
            {
                lblErrorFileUpload.Visible = false;
                string xmlFilePath = Path.GetFullPath(FileUpload1.PostedFile.FileName);
                ds.ReadXml(xmlFilePath);
                for (int j = 0; j <= ds.Tables.Count - 1; j++)
                {
                    for (int i = 0; i <= ds.Tables[j].Rows.Count - 1; i++)
                    {
                        foreach (DataColumn column in ds.Tables[j].Columns)
                        {
                            if (column.ColumnName == "ClaimNumber")
                            {
                                ClaimType.ClaimNumber = ds.Tables[j].Rows[i]["ClaimNumber"].ToString();
                            }
                            else if (column.ColumnName == "ClaimantFirstName")
                            {
                                ClaimType.ClaimantFirstName = ds.Tables[j].Rows[i]["ClaimantFirstName"].ToString();
                            }
                            else if (column.ColumnName == "ClaimantLastName")
                            {
                                ClaimType.ClaimantLastName = ds.Tables[j].Rows[i]["ClaimantLastName"].ToString();
                            }
                            else if (column.ColumnName == "Status")
                            {
                                string status = ds.Tables[j].Rows[i]["Status"].ToString();
                                ClaimType.Status = (StatusCode)Enum.Parse(typeof(StatusCode), status);
                            }
                            else if (column.ColumnName == "LossDate")
                            {
                                ClaimType.LossDate = Convert.ToDateTime(ds.Tables[j].Rows[i]["LossDate"].ToString());
                            }
                            else if (column.ColumnName == "AssignedAdjusterID")
                            {
                                ClaimType.AssignedAdjusterID = Convert.ToInt64(ds.Tables[j].Rows[i]["AssignedAdjusterID"].ToString());
                            }
                            else if (column.ColumnName == "CauseOfLoss")
                            {
                                string causeOfLoss = ds.Tables[j].Rows[i]["CauseOfLoss"].ToString();
                                lossInfo.CauseOfLoss = (CauseOfLossCode)Enum.Parse(typeof(CauseOfLossCode), causeOfLoss);
                            }
                            else if (column.ColumnName == "ReportedDate")
                            {
                                lossInfo.ReportedDate = Convert.ToDateTime(ds.Tables[j].Rows[i]["ReportedDate"].ToString());
                                if (lossInfo.ReportedDate == null)
                                {
                                    DateTime.ParseExact(lossInfo.ReportedDate.ToString(), "yyyy-mm-dd", null);
                                }
                            }
                            else if (column.ColumnName == "LossDescription")
                            {
                                lossInfo.LossDescription = ds.Tables[j].Rows[i]["LossDescription"].ToString();
                            }
                            else if (column.ColumnName == "Vin")
                            {
                                vehicleDetails.Vin = ds.Tables[j].Rows[i]["Vin"].ToString();
                            }
                            else if (column.ColumnName == "ModelYear")
                            {
                                vehicleDetails.ModelYear = Convert.ToInt32(ds.Tables[j].Rows[i]["ModelYear"].ToString());
                            }
                            else if (column.ColumnName == "MakeDescription")
                            {
                                vehicleDetails.MakeDescription = ds.Tables[j].Rows[i]["MakeDescription"].ToString();
                            }
                            else if (column.ColumnName == "ModelDescription")
                            {
                                vehicleDetails.ModelDescription = ds.Tables[j].Rows[i]["ModelDescription"].ToString();
                            }
                            else if (column.ColumnName == "EngineDescription")
                            {
                                vehicleDetails.EngineDescription = ds.Tables[j].Rows[i]["EngineDescription"].ToString();
                            }
                            else if (column.ColumnName == "ExteriorColor")
                            {
                                vehicleDetails.ExteriorColor = ds.Tables[j].Rows[i]["ExteriorColor"].ToString();
                            }
                            else if (column.ColumnName == "LicPlate")
                            {
                                vehicleDetails.LicPlate = ds.Tables[j].Rows[i]["LicPlate"].ToString();
                            }
                            else if (column.ColumnName == "LicPlateState")
                            {
                                vehicleDetails.LicPlateState = ds.Tables[j].Rows[i]["LicPlateState"].ToString();
                            }
                            else if (column.ColumnName == "LicPlateExpDate")
                            {
                                vehicleDetails.LicPlateExpDate = Convert.ToDateTime(ds.Tables[j].Rows[i]["LicPlateExpDate"].ToString());
                                if (vehicleDetails.LicPlateExpDate == null)
                                {
                                    DateTime.ParseExact(vehicleDetails.LicPlateExpDate.ToString(), "yyyy-mm-dd", null);
                                }
                            }
                            else if (column.ColumnName == "DamageDescription")
                            {
                                vehicleDetails.DamageDescription = ds.Tables[j].Rows[i]["DamageDescription"].ToString();
                            }
                            else if (column.ColumnName == "Mileage")
                            {
                                vehicleDetails.Mileage = Convert.ToInt32(ds.Tables[j].Rows[i]["Mileage"].ToString());
                            }
                        }
                    }
                }
                ClaimType.LossInfo = lossInfo;
                vehicleInfoTypeList.Add(vehicleDetails);
                ClaimType.Vehicles = vehicleInfoTypeList.ToArray();
                mitchellClaimTypeList.Add(ClaimType);
                int result = client.updateClaim(mitchellClaimTypeList);
                if (result >= 1)
                {

                    CreateClaimlbl.Visible = false;
                    lblupdateClaimerror.Visible = false;
                    updateClaimSuccessful.Visible = true;
                    updateClaimSuccessful.ForeColor = System.Drawing.Color.Green;
                    updateClaimSuccessful.Text = "Claim updated Successfuly";
                }
            }
        }
    }
}
