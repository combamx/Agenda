USE [agenda]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 24/12/2021 02:27:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[property_id] [int] NOT NULL,
	[schedule] [datetime] NOT NULL,
	[title] [varchar](255) NOT NULL,
	[dateActivity] [date] NULL,
	[timeBegin] [time](7) NULL,
	[timeEnd] [time](7) NULL,
	[create_at] [datetime] NOT NULL,
	[update_at] [datetime] NOT NULL,
	[status] [varchar](35) NOT NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 24/12/2021 02:27:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NOT NULL,
	[address] [text] NOT NULL,
	[description] [text] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[update_at] [datetime] NOT NULL,
	[disabled_at] [datetime] NULL,
	[status] [varchar](35) NOT NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survey]    Script Date: 24/12/2021 02:27:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Survey](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[activity_id] [int] NOT NULL,
	[answers] [nvarchar](max) NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_Survey] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 24/12/2021 02:27:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[contrasena] [varchar](500) NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Activity] ON 

INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (1, 1, CAST(N'2021-11-09T12:30:00.000' AS DateTime), N'EDITAR DATOS ACTIVIDAD 1', CAST(N'2021-11-09' AS Date), CAST(N'12:30:00' AS Time), CAST(N'13:30:00' AS Time), CAST(N'2021-11-09T11:58:24.267' AS DateTime), CAST(N'2021-11-09T11:58:24.267' AS DateTime), N'Active')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (2, 1, CAST(N'2021-11-09T13:00:00.000' AS DateTime), N'ESTA ES UNA PRUEBA DE ACTIVIDAD 2', CAST(N'2021-11-09' AS Date), CAST(N'13:40:00' AS Time), CAST(N'14:40:00' AS Time), CAST(N'2021-11-09T11:59:50.220' AS DateTime), CAST(N'2021-11-09T11:59:50.220' AS DateTime), N'Cancel')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (3, 1, CAST(N'2021-11-09T13:00:00.000' AS DateTime), N'ESTA ES UNA PRUEBA DE ACTIVIDAD 3', CAST(N'2021-11-09' AS Date), CAST(N'14:50:00' AS Time), CAST(N'15:50:00' AS Time), CAST(N'2021-11-09T12:00:26.757' AS DateTime), CAST(N'2021-11-09T12:00:26.757' AS DateTime), N'Active')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (4, 1, CAST(N'2021-11-09T14:00:00.000' AS DateTime), N'ESTA ES UNA PRUEBA DE ACTIVIDAD 4', CAST(N'2021-11-09' AS Date), CAST(N'16:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'2021-11-09T12:00:44.663' AS DateTime), CAST(N'2021-11-09T12:00:44.663' AS DateTime), N'Active')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (5, 1, CAST(N'2021-11-09T14:00:00.000' AS DateTime), N'ESTA ES UNA PRUEBA DE ACTIVIDAD 5', CAST(N'2021-11-09' AS Date), CAST(N'18:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'2021-11-09T12:00:48.863' AS DateTime), CAST(N'2021-11-09T12:00:48.863' AS DateTime), N'Active')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (6, 1, CAST(N'2021-11-09T14:00:00.000' AS DateTime), N'ESTA ES UNA PRUEBA DE ACTIVIDAD 6', CAST(N'2021-11-09' AS Date), CAST(N'20:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'2021-11-09T12:00:53.127' AS DateTime), CAST(N'2021-11-09T12:00:53.127' AS DateTime), N'Done')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (8, 1, CAST(N'2021-11-09T14:00:00.000' AS DateTime), N'ESTA ES UNA PRUEBA DE ACTIVIDAD 8', CAST(N'2021-11-09' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), CAST(N'2021-11-09T12:00:59.127' AS DateTime), CAST(N'2021-11-09T12:00:59.127' AS DateTime), N'Active')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (9, 1, CAST(N'2021-11-09T14:00:00.000' AS DateTime), N'ESTA ES UNA PRUEBA DE ACTIVIDAD 9', CAST(N'2021-11-09' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), CAST(N'2021-11-09T12:01:01.927' AS DateTime), CAST(N'2021-11-09T12:01:01.927' AS DateTime), N'Active')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (10, 1, CAST(N'2021-11-09T13:45:00.000' AS DateTime), N'EDITAR DATOS DE LA ACTIVIDAD', CAST(N'2021-11-09' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'2021-11-09T12:01:05.170' AS DateTime), CAST(N'2021-11-09T12:01:05.170' AS DateTime), N'Cancel')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (12, 2, CAST(N'2021-11-09T09:30:00.000' AS DateTime), N'ESTA ES UNA PRUEBA DE FECHAS', CAST(N'2021-11-09' AS Date), CAST(N'09:30:00' AS Time), CAST(N'10:30:00' AS Time), CAST(N'2021-11-09T14:48:43.053' AS DateTime), CAST(N'2021-11-09T14:48:43.053' AS DateTime), N'Active')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (13, 3, CAST(N'2021-11-10T00:00:00.000' AS DateTime), N'ESTA ES UNA PRUEBA', CAST(N'2021-11-10' AS Date), CAST(N'00:00:00' AS Time), CAST(N'01:00:00' AS Time), CAST(N'2021-11-10T22:18:51.447' AS DateTime), CAST(N'2021-11-10T22:18:51.447' AS DateTime), N'Active')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (14, 3, CAST(N'2021-11-10T10:19:00.000' AS DateTime), N'ESTA ES UNA PRUEBA', CAST(N'2021-11-10' AS Date), CAST(N'10:19:00' AS Time), CAST(N'11:19:00' AS Time), CAST(N'2021-11-10T22:20:27.377' AS DateTime), CAST(N'2021-11-10T22:20:27.377' AS DateTime), N'Active')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (15, 1, CAST(N'2021-11-11T00:30:00.000' AS DateTime), N'DSDSADSAD', CAST(N'2021-11-11' AS Date), CAST(N'00:30:00' AS Time), CAST(N'01:30:00' AS Time), CAST(N'2021-11-11T00:13:54.153' AS DateTime), CAST(N'2021-11-11T00:13:54.153' AS DateTime), N'Active')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (16, 4, CAST(N'2021-11-11T00:12:00.000' AS DateTime), N'SDSADASDSAD', CAST(N'2021-11-11' AS Date), CAST(N'00:12:00' AS Time), CAST(N'01:12:00' AS Time), CAST(N'2021-11-11T00:17:00.550' AS DateTime), CAST(N'2021-11-11T00:17:00.550' AS DateTime), N'Active')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (17, 7, CAST(N'2021-11-11T00:25:00.000' AS DateTime), N'SFDFSDFSFDSF', CAST(N'2021-11-11' AS Date), CAST(N'00:25:00' AS Time), CAST(N'01:25:00' AS Time), CAST(N'2021-11-11T00:25:43.800' AS DateTime), CAST(N'2021-11-11T00:25:43.800' AS DateTime), N'Active')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (18, 1, CAST(N'2021-11-12T22:34:00.000' AS DateTime), N'SADSADASASDA', CAST(N'2021-11-12' AS Date), CAST(N'22:34:00' AS Time), CAST(N'23:34:00' AS Time), CAST(N'2021-11-12T22:34:45.497' AS DateTime), CAST(N'2021-11-12T22:34:45.497' AS DateTime), N'Active')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (19, 7, CAST(N'2021-11-14T22:30:00.000' AS DateTime), N'ESTA ES UNA PRUEBA DEL DIA 12-11-2021', CAST(N'2021-11-14' AS Date), CAST(N'22:30:00' AS Time), CAST(N'23:30:00' AS Time), CAST(N'2021-11-12T22:38:56.120' AS DateTime), CAST(N'2021-11-12T22:38:56.120' AS DateTime), N'Cancel')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (28, 8, CAST(N'2021-12-22T08:15:00.000' AS DateTime), N'ESTA ES UNA PRUEBA MAS....', CAST(N'2021-12-22' AS Date), CAST(N'08:15:00' AS Time), CAST(N'09:15:00' AS Time), CAST(N'2021-11-14T21:30:58.063' AS DateTime), CAST(N'2021-11-14T21:30:58.063' AS DateTime), N'Active')
INSERT [dbo].[Activity] ([id], [property_id], [schedule], [title], [dateActivity], [timeBegin], [timeEnd], [create_at], [update_at], [status]) VALUES (32, 10, CAST(N'2021-12-30T09:36:00.000' AS DateTime), N'ESTA ES UNA PRUEBA MAS', CAST(N'2021-12-30' AS Date), CAST(N'09:36:00' AS Time), CAST(N'10:36:00' AS Time), CAST(N'2021-12-24T09:36:38.093' AS DateTime), CAST(N'2021-12-24T09:36:38.093' AS DateTime), N'Active')
SET IDENTITY_INSERT [dbo].[Activity] OFF
GO
SET IDENTITY_INSERT [dbo].[Property] ON 

INSERT [dbo].[Property] ([id], [title], [address], [description], [created_at], [update_at], [disabled_at], [status]) VALUES (1, N'TITULO DE LA PROPIEDAD UNO', N'DIRECCION DE LA PROPIEDAD UNO', N'ESTA ES LA DESCRIPCION DE LA PROPIEDAD UNO, EJEMPLO', CAST(N'2021-11-09T09:54:01.043' AS DateTime), CAST(N'2021-11-09T09:54:01.043' AS DateTime), NULL, N'Active')
INSERT [dbo].[Property] ([id], [title], [address], [description], [created_at], [update_at], [disabled_at], [status]) VALUES (2, N'TITULO DE LA PROPIEDAD DOS', N'DIRECCION DE LA PROPIEDAD DOS', N'ESTA ES LA DESCRIPCION DE LA PROPIEDAD DOS, EJEMPLO', CAST(N'2021-11-09T09:54:11.200' AS DateTime), CAST(N'2021-11-09T09:54:11.200' AS DateTime), NULL, N'Active')
INSERT [dbo].[Property] ([id], [title], [address], [description], [created_at], [update_at], [disabled_at], [status]) VALUES (3, N'TITULO DE LA PROPIEDAD TRES', N'DIRECCION DE LA PROPIEDAD TRES', N'ESTA ES LA DESCRIPCION DE LA PROPIEDAD TRES, EJEMPLO', CAST(N'2021-11-09T09:54:20.490' AS DateTime), CAST(N'2021-11-09T09:54:20.490' AS DateTime), NULL, N'Active')
INSERT [dbo].[Property] ([id], [title], [address], [description], [created_at], [update_at], [disabled_at], [status]) VALUES (4, N'TITULO DE LA PROPIEDAD CUATRO', N'DIRECCION DE LA PROPIEDAD CUATRO', N'ESTA ES LA DESCRIPCION DE LA PROPIEDAD CUATRO, EJEMPLO', CAST(N'2021-11-09T09:54:31.217' AS DateTime), CAST(N'2021-11-09T09:54:31.217' AS DateTime), NULL, N'Active')
INSERT [dbo].[Property] ([id], [title], [address], [description], [created_at], [update_at], [disabled_at], [status]) VALUES (5, N'TITULO DE LA PROPIEDAD CINCO', N'DIRECCION DE LA PROPIEDAD CINCO', N'ESTA ES LA DESCRIPCION DE LA PROPIEDAD CINCO, EJEMPLO', CAST(N'2021-11-09T09:54:40.960' AS DateTime), CAST(N'2021-11-09T09:54:40.960' AS DateTime), NULL, N'Active')
INSERT [dbo].[Property] ([id], [title], [address], [description], [created_at], [update_at], [disabled_at], [status]) VALUES (6, N'TITULO DE LA PROPIEDAD SEIS', N'DIRECCION DE LA PROPIEDAD SEIS', N'ESTA ES LA DESCRIPCION DE LA PROPIEDAD SEIS, EJEMPLO', CAST(N'2021-11-09T09:54:52.820' AS DateTime), CAST(N'2021-11-09T09:54:52.820' AS DateTime), NULL, N'Cancel')
INSERT [dbo].[Property] ([id], [title], [address], [description], [created_at], [update_at], [disabled_at], [status]) VALUES (7, N'TITULO DE LA PROPIEDAD SIETE', N'DIRECCION DE LA PROPIEDAD SIETE', N'ESTA ES LA DESCRIPCION DE LA PROPIEDAD SIETE, EJEMPLO', CAST(N'2021-11-09T09:55:06.070' AS DateTime), CAST(N'2021-11-09T09:55:06.070' AS DateTime), NULL, N'Active')
INSERT [dbo].[Property] ([id], [title], [address], [description], [created_at], [update_at], [disabled_at], [status]) VALUES (8, N'TITULO DE LA PROPIEDAD OCHO', N'DIRECCION DE LA PROPIEDAD OCHO', N'ESTA ES LA DESCRIPCION DE LA PROPIEDAD OCHO, EJEMPLO', CAST(N'2021-11-09T09:55:21.093' AS DateTime), CAST(N'2021-11-09T09:55:21.093' AS DateTime), NULL, N'Active')
INSERT [dbo].[Property] ([id], [title], [address], [description], [created_at], [update_at], [disabled_at], [status]) VALUES (9, N'TITULO DE LA PROPIEDAD NUEVE', N'DIRECCION DE LA PROPIEDAD NUEVE', N'ESTA ES LA DESCRIPCION DE LA PROPIEDAD NUEVE, EJEMPLO', CAST(N'2021-11-09T09:55:31.880' AS DateTime), CAST(N'2021-11-09T09:55:31.880' AS DateTime), NULL, N'Active')
INSERT [dbo].[Property] ([id], [title], [address], [description], [created_at], [update_at], [disabled_at], [status]) VALUES (10, N'TITULO DE LA PROPIEDAD DIEZ', N'DIRECCION DE LA PROPIEDAD DIEZ', N'ESTA ES LA DESCRIPCION DE LA PROPIEDAD DIEZ, EJEMPLO', CAST(N'2021-11-09T09:55:43.023' AS DateTime), CAST(N'2021-11-09T09:55:43.023' AS DateTime), NULL, N'Active')
SET IDENTITY_INSERT [dbo].[Property] OFF
GO
SET IDENTITY_INSERT [dbo].[Survey] ON 

INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (1, 1, N'ESTA ES UNA PRUEBA SURVERY 1', CAST(N'2021-11-14T22:17:43.473' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (2, 1, N'ESTA ES UNA PRUEBA SURVERY 2', CAST(N'2021-11-14T22:17:48.737' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (3, 1, N'ESTA ES UNA PRUEBA SURVERY 3', CAST(N'2021-11-14T22:17:52.440' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (4, 1, N'ESTA ES UNA PRUEBA SURVERY 4', CAST(N'2021-11-14T22:17:55.423' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (5, 1, N'ESTA ES UNA PRUEBA SURVERY 5', CAST(N'2021-11-14T22:17:58.940' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (6, 1, N'ESTA ES UNA PRUEBA SURVERY 6', CAST(N'2021-11-14T22:18:01.867' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (7, 1, N'ESTA ES UNA PRUEBA SURVERY 7', CAST(N'2021-11-14T22:18:04.320' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (8, 1, N'ESTA ES UNA PRUEBA SURVERY 8', CAST(N'2021-11-14T22:18:07.010' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (9, 1, N'ESTA ES UNA PRUEBA SURVERY 9', CAST(N'2021-11-14T22:18:10.020' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (10, 1, N'ESTA ES UNA PRUEBA SURVERY 10', CAST(N'2021-11-14T22:18:13.127' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (11, 2, N'ESTA ES UNA PRUEBA SURVERY 1', CAST(N'2021-11-14T22:18:18.847' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (12, 2, N'ESTA ES UNA PRUEBA SURVERY 2', CAST(N'2021-11-14T22:18:22.460' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (13, 2, N'ESTA ES UNA PRUEBA SURVERY 3', CAST(N'2021-11-14T22:18:24.467' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (14, 2, N'ESTA ES UNA PRUEBA SURVERY 4', CAST(N'2021-11-14T22:18:26.667' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (15, 2, N'ESTA ES UNA PRUEBA SURVERY 5', CAST(N'2021-11-14T22:18:30.057' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (16, 3, N'ESTA ES UNA PRUEBA SURVERY 1', CAST(N'2021-11-14T22:18:41.490' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (17, 3, N'ESTA ES UNA PRUEBA SURVERY 3', CAST(N'2021-11-14T22:18:46.450' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (18, 3, N'ESTA ES UNA PRUEBA SURVERY 4', CAST(N'2021-11-14T22:18:49.443' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (19, 3, N'ESTA ES UNA PRUEBA SURVERY 5', CAST(N'2021-11-14T22:18:51.847' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (20, 4, N'ESTA ES UNA PRUEBA SURVERY 1', CAST(N'2021-11-14T22:18:59.103' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (21, 4, N'ESTA ES UNA PRUEBA SURVERY 2', CAST(N'2021-11-14T22:19:01.120' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (22, 4, N'ESTA ES UNA PRUEBA SURVERY 3', CAST(N'2021-11-14T22:19:02.937' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (23, 4, N'ESTA ES UNA PRUEBA SURVERY 4', CAST(N'2021-11-14T22:19:05.480' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (24, 4, N'ESTA ES UNA PRUEBA SURVERY 5', CAST(N'2021-11-14T22:19:07.617' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (25, 4, N'ESTA ES UNA PRUEBA SURVERY 6', CAST(N'2021-11-14T22:19:09.690' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (26, 4, N'ESTA ES UNA PRUEBA SURVERY 7', CAST(N'2021-11-14T22:19:12.203' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (27, 4, N'ESTA ES UNA PRUEBA SURVERY 8', CAST(N'2021-11-14T22:19:14.787' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (28, 4, N'ESTA ES UNA PRUEBA SURVERY 9', CAST(N'2021-11-14T22:19:17.893' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (29, 4, N'ESTA ES UNA PRUEBA SURVERY 10', CAST(N'2021-11-14T22:19:21.167' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (30, 4, N'ESTA ES UNA PRUEBA SURVERY 11', CAST(N'2021-11-14T22:19:23.533' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (31, 4, N'ESTA ES UNA PRUEBA SURVERY 12', CAST(N'2021-11-14T22:19:25.840' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (32, 4, N'ESTA ES UNA PRUEBA SURVERY 13', CAST(N'2021-11-14T22:19:28.643' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (33, 5, N'ESTA ES UNA PRUEBA SURVERY 1', CAST(N'2021-11-14T22:19:38.910' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (34, 5, N'ESTA ES UNA PRUEBA SURVERY 2', CAST(N'2021-11-14T22:19:41.190' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (35, 5, N'ESTA ES UNA PRUEBA SURVERY 3', CAST(N'2021-11-14T22:19:44.277' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (36, 5, N'ESTA ES UNA PRUEBA SURVERY 4', CAST(N'2021-11-14T22:19:46.530' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (37, 5, N'ESTA ES UNA PRUEBA SURVERY 5', CAST(N'2021-11-14T22:19:49.227' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (38, 6, N'ESTA ES UNA PRUEBA SURVERY 1', CAST(N'2021-11-14T22:19:57.523' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (39, 6, N'ESTA ES UNA PRUEBA SURVERY 2', CAST(N'2021-11-14T22:20:00.013' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (40, 6, N'ESTA ES UNA PRUEBA SURVERY 3', CAST(N'2021-11-14T22:20:02.143' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (41, 8, N'ESTA ES UNA PRUEBA SURVERY 1', CAST(N'2021-11-14T22:20:09.427' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (42, 8, N'ESTA ES UNA PRUEBA SURVERY 2', CAST(N'2021-11-14T22:20:11.947' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (43, 8, N'ESTA ES UNA PRUEBA SURVERY 3', CAST(N'2021-11-14T22:20:16.800' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (44, 9, N'ESTA ES UNA PRUEBA SURVERY 1', CAST(N'2021-11-14T22:20:25.433' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (45, 9, N'ESTA ES UNA PRUEBA SURVERY 2', CAST(N'2021-11-14T22:20:28.290' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (46, 9, N'ESTA ES UNA PRUEBA SURVERY 3', CAST(N'2021-11-14T22:20:30.307' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (47, 9, N'ESTA ES UNA PRUEBA SURVERY 4', CAST(N'2021-11-14T22:20:32.293' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (48, 9, N'ESTA ES UNA PRUEBA SURVERY 5', CAST(N'2021-11-14T22:20:34.197' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (49, 10, N'ESTA ES UNA PRUEBA SURVERY 1', CAST(N'2021-11-14T22:20:41.880' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (50, 10, N'ESTA ES UNA PRUEBA SURVERY 2', CAST(N'2021-11-14T22:20:44.670' AS DateTime))
INSERT [dbo].[Survey] ([id], [activity_id], [answers], [created_at]) VALUES (51, 10, N'ESTA ES UNA PRUEBA SURVERY 3', CAST(N'2021-11-14T22:20:47.110' AS DateTime))
SET IDENTITY_INSERT [dbo].[Survey] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [email], [contrasena], [nombre]) VALUES (1, N'omar.cortes.casillas@gmail.com', N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', N'OMAR CORTES CASILLAS')
INSERT [dbo].[User] ([id], [email], [contrasena], [nombre]) VALUES (2, N'ocortesc.job@gmail.com', N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', N'EJEMPLO USUARIO')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Activity] ADD  CONSTRAINT [DF_Activity_dateActivity]  DEFAULT (CONVERT([varchar],getdate(),(23))) FOR [dateActivity]
GO
ALTER TABLE [dbo].[Activity] ADD  CONSTRAINT [DF_Activity_timeBegin]  DEFAULT (CONVERT([time],sysdatetime())) FOR [timeBegin]
GO
ALTER TABLE [dbo].[Activity] ADD  CONSTRAINT [DF_Activity_timeEnd]  DEFAULT (dateadd(hour,(1),getdate())) FOR [timeEnd]
GO
ALTER TABLE [dbo].[Activity] ADD  CONSTRAINT [DF_Activity_create_at]  DEFAULT (getdate()) FOR [create_at]
GO
ALTER TABLE [dbo].[Activity] ADD  CONSTRAINT [DF_Activity_update_at]  DEFAULT (getdate()) FOR [update_at]
GO
ALTER TABLE [dbo].[Activity] ADD  CONSTRAINT [DF_Activity_status]  DEFAULT ('Active') FOR [status]
GO
ALTER TABLE [dbo].[Property] ADD  CONSTRAINT [DF_Property_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Property] ADD  CONSTRAINT [DF_Property_update_at]  DEFAULT (getdate()) FOR [update_at]
GO
ALTER TABLE [dbo].[Property] ADD  CONSTRAINT [DF_Property_status]  DEFAULT ('Active') FOR [status]
GO
ALTER TABLE [dbo].[Survey] ADD  CONSTRAINT [DF_Survey_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Property] FOREIGN KEY([property_id])
REFERENCES [dbo].[Property] ([id])
GO
ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Property]
GO
ALTER TABLE [dbo].[Survey]  WITH CHECK ADD  CONSTRAINT [FK_Survey_Activity] FOREIGN KEY([activity_id])
REFERENCES [dbo].[Activity] ([id])
GO
ALTER TABLE [dbo].[Survey] CHECK CONSTRAINT [FK_Survey_Activity]
GO
