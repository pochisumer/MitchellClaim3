USE [NationalRegistry]
GO

/****** Object:  StoredProcedure [dbo].[sps_readClaim]    Script Date: 07/22/2015 16:08:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sps_readClaim] 
	-- Add the parameters for the stored procedure here
	@claimNumber varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT m.ClaimantFirstName, m.ClaimantLastName, m.Status, m.LossDate, m.AssignedAdjusterID, l.CauseOfLoss, l.ReportedDate, l.LossDescription,
	v.Vin, v.ModelYear, v.MakeDescription, v.ModelDescription, v.EngineDescription, v.ExteriorColor, v.LicPlate, v.LicPlateState, v.LicPlateExpDate,
	v.DamageDescription, v.Mileage
	FROM MitchellClaim m join LossInfo l on m.ClaimNumber = l.ClaimNumber join VehicleDetails v on m.ClaimNumber = v.ClaimNumber
	WHERE m.ClaimNumber = @claimNumber
	
END

GO

