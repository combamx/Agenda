USE [agenda]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 23/12/2021 09:17:08 a. m. ******/
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
/****** Object:  Table [dbo].[Property]    Script Date: 23/12/2021 09:17:08 a. m. ******/
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
/****** Object:  Table [dbo].[Survey]    Script Date: 23/12/2021 09:17:08 a. m. ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 23/12/2021 09:17:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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
