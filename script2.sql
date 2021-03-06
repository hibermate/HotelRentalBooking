USE [RoomRentalManagementDB]
GO
/****** Object:  Table [dbo].[Api]    Script Date: 9/6/2017 6:06:06 PM ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 9/6/2017 6:06:06 PM ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 9/6/2017 6:06:06 PM ******/
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
/****** Object:  Table [dbo].[Occupacy]    Script Date: 9/6/2017 6:06:06 PM ******/
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
/****** Object:  Table [dbo].[Payment]    Script Date: 9/6/2017 6:06:06 PM ******/
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
/****** Object:  Table [dbo].[Room]    Script Date: 9/6/2017 6:06:06 PM ******/
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
/****** Object:  Table [dbo].[RoomBooking]    Script Date: 9/6/2017 6:06:06 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 9/6/2017 6:06:06 PM ******/
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
INSERT [dbo].[Customer] ([IdCustomer], [Name], [Phone], [Username], [Password]) VALUES (4, N'admin', N'08686868', N'admin', N'19d40526d4f412f467b7e06be025b921')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Occupacy] ON 

INSERT [dbo].[Occupacy] ([OccupacyNumber], [EmloyeeNumber], [DateOccupacied], [IdCustomer], [IdRoom], [RateApplied], [IsPaid]) VALUES (10, NULL, CAST(N'2017-09-10 00:00:00.000' AS DateTime), 3, 4, 50, 0)
SET IDENTITY_INSERT [dbo].[Occupacy] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (1, N'Phòng couple', NULL, 30, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (2, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (3, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (4, N'Phòng vip', NULL, 50, N'09/10/2017')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (5, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (6, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (7, N'Phòng couple', NULL, 30, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (8, N'Phòng couple', NULL, 30, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (9, N'Phòng couple', NULL, 30, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (10, N'Phòng couple', NULL, 30, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (11, N'Phòng couple', NULL, 30, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (12, N'Phòng couple', NULL, 30, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (13, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (14, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (15, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (16, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (17, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (18, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (19, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (20, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (21, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (22, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (23, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (24, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (25, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (26, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (27, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (28, N'Phòng twin', NULL, 40, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (29, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (30, N'Phòng vip', NULL, 50, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (31, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (32, N'Phòng vip', NULL, 50, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (33, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (34, N'Phòng vip', NULL, 50, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (35, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (36, N'Phòng vip', NULL, 50, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (37, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (38, N'Phòng vip', NULL, 50, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (39, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (40, N'Phòng vip', NULL, 50, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (41, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (42, N'Phòng vip', NULL, 50, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (43, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (44, N'Phòng vip', NULL, 50, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (45, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (46, N'Phòng vip', NULL, 50, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (47, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (48, N'Phòng vip', NULL, 50, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (49, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (50, N'Phòng vip', NULL, 50, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (51, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (52, N'Phòng vip', NULL, 50, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (53, N'Phòng đơn', NULL, 20, N'OK')
INSERT [dbo].[Room] ([IdRoom], [RoomType], [BedType], [Rate], [Status]) VALUES (54, N'Phòng đơn', NULL, 20, N'OK')
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[RoomBooking] ON 

INSERT [dbo].[RoomBooking] ([IdBooking], [IdCustomer], [DateCheckin], [RoomType], [IsApproved]) VALUES (8, 3, CAST(N'2017-09-10 00:00:00.000' AS DateTime), N'Phòng vip', 1)
INSERT [dbo].[RoomBooking] ([IdBooking], [IdCustomer], [DateCheckin], [RoomType], [IsApproved]) VALUES (9, 3, CAST(N'2017-09-06 00:00:00.000' AS DateTime), N'Phòng đơn', 0)
SET IDENTITY_INSERT [dbo].[RoomBooking] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([IdUser], [Username], [Password], [Name], [RoleID]) VALUES (1, N'admin', N'19d40526d4f412f467b7e06be025b921', N'John Calendar', 1)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [Name], [RoleID]) VALUES (2, N'admin2', N'19d40526d4f412f467b7e06be025b921', N'Ptr Table', 2)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [Name], [RoleID]) VALUES (3, N'receptionist1', N'19d40526d4f412f467b7e06be025b921', N'Jim Pencil', 1)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [Name], [RoleID]) VALUES (4, N'receptionist2', N'19d40526d4f412f467b7e06be025b921', N'Karen Chair', 1)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [Name], [RoleID]) VALUES (5, N'receptionist3', N'19d40526d4f412f467b7e06be025b921', N'Kenny Tivi', 1)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [Name], [RoleID]) VALUES (6, N'receptionist4', N'19d40526d4f412f467b7e06be025b921', N'John Radio', 1)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [Name], [RoleID]) VALUES (7, N'cashier1', N'19d40526d4f412f467b7e06be025b921', N'David Adapter', 2)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [Name], [RoleID]) VALUES (8, N'cashier2', N'19d40526d4f412f467b7e06be025b921', N'Wayne Keyboard', 2)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [Name], [RoleID]) VALUES (9, N'cashier3', N'19d40526d4f412f467b7e06be025b921', N'Garry Shoes', 2)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [Name], [RoleID]) VALUES (10, N'cashier4', N'19d40526d4f412f467b7e06be025b921', N'Juan Bottle', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
