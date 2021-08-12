# IAccessHomeTest
This project using vb.net (Visual Studio 2012) and database sql server

this is the database script running first before try this project

-------------------1---------------------
USE [HOMETEST]
GO


CREATE TABLE [dbo].[FileAttachmentDetail](
	[StringID] [uniqueidentifier] NOT NULL,
	[StringContent] [nvarchar](max) NULL,
 CONSTRAINT [PK_StringID] PRIMARY KEY CLUSTERED 
(
	[StringID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

-----------------2---------------------------

CREATE TYPE [dbo].[DataTableTemp] AS TABLE(
	[StringID] [uniqueidentifier] NOT NULL,
	[StringContent] [nvarchar](max) NULL
)
GO

---------------3----------------------------

CREATE PROCEDURE [dbo].[spInsertTable]
    @DataTableTemp DataTableTemp readonly
AS
BEGIN
	DELETE FROM FileAttachmentDetail
    insert into [dbo].FileAttachmentDetail select * from @DataTableTemp 
END
GO
