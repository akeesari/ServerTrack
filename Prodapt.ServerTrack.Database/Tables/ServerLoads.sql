CREATE TABLE [dbo].[ServerLoads]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServerName] [nchar](50) NULL,
	[CpuLoad] [decimal](18, 0) NULL,
	[RamLoad] [decimal](18, 0) NULL,
	[DateCreated] [datetime] NOT NULL,
	CONSTRAINT [PK_dbo.ServerLoads] Primary key clustered ([Id] ASC)
)
