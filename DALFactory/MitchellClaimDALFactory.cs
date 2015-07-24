using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IType;
using DAL;


namespace DALFactory
{
    public class MitchellClaimDALFactory
    {
        public static IMitchellClaimDAL getMitchellClaimDALObject()
        {
            IMitchellClaimDAL objMitchellClaimDAL = new MitchellClaimDAL();
            return objMitchellClaimDAL;

        }
    }
}
