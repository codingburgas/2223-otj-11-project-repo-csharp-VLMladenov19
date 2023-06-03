CREATE DATABASE WardrobeManager
GO

USE WardrobeManager

--DROP TABLE [OutfitsClothes]
--DROP TABLE [ClothesColors]
--DROP TABLE [Users]
--DROP TABLE [Outfits]
--DROP TABLE [Clothes]
--DROP TABLE [Colors]
--DROP TABLE [Types]

CREATE TABLE [Users] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Username] varchar(50) NOT NULL UNIQUE, 
	[Password] varchar(64) NOT NULL,
	[Salt] varchar(50) NOT NULL,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[Email] varchar(50) NOT NULL
)

CREATE TABLE [Outfits] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50) NOT NULL,
	[Date] date NOT NULL,
	[UserId] int FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL
)

CREATE TABLE [Types] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50) NOT NULL UNIQUE
)

CREATE TABLE [Clothes] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50) NOT NULL,
	[Picture] varbinary(max),
	[UserId] int FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL,
	[TypeId] int FOREIGN KEY REFERENCES [Types]([Id])
)

CREATE TABLE [Colors] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50) NOT NULL UNIQUE
)

CREATE TABLE [OutfitClothes] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[OutfitId] int,
	[ClotheId] int,
	FOREIGN KEY ([OutfitId]) REFERENCES [Outfits]([Id]),
	FOREIGN KEY ([ClotheId]) REFERENCES [Clothes]([Id])
)

CREATE TABLE [ClotheColors] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[ClotheId] int,
	[ColorId] int,
	FOREIGN KEY ([ClotheId]) REFERENCES [Clothes]([Id]),
	FOREIGN KEY ([ColorId]) REFERENCES [Colors]([Id])
)

INSERT INTO [Types] ([Name]) VALUES ('T-Shirt');
INSERT INTO [Types] ([Name]) VALUES ('Jeans');
INSERT INTO [Types] ([Name]) VALUES ('Sweater');
INSERT INTO [Types] ([Name]) VALUES ('Shorts');
INSERT INTO [Types] ([Name]) VALUES ('Skirt');
INSERT INTO [Types] ([Name]) VALUES ('Jacket');
INSERT INTO [Types] ([Name]) VALUES ('Blouse');
INSERT INTO [Types] ([Name]) VALUES ('Pants');
INSERT INTO [Types] ([Name]) VALUES ('Dress');
INSERT INTO [Types] ([Name]) VALUES ('Suit');
INSERT INTO [Types] ([Name]) VALUES ('Coat');
INSERT INTO [Types] ([Name]) VALUES ('Hoodie');
INSERT INTO [Types] ([Name]) VALUES ('Cardigan');
INSERT INTO [Types] ([Name]) VALUES ('Sweatshirt');
INSERT INTO [Types] ([Name]) VALUES ('Tank Top');
INSERT INTO [Types] ([Name]) VALUES ('Capri Pants');
INSERT INTO [Types] ([Name]) VALUES ('Swimsuit');
INSERT INTO [Types] ([Name]) VALUES ('Bikini');
INSERT INTO [Types] ([Name]) VALUES ('Pajamas');
INSERT INTO [Types] ([Name]) VALUES ('Robe');
INSERT INTO [Types] ([Name]) VALUES ('Blazer');
INSERT INTO [Types] ([Name]) VALUES ('Leggings');
INSERT INTO [Types] ([Name]) VALUES ('Jumpsuit');
INSERT INTO [Types] ([Name]) VALUES ('Romper');
INSERT INTO [Types] ([Name]) VALUES ('Sarong');
INSERT INTO [Types] ([Name]) VALUES ('Tunic');
INSERT INTO [Types] ([Name]) VALUES ('Sweatpants');
INSERT INTO [Types] ([Name]) VALUES ('Overalls');
INSERT INTO [Types] ([Name]) VALUES ('Raincoat');
INSERT INTO [Types] ([Name]) VALUES ('Windbreaker');
INSERT INTO [Types] ([Name]) VALUES ('Parka');
INSERT INTO [Types] ([Name]) VALUES ('Puffer Jacket');
INSERT INTO [Types] ([Name]) VALUES ('Vest');
INSERT INTO [Types] ([Name]) VALUES ('Peacoat');
INSERT INTO [Types] ([Name]) VALUES ('Kimono');
INSERT INTO [Types] ([Name]) VALUES ('Poncho');
INSERT INTO [Types] ([Name]) VALUES ('Sweater Vest');
INSERT INTO [Types] ([Name]) VALUES ('Sleeveless Jacket');
INSERT INTO [Types] ([Name]) VALUES ('Bomber Jacket');
INSERT INTO [Types] ([Name]) VALUES ('Denim Jacket');
INSERT INTO [Types] ([Name]) VALUES ('Leather Jacket');
INSERT INTO [Types] ([Name]) VALUES ('Biker Jacket');
INSERT INTO [Types] ([Name]) VALUES ('Polo Shirt');
INSERT INTO [Types] ([Name]) VALUES ('Henley Shirt');
INSERT INTO [Types] ([Name]) VALUES ('Dress Shirt');
INSERT INTO [Types] ([Name]) VALUES ('Flannel Shirt');
INSERT INTO [Types] ([Name]) VALUES ('Turtleneck');
INSERT INTO [Types] ([Name]) VALUES ('Button-Down Shirt');
INSERT INTO [Types] ([Name]) VALUES ('Crop Top');
INSERT INTO [Types] ([Name]) VALUES ('Bodysuit');

INSERT INTO [Colors] ([Name]) VALUES ('Red');
INSERT INTO [Colors] ([Name]) VALUES ('Orange');
INSERT INTO [Colors] ([Name]) VALUES ('Yellow');
INSERT INTO [Colors] ([Name]) VALUES ('Green');
INSERT INTO [Colors] ([Name]) VALUES ('Blue');
INSERT INTO [Colors] ([Name]) VALUES ('Purple');
INSERT INTO [Colors] ([Name]) VALUES ('Pink');
INSERT INTO [Colors] ([Name]) VALUES ('Black');
INSERT INTO [Colors] ([Name]) VALUES ('White');
INSERT INTO [Colors] ([Name]) VALUES ('Gray');
INSERT INTO [Colors] ([Name]) VALUES ('Brown');
INSERT INTO [Colors] ([Name]) VALUES ('Beige');
INSERT INTO [Colors] ([Name]) VALUES ('Turquoise');
INSERT INTO [Colors] ([Name]) VALUES ('Lavender');
INSERT INTO [Colors] ([Name]) VALUES ('Magenta');
INSERT INTO [Colors] ([Name]) VALUES ('Olive');
INSERT INTO [Colors] ([Name]) VALUES ('Cyan');
INSERT INTO [Colors] ([Name]) VALUES ('Maroon');
INSERT INTO [Colors] ([Name]) VALUES ('Navy');
INSERT INTO [Colors] ([Name]) VALUES ('Teal');
INSERT INTO [Colors] ([Name]) VALUES ('Silver');
INSERT INTO [Colors] ([Name]) VALUES ('Gold');
INSERT INTO [Colors] ([Name]) VALUES ('Aquamarine');
INSERT INTO [Colors] ([Name]) VALUES ('Azure');
INSERT INTO [Colors] ([Name]) VALUES ('Burgundy');
INSERT INTO [Colors] ([Name]) VALUES ('Chartreuse');
INSERT INTO [Colors] ([Name]) VALUES ('Crimson');
INSERT INTO [Colors] ([Name]) VALUES ('Fuchsia');
INSERT INTO [Colors] ([Name]) VALUES ('Indigo');
INSERT INTO [Colors] ([Name]) VALUES ('Khaki');
INSERT INTO [Colors] ([Name]) VALUES ('Lime');
INSERT INTO [Colors] ([Name]) VALUES ('Mint');
INSERT INTO [Colors] ([Name]) VALUES ('Peach');
INSERT INTO [Colors] ([Name]) VALUES ('Periwinkle');
INSERT INTO [Colors] ([Name]) VALUES ('Sage');
INSERT INTO [Colors] ([Name]) VALUES ('Salmon');
INSERT INTO [Colors] ([Name]) VALUES ('Sienna');
INSERT INTO [Colors] ([Name]) VALUES ('Tangerine');
INSERT INTO [Colors] ([Name]) VALUES ('Violet');
INSERT INTO [Colors] ([Name]) VALUES ('Coral');
INSERT INTO [Colors] ([Name]) VALUES ('Electric Blue');
INSERT INTO [Colors] ([Name]) VALUES ('Forest Green');
INSERT INTO [Colors] ([Name]) VALUES ('Hot Pink');
INSERT INTO [Colors] ([Name]) VALUES ('Midnight Blue');
INSERT INTO [Colors] ([Name]) VALUES ('Mustard');
INSERT INTO [Colors] ([Name]) VALUES ('Pale Blue');
INSERT INTO [Colors] ([Name]) VALUES ('Plum');
INSERT INTO [Colors] ([Name]) VALUES ('Ruby');
INSERT INTO [Colors] ([Name]) VALUES ('Sapphire');
INSERT INTO [Colors] ([Name]) VALUES ('Terracotta');