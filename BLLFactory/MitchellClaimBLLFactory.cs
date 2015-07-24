using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IType;
using BLL;

namespace BLLFactory
{
    public class MitchellClaimBLLFactory
    {
        public static IMitchellClaimBLL getMitchellClaimBLLObject()
        {
            IMitchellClaimBLL objMitchellClaim = new MitchellClaimBLL();
            return objMitchellClaim;
        }
    }
}
