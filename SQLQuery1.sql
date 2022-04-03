USE [master]
GO
/****** Object:  Database [TourDB]    Script Date: 01.04.2021 16:08:44 ******/
CREATE DATABASE [TourDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TourDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TourDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TourDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TourDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TourDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TourDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TourDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TourDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TourDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TourDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TourDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TourDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TourDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TourDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TourDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TourDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TourDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TourDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TourDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TourDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TourDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TourDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TourDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TourDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TourDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TourDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TourDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TourDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TourDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TourDB] SET  MULTI_USER 
GO
ALTER DATABASE [TourDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TourDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TourDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TourDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TourDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TourDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TourDB] SET QUERY_STORE = OFF
GO
USE [TourDB]
GO
/****** Object:  Table [dbo].[TourVisits]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourVisits](
	[TourID] [int] NOT NULL,
	[CoutryID] [int] NOT NULL,
	[CityID] [int] NOT NULL,
	[HotelID] [int] NOT NULL,
	[VisitDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[TourID] ASC,
	[CoutryID] ASC,
	[CityID] ASC,
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResponsibleWorkers]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResponsibleWorkers](
	[WorkerID] [int] NOT NULL,
	[TourID] [int] NOT NULL,
 CONSTRAINT [PK_ResponsibleWorkers] PRIMARY KEY CLUSTERED 
(
	[WorkerID] ASC,
	[TourID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workers]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workers](
	[WorkerID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[PostID] [int] NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[AcceptDate] [date] NULL,
	[IsFired] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[WorkerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transport]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transport](
	[TransportID] [int] IDENTITY(1,1) NOT NULL,
	[TransportType] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[TransportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CoutryID] [int] IDENTITY(1,1) NOT NULL,
	[CoutryName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[CoutryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sights]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sights](
	[SightID] [int] IDENTITY(1,1) NOT NULL,
	[SightName] [nvarchar](max) NULL,
	[CoutryID] [int] NULL,
	[CityID] [int] NULL,
	[ImageUri] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[SightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[HotelID] [int] IDENTITY(1,1) NOT NULL,
	[HotelName] [nvarchar](max) NULL,
	[ImageUri] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tours]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tours](
	[TourID] [int] IDENTITY(1,1) NOT NULL,
	[TourName] [nvarchar](max) NULL,
	[Cost] [money] NULL,
	[StartDate] [date] NULL,
	[FinishDate] [date] NULL,
	[TransportID] [int] NULL,
	[MaxPeople] [int] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TourID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[FullTourInfo]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Transport.TransportID / Tours.TransportID

create view [dbo].[FullTourInfo] as
select Tours.TourID,
		Tours.TourName,
		Tours.Cost,
		Tours.StartDate,
		Tours.FinishDate,
		Tours.MaxPeople,
		Tours.IsDeleted,
		TransportType,
		Workers.FullName,
		Workers.Phone,
		Workers.Email,
		TourVisits.VisitDate,
		Hotels.HotelName,
		Hotels.ImageUri as HotelImageUri,
		Countries.CoutryName,
		Cities.CityName,
		Sights.SightName,
		Sights.ImageUri as SightImageUri
		from Tours
	left join Transport
	on Transport.TransportID = Tours.TransportID
	join ResponsibleWorkers
	on Tours.TourID = ResponsibleWorkers.TourID
	join Workers
	on Workers.WorkerID = ResponsibleWorkers.WorkerID
	join TourVisits
	on Tours.TourID = TourVisits.TourID
	join Hotels
	on TourVisits.HotelID = Hotels.HotelID
	join Countries
	on TourVisits.CoutryID = Countries.CoutryID
	join Cities
	on TourVisits.CityID = Cities.CityID
	join Sights
	on TourVisits.CityID = Sights.CityID
GO
/****** Object:  View [dbo].[ToursView]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--create table Posts
--(
--	PostID int primary key identity (1,1),
--	PostName nvarchar(max)
--)
--go

--create table Workers
--(
--	WorkerID int primary key identity(1,1),
--	FullName nvarchar(max),
--	PostID int foreign key references Posts(PostId),
--	Phone nvarchar(max),
--	Email nvarchar(max),
--	AcceptDate date check(AcceptDate <= GetDate()),
--	IsFired bit
--)
--go

--create table Transport
--(
--	TransportID int primary key identity(1,1),
--	TransportType nvarchar(max)
--)
--go

--create table Countries
--(
--	CoutryID int primary key identity(1,1),
--	CoutryName nvarchar(max)
--)
--go

--create table Cities
--(
--	CityID int primary key identity(1,1),
--	CityName nvarchar(max)
--)
--go

--create table Sights
--(
--	SightID int primary key identity(1,1),
--	SightName nvarchar(max),
--	CoutryID int foreign key references Countries(CoutryID),
--	CityID int foreign key references Cities(CityID),
--	ImageUri nvarchar(max),
--)
--go

--create table Hotels
--(
--	HotelID int primary key identity(1,1),
--	HotelName nvarchar(max),
--	ImageUri nvarchar(max)
--)
--go

--create table Tours
--(
--	TourID int primary key identity(1,1),
--	TourName nvarchar(max),
--	Cost money,
--	StartDate date,
--	FinishDate date,
--	TransportID int foreign key references Transport(TransportID),
--	MaxPeople int,
--	IsDeleted bit
--)
--go

--create table TourVisits
--(
--	TourID int foreign key references Tours(TourID),
--	CoutryID int foreign key references Countries(CoutryID),
--	CityID int foreign key references Cities(CityID),
--	HotelID int foreign key references Hotels(HotelID),
--	VisitDate date
--)
--go

--create table TourPackage
--(
--	TourID int foreign key references Tours(TourID),
--	SightID int foreign key references Sights(SightID),
--	Cost money,
--	Optional bit
--)
--go

--create table ResponsibleWorkers
--(
--	WorkerID int foreign key references Workers(WorkerID),
--	CoutryID int foreign key references Countries(CoutryID),
--	TourID int foreign key references Tours(TourID),
--)
--go

--create table Clients
--(
--	ClientID int primary key identity(1,1),
--	ClientFullName nvarchar(max),
--	Phone nvarchar(max),
--	Email nvarchar(max),
--	BirthDate date
--)
--go

--create table PayedTours
--(
--	TourID int foreign key references Tours(TourID),
--	ClientID int foreign key references Clients(ClientID),
--	Payment money
--)
--go

--create table PotentialTourists
--(
--	TourID int foreign key references Tours(TourID),
--	ClientID int foreign key references Clients(ClientID)
--)
--go

--create table Archive
--(
--	TourID int foreign key references Tours(TourID),
--	ClientID int foreign key references Clients(ClientID),
--	Payment money
--)
--go

--insert into Clients (ClientFullName, Phone, Email, BirthDate)
--values ('Client1', '+3800000000123', 'Client1Mail@mail.com', '2000-02-01'),
--	('Client2', '+3800001111231', 'Client2Mail@mail.com', '1999-11-24'),
--	('Client3', '+3800002222123', 'Client3Mail@mail.com', '1980-12-23'),
--	('Client4', '+3800001331123', 'Client2Mail@mail.com', '1999-11-24'),
--	('Client5', '+3800002552123', 'Client3Mail@mail.com', '1980-12-23')
--go

--insert into Transport(TransportType)
--values ('Bus'),
--	('Flight'),
--	('Train')
--go

--insert into Tours(TourName, Cost, StartDate, FinishDate, TransportID, MaxPeople, IsDeleted)
--values ('Tour1', 222, '2000-02-01', '2000-03-01', 1, 4, 1),
--	('Tour2', 2222, '2021-02-01', '2021-03-10', 2, 6, 0),
--	('Tour3', 222, '2000-02-01', '2000-03-20', 3, 4, 1),
--	('Tour4', 2422, '2021-02-23', '2021-03-01', 2, 8, 0),
--	('Tour5', 232, '1999-12-01', '2000-02-01', 1, 4, 1),
--	('Tour6', 2223, '2021-04-01', '2021-05-01', 2, 8, 0)
--go

--insert into Countries(CoutryName)
--values ('Coutry1'),
--	('Coutry2'),
--	('Coutry3'),
--	('Coutry4'),
--	('Coutry5'),
--	('Coutry6')

--insert into PayedTours(TourID, ClientID, Payment)
--values (1,2,2060),
--	(2,1, 3000),
--	(2,2,2220),
--	(2,3, 3030),
--	(3,1,2308),
--	(5,4, 3000),
--	(6,2,2030),
--	(1,5, 3040),
--	(1,4,2239),
--	(6,3, 3340)

create view [dbo].[ToursView] as
select TourID, TourName, Cost, StartDate, FinishDate, TransportID, MaxPeople
from Tours
where Tours.IsDeleted = 0
GO
/****** Object:  Table [dbo].[Archive]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Archive](
	[TourID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[Payment] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[TourID] ASC,
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[ClientFullName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[BirthDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayedTours]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayedTours](
	[TourID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[Payment] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[TourID] ASC,
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[PostID] [int] IDENTITY(1,1) NOT NULL,
	[PostName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Archive]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Archive]  WITH CHECK ADD FOREIGN KEY([TourID])
REFERENCES [dbo].[Tours] ([TourID])
GO
ALTER TABLE [dbo].[PayedTours]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[PayedTours]  WITH CHECK ADD FOREIGN KEY([TourID])
REFERENCES [dbo].[Tours] ([TourID])
GO
ALTER TABLE [dbo].[ResponsibleWorkers]  WITH CHECK ADD FOREIGN KEY([TourID])
REFERENCES [dbo].[Tours] ([TourID])
GO
ALTER TABLE [dbo].[ResponsibleWorkers]  WITH CHECK ADD FOREIGN KEY([WorkerID])
REFERENCES [dbo].[Workers] ([WorkerID])
GO
ALTER TABLE [dbo].[Sights]  WITH CHECK ADD FOREIGN KEY([CityID])
REFERENCES [dbo].[Cities] ([CityID])
GO
ALTER TABLE [dbo].[Sights]  WITH CHECK ADD FOREIGN KEY([CoutryID])
REFERENCES [dbo].[Countries] ([CoutryID])
GO
ALTER TABLE [dbo].[Tours]  WITH CHECK ADD FOREIGN KEY([TransportID])
REFERENCES [dbo].[Transport] ([TransportID])
GO
ALTER TABLE [dbo].[TourVisits]  WITH CHECK ADD FOREIGN KEY([CityID])
REFERENCES [dbo].[Cities] ([CityID])
GO
ALTER TABLE [dbo].[TourVisits]  WITH CHECK ADD FOREIGN KEY([CoutryID])
REFERENCES [dbo].[Countries] ([CoutryID])
GO
ALTER TABLE [dbo].[TourVisits]  WITH CHECK ADD FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotels] ([HotelID])
GO
ALTER TABLE [dbo].[TourVisits]  WITH CHECK ADD FOREIGN KEY([TourID])
REFERENCES [dbo].[Tours] ([TourID])
GO
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD FOREIGN KEY([PostID])
REFERENCES [dbo].[Posts] ([PostID])
GO
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD CHECK  (([AcceptDate]<=getdate()))
GO
/****** Object:  StoredProcedure [dbo].[BestArchiveTour]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[BestArchiveTour]
as
begin
	select top 1 ToursView.TourName from
    (
        select PayedTours.TourId as Id, COUNT(PayedTours.TourId) as CountId from PayedTours
            join Archive on PayedTours.TourId = Archive.TourId  group by PayedTours.TourId
    ) as Tour join ToursView on ToursView.TourId = Tour.Id order by CountId desc
end;
GO
/****** Object:  StoredProcedure [dbo].[BestOngoingTour]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[BestOngoingTour]
as
begin
	select top 1 ToursView.TourName from 
    (
        select PayedTours.TourId as Id, COUNT(PayedTours.TourId) as CountId from PayedTours  group by PayedTours.TourId
    ) as Tour join ToursView on ToursView.TourId = Tour.Id order by CountId desc
end;
GO
/****** Object:  StoredProcedure [dbo].[CheckInTour]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[CheckInTour] @FullName nvarchar(max)
as
begin
	if(GETDATE() < (select FinishDate from ToursView
								join Archive
									on ToursView.TourID = Archive.TourID
								join Clients
									on Clients.ClientID = Archive.ClientID
								where ClientFullName like @FullName))
		begin
			print('In tour')
		end;
	else
		begin
			print('Not in tour')
		end;
end;
GO
/****** Object:  StoredProcedure [dbo].[CheckLocation]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[CheckLocation] @FullName nvarchar(max)
as
begin
	if(GETDATE() < (select FinishDate from ToursView
								join Archive
									on ToursView.TourID = Archive.TourID
								join Clients
									on Clients.ClientID = Archive.ClientID
								where ClientFullName like @FullName))
		begin
			select CityName from Cities
							join TourVisits
								on Cities.CityID = TourVisits.CityID
							join ToursView
								on ToursView.TourID = TourVisits.TourID
							join Archive
								on ToursView.TourID = Archive.TourID
							join Clients
								on Clients.ClientID = Archive.ClientID
							where ClientFullName like @FullName
		end;
	else
		begin
			RAISERROR ('Client is not in tour', 16, 1)
		end;
end;
GO
/****** Object:  StoredProcedure [dbo].[CoutryTours]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CoutryTours] @Country nvarchar(max)
as
begin
	select * from ToursView
	where TourID = any(select TourID from ResponsibleWorkers
							where ResponsibleWorkers.CoutryID = (select CoutryID from Countries
																	where CoutryName like @Country))
end;
GO
/****** Object:  StoredProcedure [dbo].[MostActiveClient]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[MostActiveClient]
as
begin
	select top 1 * from
		(select PayedTours.ClientID as ID, Count(PayedTours.ClientID) as CountID from PayedTours
														group by PayedTours.ClientID)
		as Tour join Clients on Clients.ClientID = Tour.ID order by CountId desc
end;
GO
/****** Object:  StoredProcedure [dbo].[MostPopularCountry]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[MostPopularCountry]
as
begin
	select CoutryName, MAX(tb.tourCount) from (select CoutryName, Count(CoutryName) as tourCount from ToursView as tmp 
								join ResponsibleWorkers 
									on tmp.TourID = ResponsibleWorkers.TourID
								join Countries
									on ResponsibleWorkers.CoutryID = Countries.CoutryID
								group by CoutryName) as tb
							group by CoutryName
end;
GO
/****** Object:  StoredProcedure [dbo].[MostPopularHotel]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[MostPopularHotel]
as
begin
	declare @HotelsCount table (TourId int, HotelId int, Visited int);

    insert into @HotelsCount (TourId, HotelId, Visited)
    select TourId, HotelId, Count(HotelId) from TourVisits
    group by TourId, HotelId

    declare @Alltours table (TourId int);

        insert into @Alltours(TourId)
        select TourId from PayedTours

        insert into @Alltours(TourId)
        select TourId from Archive

    declare @ToursCount table (Id int, ToursCount int);
    insert into @ToursCount(Id, ToursCount)
    select TourId, Count(TourId) from @Alltours group by TourId;

    declare @HotelId int = (select top 1 HotelId from (select HotelId, Visited * ToursCount as Visited
    from @HotelsCount  join @ToursCount on Id = TourId) as Result order by Visited desc)

    select * from Hotels
    where @HotelId = Hotels.HotelID
end;
GO
/****** Object:  StoredProcedure [dbo].[SelectTourInDiapazone]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectTourInDiapazone] @Date1 date, @Date2 date
as
begin
	select * from ToursView where ToursView.StartDate between @Date1 and @Date2
end;
GO
/****** Object:  StoredProcedure [dbo].[TourByTransport]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[TourByTransport] @TransportName nvarchar(max)
as
begin
	select * from Tours
	where Tours.TransportID = (select TransportID from Transport
									where TransportType like @TransportName)
end;
GO
/****** Object:  StoredProcedure [dbo].[TourStory]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[TourStory] @FullName nvarchar(max)
as
begin
	select TourName from (select TourName from Clients 
							join Archive
								on Clients.ClientID = Archive.ClientID
							join ToursView
								on ToursView.TourID = Archive.TourID
							where ClientFullName like @FullName) as Tour
end;
GO
/****** Object:  StoredProcedure [dbo].[WorstOngoingTour]    Script Date: 01.04.2021 16:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[WorstOngoingTour]
as
begin
	select top 1 ToursView.TourName from 
    (
        select PayedTours.TourId as Id, COUNT(PayedTours.TourId) as CountId from PayedTours  group by PayedTours.TourId
    ) as Tour join ToursView on ToursView.TourId = Tour.Id order by CountId asc
end;
GO
USE [master]
GO
ALTER DATABASE [TourDB] SET  READ_WRITE 
GO
