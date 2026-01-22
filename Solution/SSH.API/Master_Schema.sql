/****** Object:  Table [dbo].[Account]    Script Date: 22-Jan-2026 16:31:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Account](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](100) NOT NULL,
	[Notes] [nvarchar](500) NULL,
	[Account_TypeID] [uniqueidentifier] NULL,
	[IsActive] [bit] NOT NULL,
	[DatabaseName] [nvarchar](100) NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*
-- Default Staff Account:
INSERT into Account (AccountName, Notes, Account_TypeID, IsActive, DatabaseName, DateCreated, DateModified, CreatedBy, ModifiedBy)
values ('SSHStaff', 'Admin Account of Shivanya Store Hub', null, 1, 'Cust_SSHStaff_1_Test', GETUTCDATE(), GETUTCDATE(), null, null);

*/