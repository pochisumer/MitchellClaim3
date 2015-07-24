using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IType;
using DO;
using System.Data.SqlClient;
using System.Data;
using System.Xml;


namespace DAL
{
    public class MitchellClaimDAL : IMitchellClaimDAL
    {
        DatabaseConnection connection;

        public MitchellClaimDAL()
        {
            connection = new DatabaseConnection();
        }

        public int createClaim(MitchellClaimType createClaimobjDO)
        {
            SqlParameter[] parameters = new SqlParameter[20];
            parameters[0] = new SqlParameter("@ClaimNumber", createClaimobjDO.ClaimNumber);
            parameters[1] = new SqlParameter("@ClaimantFirstName", createClaimobjDO.ClaimantFirstName);
            parameters[2] = new SqlParameter("@ClaimantLastName", createClaimobjDO.ClaimantLastName);
            parameters[3] = new SqlParameter("@Status", createClaimobjDO.Status.ToString());
            parameters[4] = new SqlParameter("@LossDate", createClaimobjDO.LossDate.ToString());
            parameters[5] = new SqlParameter("@AssignedAdjusterID", createClaimobjDO.AssignedAdjusterID);

            parameters[6] = new SqlParameter("@CauseOfLoss", createClaimobjDO.LossInfo.CauseOfLoss.ToString());
            parameters[7] = new SqlParameter("@ReportedDate", createClaimobjDO.LossInfo.ReportedDate.ToString());
            parameters[8] = new SqlParameter("@LossDescription", createClaimobjDO.LossInfo.LossDescription);

            parameters[9] = new SqlParameter("@Vin", createClaimobjDO.Vehicles[0].Vin);
            parameters[10] = new SqlParameter("@ModelYear", createClaimobjDO.Vehicles[0].ModelYear);
            parameters[11] = new SqlParameter("@MakeDescription", createClaimobjDO.Vehicles[0].MakeDescription);
            parameters[12] = new SqlParameter("@ModelDescription", createClaimobjDO.Vehicles[0].ModelDescription);
            parameters[13] = new SqlParameter("@EngineDescription", createClaimobjDO.Vehicles[0].EngineDescription);
            parameters[14] = new SqlParameter("@ExteriorColor", createClaimobjDO.Vehicles[0].ExteriorColor);
            parameters[15] = new SqlParameter("@LicPlate", createClaimobjDO.Vehicles[0].LicPlate);
            parameters[16] = new SqlParameter("@LicPlateState", createClaimobjDO.Vehicles[0].LicPlateState);
            parameters[17] = new SqlParameter("@LicPlateExpDate", createClaimobjDO.Vehicles[0].LicPlateExpDate.ToString());
            parameters[18] = new SqlParameter("@DamageDescription", createClaimobjDO.Vehicles[0].DamageDescription);
            parameters[19] = new SqlParameter("@Mileage", createClaimobjDO.Vehicles[0].Mileage);
            foreach (SqlParameter p in parameters)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }
            return connection.ExecuteNonQuery("spi_createClaim", parameters);
        }

        public DataTable readClaim(MitchellClaimType readClaimobjDO)
        {
            SqlParameter[] paramaters = new SqlParameter[1];
            paramaters[0] = new SqlParameter("@claimNumber", readClaimobjDO.ClaimNumber);
            return connection.ExecuteReader("sps_readClaim", paramaters);
        }

        public DataTable findClaimByDateRangeOfLossDate(DateTime startDate, DateTime endDate)
        {
            SqlParameter[] paramaters = new SqlParameter[2];
            paramaters[0] = new SqlParameter("@startDate", startDate);
            paramaters[1] = new SqlParameter("@endDate", endDate);
            return connection.ExecuteReader("sps_findClaimByDateRangeOfLossDate", paramaters);
        }

        public DataTable readSpecificVehicle(MitchellClaimType readSpecificVehicleobjDO)
        {
            SqlParameter[] paramaters = new SqlParameter[1];
            paramaters[0] = new SqlParameter("@claimNumber", readSpecificVehicleobjDO.ClaimNumber);
            return connection.ExecuteReader("sps_readSpecificVehicle", paramaters);
        }

        public int deleteClaim(MitchellClaimType deleteClaimobjDO)
        {
            SqlParameter[] paramaters = new SqlParameter[1];
            paramaters[0] = new SqlParameter("@claimNumber", deleteClaimobjDO.ClaimNumber);
            return connection.ExecuteNonQuery("sps_deleteClaim", paramaters);
        }

        public int updateClaim(MitchellClaimType updateClaimobjDO)
        {
            SqlParameter[] parameters = new SqlParameter[20];
            parameters[0] = new SqlParameter("@ClaimNumber", updateClaimobjDO.ClaimNumber);
            parameters[1] = new SqlParameter("@ClaimantFirstName", updateClaimobjDO.ClaimantFirstName);
            parameters[2] = new SqlParameter("@ClaimantLastName", updateClaimobjDO.ClaimantLastName);
            parameters[3] = new SqlParameter("@Status", updateClaimobjDO.Status.ToString());
            if (updateClaimobjDO.LossDate == DateTime.MinValue)
            {
                parameters[4] = new SqlParameter("@LossDate", DBNull.Value);
            }
            else
            {
                parameters[4] = new SqlParameter("@LossDate", updateClaimobjDO.LossDate);
            }
            parameters[5] = new SqlParameter("@AssignedAdjusterID", updateClaimobjDO.AssignedAdjusterID);
            parameters[6] = new SqlParameter("@CauseOfLoss", updateClaimobjDO.LossInfo.CauseOfLoss.ToString());
            if (updateClaimobjDO.LossInfo.ReportedDate == DateTime.MinValue)
            {
                parameters[7] = new SqlParameter("@ReportedDate", DBNull.Value);
            }
            else
            {
                parameters[7] = new SqlParameter("@ReportedDate", updateClaimobjDO.LossInfo.ReportedDate);
            }
            parameters[8] = new SqlParameter("@LossDescription", updateClaimobjDO.LossInfo.LossDescription);

            parameters[9] = new SqlParameter("@Vin", updateClaimobjDO.Vehicles[0].Vin);
            if (updateClaimobjDO.Vehicles[0].ModelYear == 0)
            {
                parameters[10] = new SqlParameter("@ModelYear", null);

            }
            else
            {
                parameters[10] = new SqlParameter("@ModelYear", updateClaimobjDO.Vehicles[0].ModelYear);

            }
            parameters[11] = new SqlParameter("@MakeDescription", updateClaimobjDO.Vehicles[0].MakeDescription);
            parameters[12] = new SqlParameter("@ModelDescription", updateClaimobjDO.Vehicles[0].ModelDescription);
            parameters[13] = new SqlParameter("@EngineDescription", updateClaimobjDO.Vehicles[0].EngineDescription);
            parameters[14] = new SqlParameter("@ExteriorColor", updateClaimobjDO.Vehicles[0].ExteriorColor);
            parameters[15] = new SqlParameter("@LicPlate", updateClaimobjDO.Vehicles[0].LicPlate);
            parameters[16] = new SqlParameter("@LicPlateState", updateClaimobjDO.Vehicles[0].LicPlateState);
            if (updateClaimobjDO.Vehicles[0].LicPlateExpDate == DateTime.MinValue)
            {
                parameters[17] = new SqlParameter("@LicPlateExpDate", DBNull.Value);
            }
            else
            {
                parameters[17] = new SqlParameter("@LicPlateExpDate", updateClaimobjDO.Vehicles[0].LicPlateExpDate);
            }
            parameters[18] = new SqlParameter("@DamageDescription", updateClaimobjDO.Vehicles[0].DamageDescription);
            if (updateClaimobjDO.Vehicles[0].Mileage == 0)
            {
                parameters[19] = new SqlParameter("@Mileage", null);
            }
            else
            {
                parameters[19] = new SqlParameter("@Mileage", updateClaimobjDO.Vehicles[0].Mileage);
            }
            foreach (SqlParameter p in parameters)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }
            return connection.ExecuteNonQuery("sps_UpdateClaim", parameters);
        }
    }
}
