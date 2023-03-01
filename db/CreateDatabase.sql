--CREATE DATABASE WardrobeManager
--GO

USE WardrobeManager

--DROP TABLE [UsersOutfits]
--DROP TABLE [OutfitsClothes]
--DROP TABLE [ClothesColors]
--DROP TABLE [ClothesLibraries]
--DROP TABLE [Users]
--DROP TABLE [Outfits]
--DROP TABLE [Clothes]
--DROP TABLE [Colors]
--DROP TABLE [Libraries]

CREATE TABLE [Libraries](
	[Id] int PRIMARY KEY IDENTITY(1,1)
)

CREATE TABLE [Users] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Username] varchar(50), 
	[Password] varchar(50),
	[FirstName] nvarchar(50),
	[LastName] nvarchar(50)	[Phone] bigint,
	[Email] varchar(50),
	[LibraryId] int FOREIGN KEY REFERENCES [Libraries]([Id])
)

CREATE TABLE [Outfits] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50),
	[Date] date
)

CREATE TABLE [Clothes] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50),
	[Type] varchar(50),
	[Picture] varbinary(max)
)

CREATE TABLE [Colors] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50)
)

CREATE TABLE [UsersOutfits] (
	[UserId] int,
	[OutfitId] int,
	FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
	FOREIGN KEY ([OutfitId]) REFERENCES [Outfits]([Id])
)

CREATE TABLE [OutfitsClothes] (
	[OutfitId] int,
	[ClotheId] int,
	FOREIGN KEY ([OutfitId]) REFERENCES [Outfits]([Id]),
	FOREIGN KEY ([ClotheId]) REFERENCES [Clothes]([Id])
)

CREATE TABLE [ClothesColors] (
	[ClotheId] int,
	[ColorId] int,
	FOREIGN KEY ([ClotheId]) REFERENCES [Clothes]([Id]),
	FOREIGN KEY ([ColorId]) REFERENCES [Colors]([Id])
)

CREATE TABLE [ClothesLibraries] (
	[ClotheId] int,
	[LibraryId] int,
	FOREIGN KEY ([ClotheId]) REFERENCES [Clothes]([Id]),
	FOREIGN KEY ([LibraryId]) REFERENCES [Libraries]([Id])
)