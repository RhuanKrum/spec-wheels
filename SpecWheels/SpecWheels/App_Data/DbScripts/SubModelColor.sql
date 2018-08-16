
CREATE TABLE [dbo].[SubModelColor](
	[ColorId] [int] FOREIGN KEY references [dbo].[Color] (Id),
	[SubModelId] [int] FOREIGN KEY references [dbo].[SubModel] (Id)
 
) 

