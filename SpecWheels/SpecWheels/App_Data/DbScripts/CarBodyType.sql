
CREATE TABLE [dbo].[CarBodyType](
	[BodyTypeId] [int] FOREIGN KEY references [dbo].[BodyType] (Id),
	[CarId] [int] FOREIGN KEY references [dbo].[Car] (Id)
 
) 


