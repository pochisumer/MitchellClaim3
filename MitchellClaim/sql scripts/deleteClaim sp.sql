USE [NationalRegistry]
GO

/****** Object:  StoredProcedure [dbo].[sps_deleteClaim]    Script Date: 07/22/2015 16:09:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sps_deleteClaim] 
	-- Add the parameters for the stored procedure here
	@claimNumber varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	

    -- Insert statements for procedure here


   delete t2
   from LossInfo t2
    join MitchellClaim t1
      on t2.ClaimNumber = t1.ClaimNumber
    join VehicleDetails t3
      on t3.ClaimNumber = t1.ClaimNumber
		where t1.ClaimNumber = @claimNumber
		
   delete t3
   from VehicleDetails t3
    join MitchellClaim t1
      on t3.ClaimNumber = t1.ClaimNumber
      where t1.ClaimNumber = @claimNumber 

   delete t1
   from MitchellClaim t1 
   where t1.ClaimNumber = @claimNumber
	
END
GO

