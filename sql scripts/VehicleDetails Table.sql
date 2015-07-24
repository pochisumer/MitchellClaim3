USE [NationalRegistry]
GO

/****** Object:  Table [dbo].[VehicleDetails]    Script Date: 07/22/2015 16:07:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VehicleDetails](
	[ModelYear] [int] NOT NULL,
	[MakeDescription] [char](100) NULL,
	[ModelDescription] [char](100) NULL,
	[EngineDescription] [char](100) NULL,
	[ExteriorColor] [char](100) NULL,
	[Vin] [char](100) NULL,
	[LicPlate] [char](100) NULL,
	[LicPlateState] [char](100) NULL,
	[LicPlateExpDate] [datetime] NULL,
	[DamageDescription] [char](100) NULL,
	[Mileage] [int] NULL,
	[ClaimNumber] [char](100) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[VehicleDetails]  WITH CHECK ADD FOREIGN KEY([ClaimNumber])
REFERENCES [dbo].[MitchellClaim] ([ClaimNumber])
GO

ALTER TABLE [dbo].[VehicleDetails]  WITH CHECK ADD  CONSTRAINT [CK_VehicleDetails_Mileage] CHECK  (([Mileage]>=(-2147483648.) AND [Mileage]<=(2147483647)))
GO

ALTER TABLE [dbo].[VehicleDetails] CHECK CONSTRAINT [CK_VehicleDetails_Mileage]
GO

ALTER TABLE [dbo].[VehicleDetails]  WITH CHECK ADD  CONSTRAINT [CK_VehicleDetails_ModelYear] CHECK  (([ModelYear]>=(-2147483648.) AND [ModelYear]<=(2147483647)))
GO

ALTER TABLE [dbo].[VehicleDetails] CHECK CONSTRAINT [CK_VehicleDetails_ModelYear]
GO

