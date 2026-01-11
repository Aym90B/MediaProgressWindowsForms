USE [MovieData]
GO
/****** Object:  Table [dbo].[Basics]    Script Date: 1/11/2026 1:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Basics](
	[tconst] [varchar](50) NOT NULL,
	[titleType] [varchar](50) NULL,
	[primaryTitle] [nvarchar](1024) NULL,
	[originalTitle] [nvarchar](1024) NULL,
	[isAdult] [bit] NULL,
	[startYear] [varchar](50) NULL,
	[endYear] [varchar](50) NULL,
	[runtimeMinutes] [int] NULL,
	[genres] [varchar](50) NULL,
	[Completed] [bit] NULL,
	[whereToWatch] [nvarchar](200) NULL,
	[Category] [int] NULL,
	[watchAgain] [bit] NULL,
	[StartWatching] [bit] NULL,
	[PercentageOfCompletion] [float] NULL,
	[MyRating] [float] NULL,
	[hoursToComplete] [float] NULL,
	[screenResolution] [nchar](10) NULL,
	[difficulty] [nchar](2) NULL,
 CONSTRAINT [PK_Basics] PRIMARY KEY CLUSTERED 
(
	[tconst] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 1/11/2026 1:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] NOT NULL,
	[Name] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Episodes]    Script Date: 1/11/2026 1:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Episodes](
	[tconst] [varchar](50) NOT NULL,
	[parentTconst] [varchar](50) NULL,
	[seasonNumber] [int] NULL,
	[episodeNumber] [int] NULL,
	[Completed] [bit] NULL,
	[WatchAgain] [bit] NULL,
	[screenResolution] [nchar](10) NULL,
 CONSTRAINT [PK_Episodes] PRIMARY KEY CLUSTERED 
(
	[tconst] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 1/11/2026 1:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[tconst] [varchar](50) NOT NULL,
	[averageRating] [float] NOT NULL,
	[numVotes] [int] NOT NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[tconst] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
