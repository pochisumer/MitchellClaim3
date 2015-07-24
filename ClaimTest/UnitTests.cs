using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLLFactory;
using DO;
using IType;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;

namespace ClaimTest
{
    [TestClass]
    public class MitchellClaimTests
    {
        IMitchellClaimBLL objIMitchellClaimBLL = MitchellClaimBLLFactory.getMitchellClaimBLLObject();
        MitchellClaimType ClaimType = new MitchellClaimType();
        LossInfoType lossInfo = new LossInfoType();
        VehicleInfoType vehicleDetails = new VehicleInfoType();

        [TestMethod]
        public void createClaim()
        {
            List<VehicleInfoType> vehicleInfoTypeList = new List<VehicleInfoType>();
            List<MitchellClaimType> MitchellInfoList = new List<MitchellClaimType>();
            ClaimType.ClaimNumber = "22c9c23bac142856018ce14a26b6c299";
            ClaimType.ClaimantFirstName = "George";
            ClaimType.ClaimantLastName = "Washington";
            string status = "OPEN";
            ClaimType.Status = (StatusCode)Enum.Parse(typeof(StatusCode), status);
            ClaimType.LossDate = Convert.ToDateTime("2014-07-09T17:19:13.631-07:00");
            ClaimType.AssignedAdjusterID = Convert.ToInt64("12345");
            string causeOfLoss = "Collision";
            lossInfo.CauseOfLoss = (CauseOfLossCode)Enum.Parse(typeof(CauseOfLossCode), causeOfLoss);
            lossInfo.ReportedDate = Convert.ToDateTime("2014-07-10T17:19:13.676-07:00");
            lossInfo.LossDescription = "Crashed into an apple tree.";
            ClaimType.LossInfo = lossInfo;
            vehicleDetails.Vin = "1M8GDM9AXKP042788";
            vehicleDetails.ModelYear = Convert.ToInt32("2015");
            vehicleDetails.MakeDescription = "Ford";
            vehicleDetails.ModelDescription = "Mustang";
            vehicleDetails.EngineDescription = "EcoBoost";
            vehicleDetails.ExteriorColor = "Deep Impact Blue";
            vehicleDetails.LicPlate = "NO1PRES";
            vehicleDetails.LicPlateState = "VA";
            vehicleDetails.LicPlateExpDate = Convert.ToDateTime("2015-03-10-07:00");
            vehicleDetails.DamageDescription = "Front end smashed in. Apple dents in roof.";
            vehicleDetails.Mileage = Convert.ToInt32("1776");
            vehicleInfoTypeList.Add(vehicleDetails);
            ClaimType.Vehicles = vehicleInfoTypeList.ToArray();
            MitchellInfoList.Add(ClaimType);
            int result = objIMitchellClaimBLL.createClaim(MitchellInfoList);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void readClaim()
        {
            List<VehicleInfoType> vehicleInfoTypeList = new List<VehicleInfoType>();
            List<MitchellClaimType> expectedMitchellInfoList = new List<MitchellClaimType>();
            List<MitchellClaimType> actualMitchellInfoList = new List<MitchellClaimType>();

            ClaimType.ClaimNumber = null;
            ClaimType.ClaimantFirstName = "George";
            ClaimType.ClaimantLastName = "Washington";
            string status = "OPEN";
            ClaimType.Status = (StatusCode)Enum.Parse(typeof(StatusCode), status);
            ClaimType.LossDate = Convert.ToDateTime("2014-07-09T17:19:13.631-07:00");
            ClaimType.AssignedAdjusterID = Convert.ToInt64("12345");

            string causeOfLoss = "Collision";
            lossInfo.CauseOfLoss = (CauseOfLossCode)Enum.Parse(typeof(CauseOfLossCode), causeOfLoss);
            lossInfo.ReportedDate = Convert.ToDateTime("2014-07-10T17:19:13.676-07:00");
            lossInfo.LossDescription = "Crashed into an apple tree.";
            ClaimType.LossInfo = lossInfo;

            vehicleDetails.Vin = "1M8GDM9AXKP042788";
            vehicleDetails.ModelYear = Convert.ToInt32("2015");
            vehicleDetails.MakeDescription = "Ford";
            vehicleDetails.ModelDescription = "Mustang";
            vehicleDetails.EngineDescription = "EcoBoost";
            vehicleDetails.ExteriorColor = "Deep Impact Blue";
            vehicleDetails.LicPlate = "NO1PRES";
            vehicleDetails.LicPlateState = "VA";
            vehicleDetails.LicPlateExpDate = Convert.ToDateTime("2015-03-10-07:00");
            vehicleDetails.DamageDescription = "Front end smashed in. Apple dents in roof.";
            vehicleDetails.Mileage = Convert.ToInt32("1776");
            vehicleInfoTypeList.Add(vehicleDetails);
            ClaimType.Vehicles = vehicleInfoTypeList.ToArray();
            expectedMitchellInfoList.Add(ClaimType);

            MitchellClaimType claimTypeDO = new MitchellClaimType();
            claimTypeDO.ClaimNumber = "22c9c23bac142856018ce14a26b6c299";
            actualMitchellInfoList = objIMitchellClaimBLL.readClaim(claimTypeDO);
            MitchellClaimType claim = actualMitchellInfoList.ElementAt(0);
            Equals(ClaimType, claim);
        }

        [TestMethod]
        public void findClaimByDateRangeOfLossDate()
        {
            List<VehicleInfoType> vehicleInfoTypeList = new List<VehicleInfoType>();
            List<MitchellClaimType> expectedMitchellInfoList = new List<MitchellClaimType>();
            List<MitchellClaimType> actualMitchellInfoList = new List<MitchellClaimType>();

            ClaimType.ClaimNumber = "22c9c23bac142856018ce14a26b6c299";
            ClaimType.ClaimantFirstName = "George";
            ClaimType.ClaimantLastName = "Washington";
            string status = "OPEN";
            ClaimType.Status = (StatusCode)Enum.Parse(typeof(StatusCode), status);
            ClaimType.LossDate = Convert.ToDateTime("2014-07-09T17:19:13.631-07:00");
            ClaimType.AssignedAdjusterID = Convert.ToInt64("12345");

            string causeOfLoss = "Collision";
            lossInfo.CauseOfLoss = (CauseOfLossCode)Enum.Parse(typeof(CauseOfLossCode), causeOfLoss);
            lossInfo.ReportedDate = Convert.ToDateTime("2014-07-10T17:19:13.676-07:00");
            lossInfo.LossDescription = "Crashed into an apple tree.";
            ClaimType.LossInfo = lossInfo;

            vehicleDetails.Vin = "1M8GDM9AXKP042788";
            vehicleDetails.ModelYear = Convert.ToInt32("2015");
            vehicleDetails.MakeDescription = "Ford";
            vehicleDetails.ModelDescription = "Mustang";
            vehicleDetails.EngineDescription = "EcoBoost";
            vehicleDetails.ExteriorColor = "Deep Impact Blue";
            vehicleDetails.LicPlate = "NO1PRES";
            vehicleDetails.LicPlateState = "VA";
            vehicleDetails.LicPlateExpDate = Convert.ToDateTime("2015-03-10-07:00");
            vehicleDetails.DamageDescription = "Front end smashed in. Apple dents in roof.";
            vehicleDetails.Mileage = Convert.ToInt32("1776");
            vehicleInfoTypeList.Add(vehicleDetails);
            ClaimType.Vehicles = vehicleInfoTypeList.ToArray();
            expectedMitchellInfoList.Add(ClaimType);

            DateTime startDate = Convert.ToDateTime("2014-07-01T17:19:13.631-07:00");
            DateTime endDate = Convert.ToDateTime("2014-07-15T17:19:13.631-07:00");
            actualMitchellInfoList = objIMitchellClaimBLL.findClaimByDateRangeOfLossDate(startDate, endDate);
            MitchellClaimType claim = actualMitchellInfoList.ElementAt(0);
            Equals(ClaimType, claim);
        }

        [TestMethod]
        public void readSpecificVehicle()
        {
            List<VehicleInfoType> actualvehicleInfoList = new List<VehicleInfoType>();
            vehicleDetails.Vin = "1M8GDM9AXKP042788";
            vehicleDetails.ModelYear = Convert.ToInt32("2015");
            vehicleDetails.MakeDescription = "Ford";
            vehicleDetails.ModelDescription = "Mustang";
            vehicleDetails.EngineDescription = "EcoBoost";
            vehicleDetails.ExteriorColor = "Deep Impact Blue";
            vehicleDetails.LicPlate = "NO1PRES";
            vehicleDetails.LicPlateState = "VA";
            vehicleDetails.LicPlateExpDate = Convert.ToDateTime("2015-03-10-07:00");
            vehicleDetails.DamageDescription = "Front end smashed in. Apple dents in roof.";
            vehicleDetails.Mileage = Convert.ToInt32("1776");
            MitchellClaimType claimTypeDO = new MitchellClaimType();
            claimTypeDO.ClaimNumber = "22c9c23bac142856018ce14a26b6c299";
            actualvehicleInfoList = objIMitchellClaimBLL.readSpecificVehicle(claimTypeDO);
            VehicleInfoType vehicle = actualvehicleInfoList.ElementAt(0);
            Equals(vehicleDetails, vehicle);
        }

        [TestMethod]
        public void deleteClaim()
        {
            MitchellClaimType claimTypeDO = new MitchellClaimType();
            claimTypeDO.ClaimNumber = "22c9c23bac142856018ce14a26b6c299";
            int result = objIMitchellClaimBLL.deleteClaim(claimTypeDO);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void updateClaim()
        {
            List<VehicleInfoType> vehicleInfoTypeList = new List<VehicleInfoType>();
            List<MitchellClaimType> MitchellClaimTypeList = new List<MitchellClaimType>();
            ClaimType.ClaimNumber = "22c9c23bac142856018ce14a26b6c299";
            ClaimType.AssignedAdjusterID = Convert.ToInt64("67890");
            vehicleDetails.Vin = "1M8GDM9AXKP042788";
            vehicleDetails.ExteriorColor = "Competition Orange";
            vehicleDetails.LicPlateExpDate = Convert.ToDateTime("2015-04-15-07:00");
            vehicleInfoTypeList.Add(vehicleDetails);
            ClaimType.Vehicles = vehicleInfoTypeList.ToArray();
            ClaimType.LossInfo = lossInfo;
            MitchellClaimTypeList.Add(ClaimType);
            int result = objIMitchellClaimBLL.updateClaim(MitchellClaimTypeList);
            Assert.AreEqual(3, result);
        }

        private void Equals(MitchellClaimType obj1, MitchellClaimType obj2)
        {
            Assert.AreEqual(obj1.ClaimNumber, obj2.ClaimNumber);
            Assert.AreEqual(obj1.ClaimantFirstName.Trim(), obj2.ClaimantFirstName.Trim());
            Assert.AreEqual(obj1.ClaimantLastName.Trim(), obj2.ClaimantLastName.Trim());
            Assert.AreEqual(obj1.Status, obj2.Status);
            Assert.AreEqual(obj1.LossDate.ToShortDateString(), obj2.LossDate.ToShortDateString());
            Assert.AreEqual(obj1.AssignedAdjusterID, obj2.AssignedAdjusterID);
            Assert.AreEqual(obj1.LossInfo.CauseOfLoss, obj2.LossInfo.CauseOfLoss);
            Assert.AreEqual(obj1.LossInfo.ReportedDate.ToShortDateString(), obj2.LossInfo.ReportedDate.ToShortDateString());
            Assert.AreEqual(obj1.LossInfo.LossDescription.Trim(), obj2.LossInfo.LossDescription.Trim());
            Assert.AreEqual(obj1.Vehicles[0].Vin.Trim(), obj2.Vehicles[0].Vin.Trim());
            Assert.AreEqual(obj1.Vehicles[0].ModelYear, obj2.Vehicles[0].ModelYear);
            Assert.AreEqual(obj1.Vehicles[0].MakeDescription.Trim(), obj2.Vehicles[0].MakeDescription.Trim());
            Assert.AreEqual(obj1.Vehicles[0].ModelDescription.Trim(), obj2.Vehicles[0].ModelDescription.Trim());
            Assert.AreEqual(obj1.Vehicles[0].EngineDescription.Trim(), obj2.Vehicles[0].EngineDescription.Trim());
            Assert.AreEqual(obj1.Vehicles[0].ExteriorColor.Trim(), obj2.Vehicles[0].ExteriorColor.Trim());
            Assert.AreEqual(obj1.Vehicles[0].LicPlate.Trim(), obj2.Vehicles[0].LicPlate.Trim());
            Assert.AreEqual(obj1.Vehicles[0].LicPlateState.Trim(), obj2.Vehicles[0].LicPlateState.Trim());
            Assert.AreEqual(obj1.Vehicles[0].LicPlateExpDate.ToShortDateString(), obj2.Vehicles[0].LicPlateExpDate.ToShortDateString());
            Assert.AreEqual(obj1.Vehicles[0].DamageDescription.Trim(), obj2.Vehicles[0].DamageDescription.Trim());
            Assert.AreEqual(obj1.Vehicles[0].Mileage, obj2.Vehicles[0].Mileage);
        }
    }
}
