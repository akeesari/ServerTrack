SET IDENTITY_INSERT [dbo].[ServerLoads] ON 
GO

MERGE INTO [dbo].[ServerLoads] AS [Target]
USING (VALUES 
(1, 'PDS1', 20, 90, getdate()),
(2, 'PDS2', 40, 80, getdate()),
(3, 'PDS3', 50, 50, getdate())

)

AS [Source] ([Id],[ServerName], [CpuLoad], [RamLoad], [DateCreated]) 
ON [Target].[Id] = [Source].[Id]
WHEN MATCHED THEN --update matched rows 
UPDATE SET 
[ServerName]=[Source].[ServerName],
[CpuLoad] = [Source].[CpuLoad], 
[RamLoad] = [Source].[RamLoad], 
[DateCreated] = [Source].[DateCreated]
WHEN NOT MATCHED BY TARGET THEN -- insert new rows 
INSERT ([Id],[ServerName], [CpuLoad], [RamLoad], [DateCreated]) 
VALUES ([Id],[ServerName], [CpuLoad], [RamLoad], [DateCreated])  

WHEN NOT MATCHED BY SOURCE THEN -- delete rows that are in the target but not the source 
DELETE;

GO
SET IDENTITY_INSERT [dbo].[ServerLoads] OFF
GO