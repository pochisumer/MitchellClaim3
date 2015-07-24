using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using System.Data;

namespace IType
{
    public interface IMitchellClaimDAL
    {
        int createClaim(MitchellClaimType createClaimobjDO);
        DataTable readClaim(MitchellClaimType readClaimobjDO);
        DataTable findClaimByDateRangeOfLossDate(DateTime startDate, DateTime endDate);
        DataTable readSpecificVehicle(MitchellClaimType readSpecificVehicleobjDO);
        int deleteClaim(MitchellClaimType deleteClaimobjDO);
        int updateClaim(MitchellClaimType updateClaimobjDO);
    }
}
