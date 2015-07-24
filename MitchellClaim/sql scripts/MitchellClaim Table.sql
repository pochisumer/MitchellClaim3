USE [NationalRegistry]
GO

/****** Object:  Table [dbo].[MitchellClaim]    Script Date: 07/22/2015 16:07:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MitchellClaim](
	[ClaimNumber] [char](100) NOT NULL,
	[ClaimantFirstName] [char](100) NULL,
	[ClaimantLastName] [char](100) NULL,
	[Status] [char](100) NULL,
	[LossDate] [varchar](255) NULL,
	[AssignedAdjusterID] [bigint] NULL,
 CONSTRAINT [PK_MitchellClaim] PRIMARY KEY CLUSTERED 
(
	[ClaimNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[MitchellClaim]  WITH CHECK ADD  CONSTRAINT [CK_MitchellClaim_AssignedAdjusterID] CHECK  (([AssignedAdjusterID]>=(-9223372036854775808.) AND [AssignedAdjusterID]<=(9223372036854775807.)))
GO

ALTER TABLE [dbo].[MitchellClaim] CHECK CONSTRAINT [CK_MitchellClaim_AssignedAdjusterID]
GO

ALTER TABLE [dbo].[MitchellClaim]  WITH CHECK ADD  CONSTRAINT [CK_MitchellClaim_Status] CHECK  (([Status]='CLOSED' OR [Status]='OPEN'))
GO

ALTER TABLE [dbo].[MitchellClaim] CHECK CONSTRAINT [CK_MitchellClaim_Status]
GO

