
CREATE TABLE [dbo].[Wheel](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](28) NOT NULL,
	[Brand] [nvarchar](40) NOT NULL,
	[Color] [nvarchar](40) NOT NULL,
	[Size] [nvarchar](40) NOT NULL
) 