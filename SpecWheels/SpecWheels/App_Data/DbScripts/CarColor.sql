	
CREATE TABLE [dbo].[CarColor](
	[ColorId] [int] FOREIGN KEY references [dbo].[Color] (Id),
	[CarId] [int] FOREIGN KEY references [dbo].[Car] (Id)
 
) 