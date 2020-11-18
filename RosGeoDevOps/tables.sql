--DROP DATABASE RosGeoDevOps
go
CREATE DATABASE RosGeoDevOps
go
USE RosGeoDevOps
go


CREATE TABLE Auth
(
	ID_Auth int  NOT NULL ,
	Login varchar(max)  NOT NULL ,
	Password varchar(max)  NOT NULL ,
	ID_Sotrudnik int  NULL ,
	ID_Role int  NOT NULL 
)
go


ALTER TABLE Auth
	ADD CONSTRAINT XPKАвторизация PRIMARY KEY  CLUSTERED (ID_Auth ASC)
go


CREATE TABLE Mehanizm
(
	ID_Mehanizm int  NOT NULL ,
	Naim varchar(max)  NOT NULL ,
	Opis varchar(max)  NOT NULL ,
	ID_Status int  NOT NULL 
)
go


ALTER TABLE Mehanizm
	ADD CONSTRAINT XPKМеханизм PRIMARY KEY  CLUSTERED (ID_Mehanizm ASC)
go


CREATE TABLE Reshenie
(
	ID_Reshenie int  NOT NULL ,
	Nom varchar(6)  NOT NULL ,
	Opis varchar(max)  NOT NULL ,
	ID_Zapros int  NOT NULL ,
	ID_Sotrudnik int  NOT NULL 
)
go


ALTER TABLE Reshenie
	ADD CONSTRAINT XPKРешение PRIMARY KEY  CLUSTERED (ID_Reshenie ASC)
go


CREATE TABLE Role
(
	ID_Role int  NOT NULL ,
	Naim varchar(max)  NOT NULL ,
	Dostup varchar(6)  NOT NULL 
)
go


ALTER TABLE Role
	ADD CONSTRAINT XPKРоль PRIMARY KEY  CLUSTERED (ID_Role ASC)
go


CREATE TABLE Sotrudnik
(
	ID_Sotrudnik int  NOT NULL ,
	Fam varchar(max)  NOT NULL ,
	Im varchar(max)  NOT NULL ,
	Otch varchar(max)  NULL ,
	Ser varchar(4)  NOT NULL ,
	Nom varchar(6)  NOT NULL ,
	Mail varchar(max)  NOT NULL 
)
go


ALTER TABLE Sotrudnik
	ADD CONSTRAINT XPKСотрудник PRIMARY KEY  CLUSTERED (ID_Sotrudnik ASC)
go


CREATE TABLE Status
(
	ID_Status int  NOT NULL ,
	Naim varchar(max)  NOT NULL 
)
go


ALTER TABLE Status
	ADD CONSTRAINT XPKСтатус PRIMARY KEY  CLUSTERED (ID_Status ASC)
go


CREATE TABLE Test
(
	ID_Test int  NOT NULL ,
	Nom varchar(6)  NOT NULL ,
	Naim varchar(max)  NOT NULL ,
	Rezult varchar(max)  NULL ,
	ID_TypeTest int  NOT NULL ,
	ID_Mehanizm int  NOT NULL ,
	DateTest varchar(max)  NULL default(GETDATE())
)
go


ALTER TABLE Test
	ADD CONSTRAINT XPKТест PRIMARY KEY  CLUSTERED (ID_Test ASC)
go


CREATE TABLE Type_Test
(
	ID_TypeTest int  NOT NULL ,
	Naim varchar(max)  NOT NULL
	
)
go


ALTER TABLE Type_Test
	ADD CONSTRAINT XPKТип_теста PRIMARY KEY  CLUSTERED (ID_TypeTest ASC)
go


CREATE TABLE Type_Zapros
(
	ID_TypeZapros int  NOT NULL ,
	Naim varchar(max)  NOT NULL 
)
go


ALTER TABLE Type_Zapros
	ADD CONSTRAINT XPKТип_запроса PRIMARY KEY  CLUSTERED (ID_TypeZapros ASC)
go


CREATE TABLE Zapros
(
	ID_Zapros int identity(1,1)  NOT NULL ,
	Nom varchar(6)  NOT NULL ,
	Naim varchar(max)  NULL ,
	Opis varchar(max)  NULL ,
	ID_Sotrudnik int  NOT NULL ,
	ID_TypeZapros int  NOT NULL ,
	DateZapr varchar(max)  NULL default(GETDATE()),
	ID_Test int  NULL 
)
go


ALTER TABLE Zapros
	ADD CONSTRAINT XPKЗапрос PRIMARY KEY  CLUSTERED (ID_Zapros ASC)
go



ALTER TABLE Auth
	ADD CONSTRAINT  R_4 FOREIGN KEY (ID_Sotrudnik) REFERENCES Sotrudnik(ID_Sotrudnik)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Auth
	ADD CONSTRAINT  R_5 FOREIGN KEY (ID_Role) REFERENCES Role(ID_Role)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go



ALTER TABLE Mehanizm
	ADD CONSTRAINT  R_14 FOREIGN KEY (ID_Status) REFERENCES Status(ID_Status)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go



ALTER TABLE Reshenie
	ADD CONSTRAINT  R_9 FOREIGN KEY (ID_Zapros) REFERENCES Zapros(ID_Zapros)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Reshenie
	ADD CONSTRAINT  R_15 FOREIGN KEY (ID_Sotrudnik) REFERENCES Sotrudnik(ID_Sotrudnik)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go



ALTER TABLE Test
	ADD CONSTRAINT  R_10 FOREIGN KEY (ID_TypeTest) REFERENCES Type_Test(ID_TypeTest)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go



ALTER TABLE Test
	ADD CONSTRAINT  R_12 FOREIGN KEY (ID_Mehanizm) REFERENCES Mehanizm(ID_Mehanizm)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go



ALTER TABLE Zapros
	ADD CONSTRAINT  R_6 FOREIGN KEY (ID_Sotrudnik) REFERENCES Sotrudnik(ID_Sotrudnik)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Zapros
	ADD CONSTRAINT  R_7 FOREIGN KEY (ID_TypeZapros) REFERENCES Type_Zapros(ID_TypeZapros)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE Zapros
	ADD CONSTRAINT  R_16 FOREIGN KEY (ID_Test) REFERENCES Test(ID_Test)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

insert into [dbo].Role(Naim,Dostup) 
values 
('Администратор', '111111'),
('Гость', '100000')

INSERT INTO [dbo].[Sotrudnik]
           ([Fam]
           ,[Im]
           ,[Otch]
           ,[Ser]
           ,[Nom]
           ,[Mail])
     VALUES
			('Борисов','Борис','Борисович','5231','521321','borisov@mail.ru'),
			('Романов','Роман','Романович','6421','523152','romanov@mail.ru')


INSERT INTO [dbo].[Auth]
           ([Login]
           ,[Password]
           ,[ID_Sotrudnik]
           ,[ID_Role])
     VALUES
           ('admin', 'admin', 1, 1),
		   ('gg', 'gg', 2, 2)


INSERT INTO [dbo].[Type_Test]
           ([Naim])
     VALUES
           ('Стрессовый'),
		   ('Функциональный')

INSERT INTO [dbo].[Type_Zapros]
           ([Naim])
     VALUES
           ('Ошибка'),
		   ('Проблема')

INSERT INTO [dbo].[Status]
           ([Naim])
     VALUES
           ('В разработке'),
		   ('Тестирование'),
		   ('Завершен')

INSERT INTO [dbo].[Mehanizm]
           ([Naim]
           ,[Opis]
           ,[ID_Status])
     VALUES
           ('Учет контрактов', 'Добавление файлов контрактов и данных о контрактах в базу данных', 1),
		   ('Учет договоров', 'Добавление файлов договоров и данных о контрактах в базу данных', 2),
		   ('Обратная связь', 'Возможность пользователя оставить сообщение об ошибке или улучшении', 3)

USE [RosGeoDevOps]
GO

INSERT INTO [dbo].[Test]
           ([Nom]
           ,[Naim]
           ,[Rezult]
           ,[ID_TypeTest]
           ,[ID_Mehanizm]
           ,[DateTest])
     VALUES
           ('523123','Проверка учета контрактов','При попытке добавления ничего не происходит',1,1,NULL),
		   ('623123','Проверка учета договоров',NULL,2,2,NULL),
		   ('513214','Дополнительная проверка обратной связи','При попытке отправить сообщение оно отправляется',1,3,NULL)


INSERT INTO [dbo].[Zapros]
           ([Nom]
           ,[Naim]
           ,[Opis]
           ,[ID_Sotrudnik]
           ,[ID_TypeZapros]
           ,[DateZapr]
           ,[ID_Test])
     VALUES
           ('521321','Ошибка добавления контракта','В модуле Contracts возникает критическая ошибка',1,1,NULL,1),
		   ('612362','Доработка учета договоров','Доработка модуля Dogovors',2,2,NULL,NULL)


INSERT INTO [dbo].[Reshenie]
           ([Nom]
           ,[Opis]
           ,[ID_Zapros]
           ,[ID_Sotrudnik])
     VALUES
           ('512521', 'Решена проблема добавления контракта', 1, 1),
		   ('734521', 'Доработан учет договоров', 2, 1)
GO













