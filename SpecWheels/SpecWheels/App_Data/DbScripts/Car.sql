
CREATE TABLE [dbo].[Car](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](48) NOT NULL,
	[Brand] [nvarchar](48) NOT NULL,
	[Weight] DECIMAL(8,2) NOT NULL,
	[Height] DECIMAL(8,2) NOT NULL,
	[Lenght] DECIMAL(8,2) NOT NULL,
	[Width] DECIMAL(8,2) NOT NULL,
	[ImageName] [nvarchar](48) NOT NULL,
	[ImageData] [varbinary](Max) NOT NULL,
	[YearStart] [date] NOT NULL,
	[YearEnd] [date] NOT NULL,
	[EngineId] [int] FOREIGN KEY references [dbo].[Engine] (Id),
	[SuspensionId] [int] FOREIGN KEY references [dbo].[Suspension] (Id),
	[BreakId] [int] FOREIGN KEY references [dbo].[Break] (Id),
	[DriveTypeId] [int] FOREIGN KEY references [dbo].[DriveType] (Id),
	[TireId] [int] FOREIGN KEY references [dbo].[Tire] (Id),
	[WheelId] [int] FOREIGN KEY references [dbo].[Wheel] (Id),
	 
	
);
