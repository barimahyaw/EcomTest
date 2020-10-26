USE [EcomTestDb]
GO

/****** Object:  Table [dbo].[Disbursement_Dtl]    Script Date: 23-Oct-20 6:43:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Disbursement_Dtl](
	[Cust_Code] [int] NOT NULL,
	[Cust_Name] [varchar](50) NOT NULL,
	[Disb_Date] [datetime] NOT NULL,
	[Disb_Amount] [float] NOT NULL,
	[Int_Rate] [float] NOT NULL,
	[Months] [int] NOT NULL,
	[EMS_St_Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Disbursement_Dtl] PRIMARY KEY CLUSTERED 
(
	[Cust_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


