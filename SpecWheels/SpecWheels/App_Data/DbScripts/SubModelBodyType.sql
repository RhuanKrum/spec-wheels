
CREATE TABLE [dbo].[SubModelBodyType](
	[BodyTypeId] [int] FOREIGN KEY references [dbo].[BodyType] (Id),
	[SubModelId] [int] FOREIGN KEY references [dbo].[SubModel] (Id)
 
) 


