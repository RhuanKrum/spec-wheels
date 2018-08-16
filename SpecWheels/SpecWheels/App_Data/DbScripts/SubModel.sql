
CREATE TABLE [dbo].[SubModel](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](48) NOT NULL,
	[YearStart] [date] NOT NULL,
	[YearEnd] [date] NOT NULL,
	[EngineId] [int] FOREIGN KEY references [dbo].[Engine] (Id),
	[SuspensionId] [int] FOREIGN KEY references [dbo].[Suspension] (Id),
	[BreakId] [int] FOREIGN KEY references [dbo].[Break] (Id),
	[DriveTypeId] [int] FOREIGN KEY references [dbo].[DriveType] (Id),
	[TireId] [int] FOREIGN KEY references [dbo].[Tire] (Id),
	[WheelId] [int] FOREIGN KEY references [dbo].[Wheel] (Id)
	
);
