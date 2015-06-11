USE [hackathonDB]
GO
/****** Object:  Table [dbo].[Badges]    Script Date: 11/06/2015 7:28:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Badges](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	[description] [nvarchar](50) NULL,
	[photourl] [nvarchar](50) NULL,
	[points] [int] NULL,
	[languageid] [int] NOT NULL,
	[bageid] [int] NOT NULL,
 CONSTRAINT [PK_Badges] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/06/2015 7:28:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cat_id] [int] NOT NULL,
	[cat_name] [nvarchar](50) NULL,
	[cat_desc] [nvarchar](max) NULL,
	[languageid] [int] NOT NULL,
 CONSTRAINT [PK_Categories_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Companies]    Script Date: 11/06/2015 7:28:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[afm] [int] NOT NULL,
	[company_name] [nvarchar](50) NULL,
	[categoryid] [int] NOT NULL,
	[country] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Complaints]    Script Date: 11/06/2015 7:28:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Complaints](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NOT NULL,
	[description] [nvarchar](max) NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_Complaints] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 11/06/2015 7:28:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[id] [int] NOT NULL,
	[language] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Offer_details]    Script Date: 11/06/2015 7:28:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offer_details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[offerid] [int] NOT NULL,
	[languageid] [int] NOT NULL,
	[title] [nvarchar](50) NULL,
	[description] [nvarchar](max) NULL,
	[photourl] [nchar](10) NULL,
 CONSTRAINT [PK_Offer_details] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Offers]    Script Date: 11/06/2015 7:28:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[companyid] [int] NOT NULL,
	[points_required] [int] NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Offers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Receipts]    Script Date: 11/06/2015 7:28:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[company_afm] [int] NOT NULL,
	[receipt_no] [int] NOT NULL,
	[date_issued] [datetime] NULL,
	[amount] [float] NULL,
	[vat] [float] NULL,
	[ccn] [int] NULL,
	[categoryid] [int] NOT NULL,
	[user_registration_id] [int] NULL,
	[company_reg_id] [int] NULL,
 CONSTRAINT [PK_Receipts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Badges]    Script Date: 11/06/2015 7:28:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Badges](
	[user_id] [int] NOT NULL,
	[badge_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_info]    Script Date: 11/06/2015 7:28:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_info](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fname] [nvarchar](50) NULL,
	[lname] [nvarchar](50) NULL,
	[dob] [datetime] NULL,
	[gender] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[country] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[postcode] [int] NULL,
	[afm] [int] NOT NULL,
	[userid] [int] NOT NULL,
 CONSTRAINT [PK_User_info] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/06/2015 7:28:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[isLocal] [bit] NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[points] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Badges]  WITH CHECK ADD  CONSTRAINT [FK_Badges_Languages] FOREIGN KEY([languageid])
REFERENCES [dbo].[Languages] ([id])
GO
ALTER TABLE [dbo].[Badges] CHECK CONSTRAINT [FK_Badges_Languages]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Languages] FOREIGN KEY([languageid])
REFERENCES [dbo].[Languages] ([id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Languages]
GO
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK_Complaints_Users] FOREIGN KEY([userid])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK_Complaints_Users]
GO
ALTER TABLE [dbo].[Offer_details]  WITH CHECK ADD  CONSTRAINT [FK_Offer_details_Languages] FOREIGN KEY([languageid])
REFERENCES [dbo].[Languages] ([id])
GO
ALTER TABLE [dbo].[Offer_details] CHECK CONSTRAINT [FK_Offer_details_Languages]
GO
ALTER TABLE [dbo].[Offer_details]  WITH CHECK ADD  CONSTRAINT [FK_Offer_details_Offers] FOREIGN KEY([offerid])
REFERENCES [dbo].[Offers] ([id])
GO
ALTER TABLE [dbo].[Offer_details] CHECK CONSTRAINT [FK_Offer_details_Offers]
GO
ALTER TABLE [dbo].[Offers]  WITH CHECK ADD  CONSTRAINT [FK_Offers_Companies] FOREIGN KEY([companyid])
REFERENCES [dbo].[Companies] ([id])
GO
ALTER TABLE [dbo].[Offers] CHECK CONSTRAINT [FK_Offers_Companies]
GO
ALTER TABLE [dbo].[User_info]  WITH CHECK ADD  CONSTRAINT [FK_User_info_Users] FOREIGN KEY([userid])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[User_info] CHECK CONSTRAINT [FK_User_info_Users]
GO
