USE [NationalRegistry]
GO

/****** Object:  StoredProcedure [dbo].[spi_createClaim]    Script Date: 07/22/2015 16:12:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/****** Object:  Stored Procedure dbo.spi_Participants    Script Date: 5/7/2007 5:25:40 PM ******/

CREATE PROCEDURE [dbo].[spi_createClaim] 
	@ClaimNumber char(100),
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
AS 

	DECLARE @ClaimNo char(100)
	INSERT INTO MitchellCLaim (ClaimNumber, ClaimantFirstName, ClaimantLastName, Status, LossDate, AssignedAdjusterID)
	VALUES (@ClaimNumber, @ClaimantFirstName, @ClaimantLastName, @Status, @LossDate, @AssignedAdjusterID) 

	select @claimNO = m.ClaimNumber from MitchellClaim m  
	
	INSERT INTO LossInfo (CauseOfLoss,ReportedDate,LossDescription, ClaimNumber)
	VALUES (@CauseOfLoss,@ReportedDate,@LossDescription, @claimNO)	
	
	INSERT INTO VehicleDetails (Vin, ModelYear,MakeDescription, ModelDescription,EngineDescription,ExteriorColor,LicPlate,LicPlateState,LicPlateExpDate,DamageDescription,Mileage, ClaimNumber)
	VALUES (@Vin,@ModelYear,@MakeDescription,@ModelDescription,@EngineDescription,@ExteriorColor,@LicPlate,@LicPlateState,@LicPlateExpDate,@DamageDescription,@Mileage, @claimNO)
GO

