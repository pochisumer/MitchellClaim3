USE [NationalRegistry]
GO

/****** Object:  StoredProcedure [dbo].[sps_UpdateClaim]    Script Date: 07/24/2015 01:35:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sps_UpdateClaim] 
	@ClaimNumber varchar(100),
	@ClaimantFirstName varchar(100),
	@ClaimantLastName varchar(100),
	@Status varchar(100),
	@LossDate varchar(100),
	@AssignedAdjusterID int,
	@CauseOfLoss varchar(100),
	@ReportedDate varchar(100),
	@LossDescription varchar(100), 
	@Vin varchar(255),
	@ModelYear int,
	@MakeDescription varchar(100),
	@ModelDescription varchar(100),
	@EngineDescription varchar(100),
	@ExteriorColor varchar(100),
	@LicPlate varchar(100),
	@LicPlateState varchar(100),
	@LicPlateExpDate varchar(100),
	@DamageDescription varchar(100),
	@Mileage int
	
--ClaimNumber = COALESCE(@ClaimNumber int, ClaimNumber),
--ClaimantFirstName = COALESCE(@ClaimantFirstName,ClaimantFirstName),
--ClaimantLastName = COALESCE(@ClaimantLastName,ClaimantLastName),
--Status = COALESCE(@Status,Status),
--LossDate = COALESCE(@LossDate,LossDate),
--AssignedAdjusterID = COALESCE(@AssignedAdjusterID,AssignedAdjusterID),
--CauseOfLoss = COALESCE(@CauseOfLoss,CauseOfLoss),
--ReportedDate = COALESCE(@ReportedDate,ReportedDate),
--LossDescription = COALESCE(@LossDescription,LossDescription),
--Vin = COALESCE(@Vin,Vin),
--ModelYear = COALESCE(@ModelYear,ModelYear),
--MakeDescription = COALESCE(@MakeDescription,MakeDescription),
--ModelDescription = COALESCE(@ModelDescription,ModelDescription),
--EngineDescription =COALESCE (@EngineDescription,EngineDescription),
--ExteriorColor =COALESCE (@ExteriorColor,ExteriorColor),
--LicPlate = COALESCE(@LicPlate,LicPlate),
--LicPlateState =COALESCE (@LicPlateState,LicPlateState),
--LicPlateExpDate =COALESCE (@LicPlateExpDate,LicPlateExpDate),
--DamageDescription COALESCE= (@DamageDescription,DamageDescription),
--Mileage = COALESCE(@Mileage,Mileage)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

    -- Insert statements for procedure here

   UPDATE MitchellClaim
   set
  ClaimNumber = COALESCE(@ClaimNumber, ClaimNumber),	
  ClaimantFirstName = COALESCE(@ClaimantFirstName,ClaimantFirstName),
  ClaimantLastName = COALESCE(@ClaimantLastName,ClaimantLastName),
  Status = COALESCE(@Status,Status),
  LossDate = COALESCE(@LossDate,LossDate),
  AssignedAdjusterID = COALESCE(@AssignedAdjusterID,AssignedAdjusterID)
   --AssignedAdjusterID = @AssignedAdjusterID
   where ClaimNumber = @claimNumber   
   
   UPDATE LossInfo
   set
   CauseOfLoss = COALESCE(@CauseOfLoss,CauseOfLoss),
   ReportedDate = COALESCE(@ReportedDate,ReportedDate),
   LossDescription = COALESCE(@LossDescription,LossDescription)
   where ClaimNumber = @claimNumber   
   
   UPDATE VehicleDetails 
   set 
   Vin = COALESCE(@Vin,Vin),
   ModelYear = COALESCE(@ModelYear,ModelYear),
   MakeDescription = COALESCE(@MakeDescription,MakeDescription),
   ModelDescription = COALESCE(@ModelDescription,ModelDescription),
   EngineDescription =COALESCE(@EngineDescription,EngineDescription),
   ExteriorColor = COALESCE(@ExteriorColor,ExteriorColor),
   LicPlate = COALESCE(@LicPlate,LicPlate),
   LicPlateState = COALESCE(@LicPlateState,LicPlateState),
   LicPlateExpDate = COALESCE(@LicPlateExpDate,LicPlateExpDate),
   DamageDescription = COALESCE(@DamageDescription,DamageDescription),
   Mileage = COALESCE(@Mileage,Mileage)
   where ClaimNumber = @claimNumber  
	
END
GO

