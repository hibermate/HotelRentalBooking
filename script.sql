USE [RoomRentalManagementDB]
GO
/****** Object:  Table [dbo].[Api]    Script Date: 9/5/2017 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Api](
	[IdAPI] [bigint] NOT NULL,
	[ApiKey] [nvarchar](250) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Apis] PRIMARY KEY CLUSTERED 
(
	[IdAPI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 9/5/2017 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[IdCustomer] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Phone] [nvarchar](500) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer2] PRIMARY KEY CLUSTERED 
(
	[IdCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 9/5/2017 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeNumber] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Title] [nvarchar](500) NULL,
 CONSTRAINT [PK_Employee2] PRIMARY KEY CLUSTERED 
(
	[EmployeeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Occupacy]    Script Date: 9/5/2017 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Occupacy](
	[OccupacyNumber] [bigint] IDENTITY(1,1) NOT NULL,
	[EmloyeeNumber] [bigint] NULL,
	[DateOccupacied] [datetime] NULL,
	[IdCustomer] [bigint] NULL,
	[IdRoom] [bigint] NULL,
	[RateApplied] [bigint] NULL,
	[IsPaid] [bit] NULL,
 CONSTRAINT [PK_Occupacy2] PRIMARY KEY CLUSTERED 
(
	[OccupacyNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 9/5/2017 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[IdReceipt] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeNumber] [bigint] NULL,
	[PaymentDate] [datetime] NULL,
	[TotalDays] [bigint] NULL,
	[AmountCharged] [bigint] NULL,
	[TaxAmount] [bigint] NULL,
	[PaymentTotal] [bigint] NULL,
 CONSTRAINT [PK_Payment2] PRIMARY KEY CLUSTERED 
(
	[IdReceipt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 9/5/2017 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[IdRoom] [bigint] IDENTITY(1,1) NOT NULL,
	[RoomType] [nvarchar](500) NULL,
	[BedType] [nvarchar](500) NULL,
	[Rate] [bigint] NULL,
	[Status] [nvarchar](500) NULL,
 CONSTRAINT [PK_Room2] PRIMARY KEY CLUSTERED 
(
	[IdRoom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomBooking]    Script Date: 9/5/2017 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomBooking](
	[IdBooking] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCustomer] [bigint] NULL,
	[DateCheckin] [datetime] NULL,
	[RoomType] [nvarchar](500) NULL,
	[IsApproved] [bit] NULL,
 CONSTRAINT [PK_RoomBooking] PRIMARY KEY CLUSTERED 
(
	[IdBooking] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 9/5/2017 5:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](500) NULL,
	[Name] [nvarchar](500) NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_User2] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([IdCustomer], [Name], [Phone], [Username], [Password]) VALUES (1, N'123', N'123', N'123', N'123')
INSERT [dbo].[Customer] ([IdCustomer], [Name], [Phone], [Username], [Password]) VALUES (3, N'truong quang thai', N'0868149387', N'quangthai', N'19d40526d4f412f467b7e06be025b921')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Occupacy] ON 

INSERT [dbo].[Occupacy] ([OccupacyNumber], [EmloyeeNumber], [DateOccupacied], [IdCustomer], [IdRoom], [RateApplied], [IsPaid]) VALUES (1, NULL, NULL, 1, 2, 40, 0)
INSERT [dbo].[Occupacy] ([OccupacyNumber], [EmloyeeNumber], [DateOccupacied], [IdCustomer], [IdRoom], [RateApplied], [IsPaid]) VALUES (2, NULL, NULL, 1, 2, 40, 0)
INSERT [dbo].[Occupacy] ([OccupacyNumber], [EmloyeeNumber], [DateOccupacied], [IdCustomer], [IdRoom], [RateApplied], [IsPaid]) VALUES (3, NULL, NULL, 1, 2, 40, 0)
INSERT [dbo].[Occupacy] ([OccupacyNumber], [EmloyeeNumber], [DateOccupacied], [IdCustomer], [IdRoom], [RateApplied], [IsPaid]) VALUES (4, NULL, NULL, 1, 2, 40, 0)
INSERT [dbo].[Occupacy] ([OccupacyNumber], [EmloyeeNumber], [DateOccupacied], [IdCustomer], [IdRoom], [RateApplied], [IsPaid]) VALUES (5, NULL, NULL, 1, 2, 40, 1)
INSERT [dbo].[Occupacy] ([OccupacyNumber], [EmloyeeNumber], [DateOccupacied], [IdCustomer], [IdRoom], [RateApplied], [IsPaid]) VALUES (6, NULL, CAST(N'2016-08-31 00:00:00.000' AS DateTime), 1, 6, 40, 1)
INSERT [dbo].[Occupacy] ([OccupacyNumber], [EmloyeeNumber], [DateOccupacied], [IdCustomer], [IdRoom], [RateApplied], [IsPaid]) VALUES (7, NULL, CAST(N'2017-08-31 00:00:00.000' AS DateTime), 1, 1, 30, 0)
INSERT [dbo].[Occupacy] ([OccupacyNumber], [EmloyeeNumber], [DateOccupacied], [IdCustomer], [IdRoom], [RateApplied], [IsPaid]) VALUES (8, NULL, CAST(N'2017-08-31 00:00:00.000' AS DateTime), 1, 1, 30, 0)
SET IDENTITY_INSERT [dbo].[Occupacy] OFF
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([IdReceipt], [EmployeeNumber], [PaymentDate], [TotalDays], [AmountCharged], [TaxAmount], [PaymentTotal]) VALUES (3, 1, CAST(N'2017-09-05 11:32:34.317' AS DateTime), 371, 14840, 1484, 16324)
SET IDENTITY_INSERT [dbo].[Payment] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (1, N'Phòng couple', NULL, 30, N'08/31/2017')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (2, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (3, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (4, N'Phòng vip', NULL, 50, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (5, N'Phòng twin', NULL, 40, N'Not OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (6, N'Phòng twin', NULL, 40, N'OK')
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[RoomBooking] ON 

INSERT [dbo].[RoomBooking] ([IdBooking], [IdCustomer], [DateCheckin], [RoomType], [IsApproved]) VALUES (1, 1, CAST(N'2017-08-31 00:00:00.000' AS DateTime), N'Phòng couple', 1)
INSERT [dbo].[RoomBooking] ([IdBooking], [IdCustomer], [DateCheckin], [RoomType], [IsApproved]) VALUES (2, 1, CAST(N'2017-08-31 00:00:00.000' AS DateTime), N'Phòng twin', 1)
INSERT [dbo].[RoomBooking] ([IdBooking], [IdCustomer], [DateCheckin], [RoomType], [IsApproved]) VALUES (3, 1, CAST(N'2016-08-31 00:00:00.000' AS DateTime), N'Phòng twin', 1)
INSERT [dbo].[RoomBooking] ([IdBooking], [IdCustomer], [DateCheckin], [RoomType], [IsApproved]) VALUES (4, 1, CAST(N'2017-08-31 00:00:00.000' AS DateTime), N'Phòng twin', 0)
INSERT [dbo].[RoomBooking] ([IdBooking], [IdCustomer], [DateCheckin], [RoomType], [IsApproved]) VALUES (5, 1, CAST(N'2017-08-31 00:00:00.000' AS DateTime), N'Phòng twin', 0)
INSERT [dbo].[RoomBooking] ([IdBooking], [IdCustomer], [DateCheckin], [RoomType], [IsApproved]) VALUES (6, 1, CAST(N'2016-09-08 00:00:00.000' AS DateTime), N'Phòng couple', 0)
SET IDENTITY_INSERT [dbo].[RoomBooking] OFF
