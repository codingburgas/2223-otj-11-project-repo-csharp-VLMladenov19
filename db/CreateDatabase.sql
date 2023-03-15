--CREATE DATABASE WardrobeManager
--GO

USE WardrobeManager

--DROP TABLE [UsersOutfits]
--DROP TABLE [OutfitsClothes]
--DROP TABLE [ClothesColors]
--DROP TABLE [ClothesTypes]
--DROP TABLE [Users]
--DROP TABLE [Outfits]
--DROP TABLE [Clothes]
--DROP TABLE [Colors]
--DROP TABLE [Types]

CREATE TABLE [Users] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Username] varchar(50) NOT NULL UNIQUE, 
	[Password] varchar(50) NOT NULL,
	[Salt] varchar(50) NOT NULL,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[Phone] bigint NOT NULL,
	[Email] varchar(50) NOT NULL
)

CREATE TABLE [Outfits] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50) NOT NULL,
	[Date] date NOT NULL
)

CREATE TABLE [Clothes] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50) NOT NULL,
	[Type] varchar(50),
	[Picture] varbinary(max),
	[UserId] int FOREIGN KEY REFERENCES [Users]([Id])
)

CREATE TABLE [Colors] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50) NOT NULL
)

CREATE TABLE [Types] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50) NOT NULL
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

CREATE TABLE [ClothesTypes] (
	[ClotheId] int,
	[TypeId] int,
	FOREIGN KEY ([ClotheId]) REFERENCES [Clothes]([Id]),
	FOREIGN KEY ([TypeId]) REFERENCES [Types]([Id])
)