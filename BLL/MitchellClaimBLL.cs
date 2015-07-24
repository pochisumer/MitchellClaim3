using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IType;
using DO;
using DALFactory;
using System.Collections;
using System.Data;
namespace BLL
{
    public class MitchellClaimBLL : IMitchellClaimBLL
    {
        IMitchellClaimDAL objMitchellClaimDAL = MitchellClaimDALFactory.getMitchellClaimDALObject();
        List<MitchellClaimType> collection = new List<MitchellClaimType>();
        List<VehicleInfoType> vehicleInfoTypeList = new List<VehicleInfoType>();
        MitchellClaimType ClaimType = new MitchellClaimType();
        LossInfoType lossInfo = new LossInfoType();
        VehicleInfoType vehicleDetails = new VehicleInfoType();

        public int createClaim(List<MitchellClaimType> createClaimobjDO)
        {
            int result = 0;
            foreach (MitchellClaimType cresteClaimobjdO in createClaimobjDO)
            {
                result = objMitchellClaimDAL.createClaim(cresteClaimobjdO);
            }
            return result;
        }

        public List<MitchellClaimType> readClaim(MitchellClaimType readClaimobjDO)
        {
            DataTable dt = objMitchellClaimDAL.readClaim(readClaimobjDO);

            if (dt.Rows.Count >= 1)
            {
                ClaimType.ClaimantFirstName = dt.Rows[0]["ClaimantFirstName"].ToString();
                ClaimType.ClaimantLastName = dt.Rows[0]["ClaimantLastName"].ToString();
                string status = dt.Rows[0]["Status"].ToString();
                ClaimType.Status = (StatusCode)Enum.Parse(typeof(StatusCode), status);
                ClaimType.LossDate = Convert.ToDateTime(dt.Rows[0]["LossDate"].ToString());
                ClaimType.AssignedAdjusterID = Convert.ToInt64(dt.Rows[0]["AssignedAdjusterID"].ToString());

                string causeOfLoss = dt.Rows[0]["CauseOfLoss"].ToString();
                lossInfo.CauseOfLoss = (CauseOfLossCode)Enum.Parse(typeof(CauseOfLossCode), causeOfLoss);
                lossInfo.ReportedDate = Convert.ToDateTime(dt.Rows[0]["ReportedDate"].ToString());
                lossInfo.LossDescription = dt.Rows[0]["LossDescription"].ToString();
                ClaimType.LossInfo = lossInfo;

                vehicleDetails.Vin = dt.Rows[0]["Vin"].ToString();
                vehicleDetails.ModelYear = Convert.ToInt32(dt.Rows[0]["ModelYear"].ToString());
                vehicleDetails.MakeDescription = dt.Rows[0]["MakeDescription"].ToString();
                vehicleDetails.ModelDescription = dt.Rows[0]["ModelDescription"].ToString();
                vehicleDetails.EngineDescription = dt.Rows[0]["EngineDescription"].ToString();
                vehicleDetails.ExteriorColor = dt.Rows[0]["ExteriorColor"].ToString();
                vehicleDetails.LicPlate = dt.Rows[0]["LicPlate"].ToString();
                vehicleDetails.LicPlateState = dt.Rows[0]["LicPlateState"].ToString();
                vehicleDetails.LicPlateExpDate = Convert.ToDateTime(dt.Rows[0]["LicPlateExpDate"].ToString());
                vehicleDetails.DamageDescription = dt.Rows[0]["DamageDescription"].ToString();
                vehicleDetails.Mileage = Convert.ToInt32(dt.Rows[0]["Mileage"].ToString());
                vehicleInfoTypeList.Add(vehicleDetails);
                ClaimType.Vehicles = vehicleInfoTypeList.ToArray();
                collection.Add(ClaimType);
            }
            return collection;
        }

        public List<MitchellClaimType> findClaimByDateRangeOfLossDate(DateTime startDate, DateTime endDate)
        {
            DataTable dt = objMitchellClaimDAL.findClaimByDateRangeOfLossDate(startDate, endDate);
            if (dt.Rows.Count >= 1)
            {
                ClaimType.ClaimNumber = dt.Rows[0]["ClaimNumber"].ToString().Trim();
                ClaimType.ClaimantFirstName = dt.Rows[0]["ClaimantFirstName"].ToString();
                ClaimType.ClaimantLastName = dt.Rows[0]["ClaimantLastName"].ToString();
                string status = dt.Rows[0]["Status"].ToString();
                ClaimType.Status = (StatusCode)Enum.Parse(typeof(StatusCode), status);
                ClaimType.LossDate = Convert.ToDateTime(dt.Rows[0]["LossDate"].ToString());
                ClaimType.AssignedAdjusterID = Convert.ToInt64(dt.Rows[0]["AssignedAdjusterID"].ToString());

                string causeOfLoss = dt.Rows[0]["CauseOfLoss"].ToString();
                lossInfo.CauseOfLoss = (CauseOfLossCode)Enum.Parse(typeof(CauseOfLossCode), causeOfLoss);
                lossInfo.ReportedDate = Convert.ToDateTime(dt.Rows[0]["ReportedDate"].ToString());
                lossInfo.LossDescription = dt.Rows[0]["LossDescription"].ToString();
                ClaimType.LossInfo = lossInfo;

                vehicleDetails.Vin = dt.Rows[0]["Vin"].ToString();
                vehicleDetails.ModelYear = Convert.ToInt32(dt.Rows[0]["ModelYear"].ToString());
                vehicleDetails.MakeDescription = dt.Rows[0]["MakeDescription"].ToString();
                vehicleDetails.ModelDescription = dt.Rows[0]["ModelDescription"].ToString();
                vehicleDetails.EngineDescription = dt.Rows[0]["EngineDescription"].ToString();
                vehicleDetails.ExteriorColor = dt.Rows[0]["ExteriorColor"].ToString();
                vehicleDetails.LicPlate = dt.Rows[0]["LicPlate"].ToString();
                vehicleDetails.LicPlateState = dt.Rows[0]["LicPlateState"].ToString();
                vehicleDetails.LicPlateExpDate = Convert.ToDateTime(dt.Rows[0]["LicPlateExpDate"].ToString());
                vehicleDetails.DamageDescription = dt.Rows[0]["DamageDescription"].ToString();
                vehicleDetails.Mileage = Convert.ToInt32(dt.Rows[0]["Mileage"].ToString());
                vehicleInfoTypeList.Add(vehicleDetails);
                ClaimType.Vehicles = vehicleInfoTypeList.ToArray();
                collection.Add(ClaimType);
            }
            return collection;
        }

        public List<VehicleInfoType> readSpecificVehicle(MitchellClaimType readSpecificVehicleobjDO)
        {
            DataTable dt = objMitchellClaimDAL.readSpecificVehicle(readSpecificVehicleobjDO);
            if (dt.Rows.Count >= 1)
            {
                vehicleDetails.Vin = dt.Rows[0]["Vin"].ToString();
                vehicleDetails.ModelYear = Convert.ToInt32(dt.Rows[0]["ModelYear"].ToString());
                vehicleDetails.MakeDescription = dt.Rows[0]["MakeDescription"].ToString();
                vehicleDetails.ModelDescription = dt.Rows[0]["ModelDescription"].ToString();
                vehicleDetails.EngineDescription = dt.Rows[0]["EngineDescription"].ToString();
                vehicleDetails.ExteriorColor = dt.Rows[0]["ExteriorColor"].ToString();
                vehicleDetails.LicPlate = dt.Rows[0]["LicPlate"].ToString();
                vehicleDetails.LicPlateState = dt.Rows[0]["LicPlateState"].ToString();
                vehicleDetails.LicPlateExpDate = Convert.ToDateTime(dt.Rows[0]["LicPlateExpDate"].ToString());
                vehicleDetails.DamageDescription = dt.Rows[0]["DamageDescription"].ToString();
                vehicleDetails.Mileage = Convert.ToInt32(dt.Rows[0]["Mileage"].ToString());

                vehicleInfoTypeList.Add(vehicleDetails);
            }
            return vehicleInfoTypeList;

        }

        public int deleteClaim(MitchellClaimType deleteClaimobjDO)
        {
            int result = objMitchellClaimDAL.deleteClaim(deleteClaimobjDO);
            return result;
        }

        public int updateClaim(List<MitchellClaimType> updateClaimobjDO)
        {
            int result = 0;

            foreach (MitchellClaimType updateClaimobjdO in updateClaimobjDO)
            {
                result = objMitchellClaimDAL.updateClaim(updateClaimobjdO);
            }
            return result;
        }
    }
}



