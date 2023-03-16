CREATE DATABASE WardrobeManager
GO

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

insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('epollicott0', 'PTKGGxD6ldPl', 'PeeYPxdMmV41', 'Ealasaid', 'Pollicott', '7282352051', 'epollicott0@deviantart.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('mpinyon1', 'YbqHGJpXHH', 'W6Yn0RA8', 'Marcie', 'Pinyon', '5447148750', 'mpinyon1@sitemeter.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('calphege2', 'xlkCSWFT', '6oOFApU5', 'Carter', 'Alphege', '3465518438', 'calphege2@cornell.edu');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('lheminsley3', 'KE3zSW', 'pb4Ro9', 'Lyssa', 'Heminsley', '1384563305', 'lheminsley3@ifeng.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('sarmes4', '6SdG0kHf', 'LrSxIIn', 'Shirleen', 'Armes', '3388655173', 'sarmes4@blinklist.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('jbearne5', 'OIKSUiPHNdp', 'WBHCXCVA498J', 'Jewell', 'Bearne', '7524643759', 'jbearne5@home.pl');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('dwinchurch6', 'OLf79IL', 'p4uT02nN', 'Darcey', 'Winchurch', '2936902655', 'dwinchurch6@google.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('csweeting7', 'wEKrLIw', '01lewEHJZ', 'Claudine', 'Sweeting', '9232657485', 'csweeting7@pinterest.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('aoates8', 'nK03nrvPAqT8', 'syr84xTjD', 'Augusto', 'Oates', '1277030074', 'aoates8@google.ca');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('hcarver9', 'mKYw43h9Klk', 'JJcRyHU80BSh', 'Hayward', 'Carver', '1305297603', 'hcarver9@businessweek.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('bjouannota', 'ZhcvBa', 'vgOYidJtmB0u', 'Bennie', 'Jouannot', '3212955757', 'bjouannota@soup.io');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('gdeemb', 'zYXV0p', 'zzEQE69maH', 'Gretna', 'Deem', '6035984193', 'gdeemb@symantec.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('wlearmonthc', 'K3PWlTB3NpPX', 'jtXCfuQ1e', 'Willi', 'Learmonth', '5128574039', 'wlearmonthc@symantec.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('agrayshond', '5fU9qF9lE0SU', 'nnPttA', 'Ania', 'Grayshon', '9702953640', 'agrayshond@github.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('jgorche', 'yEouWSbhHkl', 'BvdV5L4L', 'Juline', 'Gorch', '4698877516', 'jgorche@yellowbook.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('ndainesf', 'g6le66G0K', 'etVxF7xZtk', 'Nap', 'Daines', '4571296291', 'ndainesf@huffingtonpost.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('mkisbyg', 'pri7QX9m', '51qGfbx', 'Midge', 'Kisby', '3562091534', 'mkisbyg@t.co');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('gblaxillh', 'sByoe6OUD', 'slH2nDjB', 'Gisele', 'Blaxill', '6704071947', 'gblaxillh@ihg.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('adaouti', 'ApqGhygdnt', 'blIeVDVw', 'Aubrette', 'Daout', '6896055365', 'adaouti@is.gd');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('rmaiorj', 'k2kF50yI', 'aeftGxo', 'Rawley', 'Maior', '8049781898', 'rmaiorj@amazon.co.uk');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('cleipnikk', 'r1JfzwYf2', 'XMvLkPYX', 'Corny', 'Leipnik', '4667672426', 'cleipnikk@discovery.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('lgrogonol', 'naa1GwUYyP9', 'UoFhPOIK1en', 'Lezley', 'Grogono', '8524143248', 'lgrogonol@jimdo.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('chullahm', '8JZQN5b5R', 'r4jf8y5S', 'Cristionna', 'Hullah', '8819204780', 'chullahm@hexun.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('kosgarbyn', 'lMtE7Ck', '5tKi9loM', 'Kort', 'Osgarby', '6447468032', 'kosgarbyn@nih.gov');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('blotso', '8gkXsxA', 'jz0qRy', 'Berkie', 'Lots', '3908742981', 'blotso@kickstarter.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('hivensp', 'wYHUxPtpYdOt', 'fahSOKw', 'Hastie', 'Ivens', '4466616208', 'hivensp@cdc.gov');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('jartinstallq', 'gwGGMVWSpG', '2JX3VXsFj', 'Joletta', 'Artinstall', '5718788233', 'jartinstallq@timesonline.co.uk');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('uzanucioliir', '1xEXofulU', 'ldgJmoRlny', 'Ursola', 'Zanuciolii', '4241680861', 'uzanucioliir@privacy.gov.au');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('jentwisles', 'H1KcKlsv8nd', 'zqKlJQbO7z', 'Jennine', 'Entwisle', '7847532504', 'jentwisles@list-manage.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('rhaggartyt', 'RTlzST3Aq', 'gGVFNDWOT', 'Rosalind', 'Haggarty', '1069289948', 'rhaggartyt@ucla.edu');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('lleadstonu', '9O9Der0wITL', 'KTCblvYHPhc', 'Leonard', 'Leadston', '3036599299', 'lleadstonu@123-reg.co.uk');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('mwingeattv', 'vTmPRnNYVh', 'l2D9R9c0oc', 'Marchelle', 'Wingeatt', '7327231157', 'mwingeattv@redcross.org');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('hshakshaftw', 'YKVAx4QetQj', 'c7GJV1Ql9', 'Hermia', 'Shakshaft', '1119458163', 'hshakshaftw@soup.io');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('vmealex', 'z7DSW7gs', '2ElmEeQS', 'Valida', 'Meale', '8436722326', 'vmealex@w3.org');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('shasemany', 'XlkEp4RIrt3q', 'ArZ9auxakISR', 'Shaine', 'Haseman', '1769852473', 'shasemany@dedecms.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('edagnanz', 'EwpszOuJ', 'HwXDvy', 'Evonne', 'Dagnan', '6612452088', 'edagnanz@princeton.edu');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('cgrimmolby10', 'qwtVzq6', 'x6GVxqXsNr', 'Claudius', 'Grimmolby', '1011102770', 'cgrimmolby10@jugem.jp');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('irevans11', 'iEedIRcX8FM', 'GYH2qeBZF', 'Izak', 'Revans', '6049529062', 'irevans11@hao123.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('csmartman12', '7elhJf', '6N2Vcva', 'Cornela', 'Smartman', '2793233238', 'csmartman12@nhs.uk');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('caaronsohn13', 'zTCFGy3', 'Qw3WgW0p', 'Cherish', 'Aaronsohn', '4496277841', 'caaronsohn13@msn.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('tcastree14', 'VS15wOA', '26ale4ipEx', 'Terrel', 'Castree', '5058128814', 'tcastree14@google.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('ohoy15', '0EshH91aPXRZ', 'PqxP7y', 'Orsola', 'Hoy', '4941412525', 'ohoy15@hao123.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('tpetera16', 'WFeFIfpA0ol9', 'brgtcEA', 'Tyler', 'Petera', '2858171672', 'tpetera16@hp.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('alefriec17', 'sKp35aRmZ', 'rj39O3RYzfCy', 'Amil', 'Le Friec', '8665654178', 'alefriec17@gravatar.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('nbrumpton18', 'hAy1VighE1HB', 'VPrjrWn', 'Nikolos', 'Brumpton', '1131611197', 'nbrumpton18@nyu.edu');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('dosmar19', 'xQi0v8fVqTu', 'YjiOvDQW', 'Daniela', 'Osmar', '7328397684', 'dosmar19@globo.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('bkeightley1a', 'reqhPH1JvF', '3UXubrA3Df', 'Bertrando', 'Keightley', '5049627636', 'bkeightley1a@gov.uk');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('ececely1b', 'SmdoOjR', '8HqPJvx2V0', 'Erika', 'Cecely', '2704550828', 'ececely1b@upenn.edu');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('bgodfery1c', 'ZA6TyG', 'OUFooVe', 'Bondon', 'Godfery', '1723094996', 'bgodfery1c@jiathis.com');
insert into [Users] ([Username], [Password], [Salt], [FirstName], [LastName], [Phone], [Email]) values ('tkynoch1d', 'eKEjl1', 'UtPVdBk', 'Talbot', 'Kynoch', '8392783595', 'tkynoch1d@auda.org.au');

insert into [Outfits] ([Name], [Date]) values ('Domainer', '2022-05-09');
insert into [Outfits] ([Name], [Date]) values ('Bigtax', '2022-02-10');
insert into [Outfits] ([Name], [Date]) values ('Cardguard', '2022-03-14');
insert into [Outfits] ([Name], [Date]) values ('Fixflex', '2022-09-10');
insert into [Outfits] ([Name], [Date]) values ('Kanlam', '2022-06-22');
insert into [Outfits] ([Name], [Date]) values ('Job', '2022-03-10');
insert into [Outfits] ([Name], [Date]) values ('Zaam-Dox', '2022-11-18');
insert into [Outfits] ([Name], [Date]) values ('Tampflex', '2022-06-22');
insert into [Outfits] ([Name], [Date]) values ('Bitchip', '2022-07-19');
insert into [Outfits] ([Name], [Date]) values ('Holdlamis', '2022-07-02');
insert into [Outfits] ([Name], [Date]) values ('Bamity', '2022-04-13');
insert into [Outfits] ([Name], [Date]) values ('Konklab', '2022-04-15');
insert into [Outfits] ([Name], [Date]) values ('Regrant', '2022-01-16');
insert into [Outfits] ([Name], [Date]) values ('Aerified', '2022-11-24');
insert into [Outfits] ([Name], [Date]) values ('Sonair', '2022-03-01');
insert into [Outfits] ([Name], [Date]) values ('Treeflex', '2022-06-25');
insert into [Outfits] ([Name], [Date]) values ('Kanlam', '2022-08-07');
insert into [Outfits] ([Name], [Date]) values ('Latlux', '2022-03-05');
insert into [Outfits] ([Name], [Date]) values ('Prodder', '2022-03-16');
insert into [Outfits] ([Name], [Date]) values ('Viva', '2022-02-05');
insert into [Outfits] ([Name], [Date]) values ('Stronghold', '2022-05-05');
insert into [Outfits] ([Name], [Date]) values ('Bitchip', '2022-01-22');
insert into [Outfits] ([Name], [Date]) values ('Aerified', '2022-01-19');
insert into [Outfits] ([Name], [Date]) values ('Sonsing', '2022-11-08');
insert into [Outfits] ([Name], [Date]) values ('Sonair', '2022-08-04');
insert into [Outfits] ([Name], [Date]) values ('Lotlux', '2022-06-01');
insert into [Outfits] ([Name], [Date]) values ('Alphazap', '2022-07-27');
insert into [Outfits] ([Name], [Date]) values ('Lotlux', '2022-05-02');
insert into [Outfits] ([Name], [Date]) values ('Cardify', '2022-07-29');
insert into [Outfits] ([Name], [Date]) values ('Hatity', '2022-05-07');
insert into [Outfits] ([Name], [Date]) values ('Home Ing', '2022-02-24');
insert into [Outfits] ([Name], [Date]) values ('Konklux', '2022-03-24');
insert into [Outfits] ([Name], [Date]) values ('Cardguard', '2022-06-12');
insert into [Outfits] ([Name], [Date]) values ('Rank', '2022-04-18');
insert into [Outfits] ([Name], [Date]) values ('Otcom', '2022-08-15');
insert into [Outfits] ([Name], [Date]) values ('Solarbreeze', '2022-12-28');
insert into [Outfits] ([Name], [Date]) values ('Zaam-Dox', '2022-05-10');
insert into [Outfits] ([Name], [Date]) values ('Keylex', '2022-01-08');
insert into [Outfits] ([Name], [Date]) values ('Stringtough', '2022-08-12');
insert into [Outfits] ([Name], [Date]) values ('Pannier', '2022-11-28');
insert into [Outfits] ([Name], [Date]) values ('Hatity', '2022-03-08');
insert into [Outfits] ([Name], [Date]) values ('Pannier', '2022-10-30');
insert into [Outfits] ([Name], [Date]) values ('Bamity', '2022-03-30');
insert into [Outfits] ([Name], [Date]) values ('Tempsoft', '2022-03-25');
insert into [Outfits] ([Name], [Date]) values ('Daltfresh', '2022-09-16');
insert into [Outfits] ([Name], [Date]) values ('Alpha', '2022-10-19');
insert into [Outfits] ([Name], [Date]) values ('Zoolab', '2022-05-05');
insert into [Outfits] ([Name], [Date]) values ('Konklab', '2022-12-14');
insert into [Outfits] ([Name], [Date]) values ('Y-Solowarm', '2022-09-01');
insert into [Outfits] ([Name], [Date]) values ('Cookley', '2022-08-29');

insert into [Clothes] ([Name], [Picture], [UserId]) values ('Alpha', 6611, 32);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Rank', 7260, 3);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Andalax', 2717, 7);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Keylex', 6660, 16);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Gembucket', 2910, 11);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Zoolab', 7297, 31);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Trippledex', 7317, 6);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Zoolab', 627, 26);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Domainer', 8000, 38);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Cardify', 1443, 31);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Bitwolf', 3412, 33);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Treeflex', 2472, 5);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Zaam-Dox', 6937, 40);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Konklab', 2739, 14);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Stim', 5304, 24);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Alphazap', 2761, 33);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Hatity', 5162, 30);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Flowdesk', 2112, 22);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Asoka', 1168, 4);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Stringtough', 7829, 1);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Tampflex', 5890, 24);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Redhold', 5144, 49);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Fintone', 1384, 7);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Toughjoyfax', 2334, 7);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Sonsing', 5849, 33);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Flexidy', 6477, 32);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Span', 604, 2);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Bamity', 3013, 16);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Tresom', 4480, 38);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Zontrax', 508, 48);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Voyatouch', 6647, 44);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Daltfresh', 1124, 12);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Fintone', 2007, 44);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Lotstring', 3965, 1);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Hatity', 2810, 16);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Kanlam', 3123, 9);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Voltsillam', 6058, 34);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Biodex', 3353, 6);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Tampflex', 1132, 48);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Asoka', 4277, 24);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Aerified', 3770, 14);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Ventosanzap', 3, 8);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Sonair', 968, 27);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Cardify', 6409, 27);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Fintone', 5201, 42);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Fixflex', 6424, 6);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Cardguard', 5638, 28);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Alphazap', 5731, 50);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Matsoft', 1373, 47);
insert into [Clothes] ([Name], [Picture], [UserId]) values ('Veribet', 1183, 9);

insert into [Colors] ([Name]) values ('Indigo');
insert into [Colors] ([Name]) values ('Orange');
insert into [Colors] ([Name]) values ('Pink');
insert into [Colors] ([Name]) values ('Aquamarine');
insert into [Colors] ([Name]) values ('Teal');
insert into [Colors] ([Name]) values ('Crimson');
insert into [Colors] ([Name]) values ('Violet');
insert into [Colors] ([Name]) values ('Mauv');
insert into [Colors] ([Name]) values ('Goldenrod');
insert into [Colors] ([Name]) values ('Turquoise');
insert into [Colors] ([Name]) values ('Orange');
insert into [Colors] ([Name]) values ('Violet');
insert into [Colors] ([Name]) values ('Fuscia');
insert into [Colors] ([Name]) values ('Turquoise');
insert into [Colors] ([Name]) values ('Fuscia');
insert into [Colors] ([Name]) values ('Orange');
insert into [Colors] ([Name]) values ('Pink');
insert into [Colors] ([Name]) values ('Khaki');
insert into [Colors] ([Name]) values ('Puce');
insert into [Colors] ([Name]) values ('Pink');
insert into [Colors] ([Name]) values ('Aquamarine');
insert into [Colors] ([Name]) values ('Teal');
insert into [Colors] ([Name]) values ('Goldenrod');
insert into [Colors] ([Name]) values ('Indigo');
insert into [Colors] ([Name]) values ('Violet');
insert into [Colors] ([Name]) values ('Fuscia');
insert into [Colors] ([Name]) values ('Teal');
insert into [Colors] ([Name]) values ('Teal');
insert into [Colors] ([Name]) values ('Purple');
insert into [Colors] ([Name]) values ('Maroon');
insert into [Colors] ([Name]) values ('Violet');
insert into [Colors] ([Name]) values ('Crimson');
insert into [Colors] ([Name]) values ('Puce');
insert into [Colors] ([Name]) values ('Blue');
insert into [Colors] ([Name]) values ('Khaki');
insert into [Colors] ([Name]) values ('Fuscia');
insert into [Colors] ([Name]) values ('Orange');
insert into [Colors] ([Name]) values ('Khaki');
insert into [Colors] ([Name]) values ('Pink');
insert into [Colors] ([Name]) values ('Crimson');
insert into [Colors] ([Name]) values ('Crimson');
insert into [Colors] ([Name]) values ('Crimson');
insert into [Colors] ([Name]) values ('Puce');
insert into [Colors] ([Name]) values ('Puce');
insert into [Colors] ([Name]) values ('Pink');
insert into [Colors] ([Name]) values ('Blue');
insert into [Colors] ([Name]) values ('Orange');
insert into [Colors] ([Name]) values ('Pink');
insert into [Colors] ([Name]) values ('Yellow');
insert into [Colors] ([Name]) values ('Mauv');

insert into [Types] ([Name]) values ('Fixflex');
insert into [Types] ([Name]) values ('Zoolab');
insert into [Types] ([Name]) values ('Alpha');
insert into [Types] ([Name]) values ('Konklab');
insert into [Types] ([Name]) values ('Rank');
insert into [Types] ([Name]) values ('Domainer');
insert into [Types] ([Name]) values ('Alpha');
insert into [Types] ([Name]) values ('Y-find');
insert into [Types] ([Name]) values ('Bytecard');
insert into [Types] ([Name]) values ('Zamit');
insert into [Types] ([Name]) values ('Tampflex');
insert into [Types] ([Name]) values ('It');
insert into [Types] ([Name]) values ('Tempsoft');
insert into [Types] ([Name]) values ('Zathin');
insert into [Types] ([Name]) values ('Quo Lux');
insert into [Types] ([Name]) values ('Span');
insert into [Types] ([Name]) values ('Ronstring');
insert into [Types] ([Name]) values ('Gembucket');
insert into [Types] ([Name]) values ('Temp');
insert into [Types] ([Name]) values ('Opela');
insert into [Types] ([Name]) values ('Tres-Zap');
insert into [Types] ([Name]) values ('Zoolab');
insert into [Types] ([Name]) values ('Voyatouch');
insert into [Types] ([Name]) values ('Lotlux');
insert into [Types] ([Name]) values ('Bigtax');
insert into [Types] ([Name]) values ('Mat Lam Tam');
insert into [Types] ([Name]) values ('Duobam');
insert into [Types] ([Name]) values ('Sonair');
insert into [Types] ([Name]) values ('Sonsing');
insert into [Types] ([Name]) values ('Hatity');
insert into [Types] ([Name]) values ('Biodex');
insert into [Types] ([Name]) values ('Sonair');
insert into [Types] ([Name]) values ('Konklab');
insert into [Types] ([Name]) values ('Stringtough');
insert into [Types] ([Name]) values ('Stringtough');
insert into [Types] ([Name]) values ('Konklab');
insert into [Types] ([Name]) values ('Keylex');
insert into [Types] ([Name]) values ('Zamit');
insert into [Types] ([Name]) values ('Wrapsafe');
insert into [Types] ([Name]) values ('Zontrax');
insert into [Types] ([Name]) values ('Sonair');
insert into [Types] ([Name]) values ('Lotstring');
insert into [Types] ([Name]) values ('Ventosanzap');
insert into [Types] ([Name]) values ('Solarbreeze');
insert into [Types] ([Name]) values ('Latlux');
insert into [Types] ([Name]) values ('Flexidy');
insert into [Types] ([Name]) values ('Rank');
insert into [Types] ([Name]) values ('Alphazap');
insert into [Types] ([Name]) values ('Cardify');
insert into [Types] ([Name]) values ('Opela');

insert into [UsersOutfits] ([UserId], [OutfitId]) values (24, 30);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (37, 27);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (48, 5);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (11, 23);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (31, 47);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (16, 44);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (50, 33);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (27, 50);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (44, 22);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (4, 10);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (27, 18);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (20, 26);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (46, 50);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (12, 18);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (28, 12);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (40, 42);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (46, 10);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (39, 35);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (47, 30);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (49, 15);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (13, 50);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (26, 33);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (30, 31);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (33, 43);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (12, 48);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (22, 20);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (37, 50);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (33, 13);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (36, 49);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (17, 33);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (15, 41);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (43, 4);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (12, 11);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (43, 21);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (21, 49);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (16, 6);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (17, 50);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (34, 35);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (42, 36);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (13, 45);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (32, 3);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (37, 33);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (9, 45);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (15, 39);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (28, 49);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (44, 9);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (34, 38);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (32, 39);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (26, 36);
insert into [UsersOutfits] ([UserId], [OutfitId]) values (43, 5);

insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (7, 29);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (43, 34);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (23, 43);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (9, 30);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (10, 4);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (2, 10);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (33, 41);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (41, 47);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (11, 26);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (24, 35);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (48, 17);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (28, 38);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (23, 47);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (44, 46);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (17, 29);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (37, 17);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (45, 26);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (17, 13);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (47, 29);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (22, 31);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (21, 25);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (46, 26);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (48, 29);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (35, 33);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (11, 13);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (34, 9);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (35, 23);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (40, 8);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (3, 50);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (13, 32);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (36, 10);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (42, 33);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (48, 40);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (3, 33);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (29, 46);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (16, 6);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (21, 13);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (22, 10);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (37, 5);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (31, 42);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (32, 9);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (17, 50);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (16, 26);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (19, 12);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (26, 50);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (13, 21);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (12, 22);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (2, 31);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (49, 15);
insert into [OutfitsClothes] ([OutfitId], [ClotheId]) values (31, 32);

insert into [ClothesColors] ([ClotheId], [ColorId]) values (28, 49);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (16, 6);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (19, 2);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (11, 29);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (12, 34);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (24, 44);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (37, 48);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (25, 21);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (13, 13);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (46, 10);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (4, 43);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (37, 36);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (9, 48);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (11, 8);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (10, 46);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (8, 16);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (37, 2);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (37, 38);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (17, 43);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (41, 47);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (29, 11);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (4, 28);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (10, 6);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (7, 13);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (2, 35);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (22, 27);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (44, 12);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (46, 1);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (11, 23);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (26, 1);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (34, 3);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (38, 28);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (32, 23);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (20, 30);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (3, 43);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (42, 6);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (50, 50);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (32, 10);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (1, 27);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (1, 2);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (39, 46);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (26, 13);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (9, 32);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (1, 37);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (9, 35);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (40, 36);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (22, 46);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (19, 19);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (17, 42);
insert into [ClothesColors] ([ClotheId], [ColorId]) values (20, 2);

insert into [ClothesTypes] ([ClotheId], [TypeId]) values (27, 41);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (47, 32);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (10, 47);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (25, 40);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (35, 9);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (46, 29);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (46, 35);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (44, 7);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (12, 36);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (8, 4);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (17, 16);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (8, 13);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (6, 45);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (21, 35);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (47, 31);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (9, 37);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (28, 41);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (46, 30);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (12, 43);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (7, 40);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (14, 45);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (50, 10);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (7, 1);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (49, 17);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (8, 25);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (35, 44);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (10, 25);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (44, 40);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (34, 25);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (37, 13);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (36, 20);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (29, 40);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (31, 47);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (10, 31);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (49, 19);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (18, 33);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (28, 21);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (6, 9);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (28, 20);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (47, 7);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (26, 19);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (20, 14);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (7, 33);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (1, 45);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (18, 40);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (8, 34);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (4, 15);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (37, 23);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (7, 38);
insert into [ClothesTypes] ([ClotheId], [TypeId]) values (4, 21);