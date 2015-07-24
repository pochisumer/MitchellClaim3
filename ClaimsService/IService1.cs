using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DO;
using System.Data;

namespace ClaimsService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int createClaim(List<MitchellClaimType> createClaimobjDO);

        [OperationContract]
        List<MitchellClaimType> readClaim(MitchellClaimType readClaimobjDO);

        [OperationContract]
        List<MitchellClaimType> findClaimByDateRangeOfLossDate(DateTime startDate, DateTime endDate);

        [OperationContract]
        List<VehicleInfoType> readSpecificVehicle(MitchellClaimType readSpecificVehicleobjDO);

        [OperationContract]
        int deleteClaim(MitchellClaimType deleteClaimobjDO);

        [OperationContract]
        int updateClaim(List<MitchellClaimType> updateClaimobjDO);

    }
}
