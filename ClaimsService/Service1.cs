using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using DO;
using BLLFactory;
using IType;

namespace ClaimsService
{
    public class Service1 : IService1
    {
        IMitchellClaimBLL objMitchellClaimBLL = MitchellClaimBLLFactory.getMitchellClaimBLLObject();
        public int createClaim(List<MitchellClaimType> createClaimobjDO)
        {
            return objMitchellClaimBLL.createClaim(createClaimobjDO);
        }

        public List<MitchellClaimType> readClaim(MitchellClaimType readClaimobjDO)
        {
            return objMitchellClaimBLL.readClaim(readClaimobjDO);
        }

        public List<MitchellClaimType> findClaimByDateRangeOfLossDate(DateTime startDate, DateTime endDate)
        {
            return objMitchellClaimBLL.findClaimByDateRangeOfLossDate(startDate, endDate);
        }

        public List<VehicleInfoType> readSpecificVehicle(MitchellClaimType readSpecificVehicleobjDO)
        {
            return objMitchellClaimBLL.readSpecificVehicle(readSpecificVehicleobjDO);
        }

        public int deleteClaim(MitchellClaimType deleteClaimobjDO)
        {
            return objMitchellClaimBLL.deleteClaim(deleteClaimobjDO);
        }

        public int updateClaim(List<MitchellClaimType> updateClaimobjDO)
        {
            return objMitchellClaimBLL.updateClaim(updateClaimobjDO);
        }
    }
}
