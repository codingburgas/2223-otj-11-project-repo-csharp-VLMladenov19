--CREATE DATABASE WardrobeManager
--GO

USE WardrobeManager

--DROP TABLE [Libraries]
--DROP TABLE [Users]
--DROP TABLE [Outfits]
--DROP TABLE [Clothes]
--DROP TABLE [Colors]
--DROP TABLE [UsersOutfits]
--DROP TABLE [OutfitsClothes]
--DROP TABLE [ClothesColors]
--DROP TABLE [ClothesLibraries]

CREATE TABLE [Libraries](
	[Id] INT PRIMARY KEY IDENTITY(1,1)
)

CREATE TABLE [Users] (
	[Id] INT PRIMARY KEY IDENTITY(1,1),  -- UNIQUE NOT NULL
	[Username] varchar(50), 
	[Password] varchar(50),
	[FirstName] nvarchar(50),
	[LastName] nvarchar(50),
	[Phone] int,
	[Email] varchar(50),
	[LibraryId] int FOREIGN KEY REFERENCES [Libraries]([Id])
)

CREATE TABLE [Outfits] (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50),
	[Date] date
)

CREATE TABLE [Clothes] (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50),
	[Type] varchar(50),
	[Picture] varbinary
)

CREATE TABLE [Colors] (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50)
)

CREATE TABLE [UsersOutfits] (
	[UserId] int,
	[OutfitId] int,
	PRIMARY KEY([UserId], [OutfitId]),
	FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
	FOREIGN KEY ([OutfitId]) REFERENCES [Outfits]([Id])
)

CREATE TABLE [OutfitsClothes] (
	[OutfitId] int,
	[ClotheId] int,
	PRIMARY KEY([OutfitId], [ClotheId]),
	FOREIGN KEY ([OutfitId]) REFERENCES [Outfits]([Id]),
	FOREIGN KEY ([ClotheId]) REFERENCES [Clothes]([Id])
)

CREATE TABLE [ClothesColors] (
	[ClotheId] int,
	[ColorId] int,
	PRIMARY KEY([ClotheId], [ColorId]),
	FOREIGN KEY ([ClotheId]) REFERENCES [Clothes]([Id]),
	FOREIGN KEY ([ColorId]) REFERENCES [Colors]([Id])
)

CREATE TABLE [ClothesLibraries] (
	[ClotheId] int,
	[LibraryId] int,
	PRIMARY KEY([ClotheId], [LibraryId]),
	FOREIGN KEY ([ClotheId]) REFERENCES [Clothes]([Id]),
	FOREIGN KEY ([LibraryId]) REFERENCES [Libraries]([Id])
)