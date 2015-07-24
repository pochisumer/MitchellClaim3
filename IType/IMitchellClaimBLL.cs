using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using System.Data;


namespace IType
{
    public interface IMitchellClaimBLL
    {
        int createClaim(List<MitchellClaimType> createClaimobjDO);
        List<MitchellClaimType> readClaim(MitchellClaimType readClaimobjDO);
        List<MitchellClaimType> findClaimByDateRangeOfLossDate(DateTime startDate, DateTime endDate);
        List<VehicleInfoType> readSpecificVehicle(MitchellClaimType readSpecificVehicleobjDO);
        int deleteClaim(MitchellClaimType deleteClaimobjDO);
        int updateClaim(List<MitchellClaimType> updateClaimobjDO);
    }
}
