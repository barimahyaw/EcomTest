USE [EcomTestDb]
GO

/****** Object:  Table [dbo].[Schedule_Dtl]    Script Date: 23-Oct-20 6:35:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Schedule_Dtl](
	[SL_NO] [int] NOT NULL,
	[Cust_Code] [int] NOT NULL,
	[EMI_Date] [datetime] NOT NULL,
	[Total_Amount] [float] NOT NULL,
	[Prn_Amount] [float] NOT NULL,
	[Int_Amount] [float] NOT NULL,
	[Balance] [float] NOT NULL,
	[EMI_St_Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Schedule_Dtl] PRIMARY KEY CLUSTERED 
(
	[SL_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


