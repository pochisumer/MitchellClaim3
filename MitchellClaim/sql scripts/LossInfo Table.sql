USE [NationalRegistry]
GO

/****** Object:  Table [dbo].[LossInfo]    Script Date: 07/22/2015 16:06:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LossInfo](
	[CauseOfLoss] [char](100) NULL,
	[ReportedDate] [varchar](255) NULL,
	[LossDescription] [char](100) NULL,
	[ClaimNumber] [char](100) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[LossInfo]  WITH CHECK ADD FOREIGN KEY([ClaimNumber])
REFERENCES [dbo].[MitchellClaim] ([ClaimNumber])
GO

ALTER TABLE [dbo].[LossInfo]  WITH CHECK ADD  CONSTRAINT [CK_LossInfo_CauseOfLoss] CHECK  (([CauseOfLoss]='Other' OR [CauseOfLoss]='Mechanical Breakdown' OR [CauseOfLoss]='Hail' OR [CauseOfLoss]='Fire' OR [CauseOfLoss]='Explosion' OR [CauseOfLoss]='Collision'))
GO

ALTER TABLE [dbo].[LossInfo] CHECK CONSTRAINT [CK_LossInfo_CauseOfLoss]
GO

