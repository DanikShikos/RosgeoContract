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
	ADD CONSTRAINT XPK����������� PRIMARY KEY  CLUSTERED (ID_Auth ASC)
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
	ADD CONSTRAINT XPK�������� PRIMARY KEY  CLUSTERED (ID_Mehanizm ASC)
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
	ADD CONSTRAINT XPK������� PRIMARY KEY  CLUSTERED (ID_Reshenie ASC)
go


CREATE TABLE Role
(
	ID_Role int  NOT NULL ,
	Naim varchar(max)  NOT NULL ,
	Dostup varchar(6)  NOT NULL 
)
go


ALTER TABLE Role
	ADD CONSTRAINT XPK���� PRIMARY KEY  CLUSTERED (ID_Role ASC)
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
	ADD CONSTRAINT XPK��������� PRIMARY KEY  CLUSTERED (ID_Sotrudnik ASC)
go


CREATE TABLE Status
(
	ID_Status int  NOT NULL ,
	Naim varchar(max)  NOT NULL 
)
go


ALTER TABLE Status
	ADD CONSTRAINT XPK������ PRIMARY KEY  CLUSTERED (ID_Status ASC)
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
	ADD CONSTRAINT XPK���� PRIMARY KEY  CLUSTERED (ID_Test ASC)
go


CREATE TABLE Type_Test
(
	ID_TypeTest int  NOT NULL ,
	Naim varchar(max)  NOT NULL
	
)
go


ALTER TABLE Type_Test
	ADD CONSTRAINT XPK���_����� PRIMARY KEY  CLUSTERED (ID_TypeTest ASC)
go


CREATE TABLE Type_Zapros
(
	ID_TypeZapros int  NOT NULL ,
	Naim varchar(max)  NOT NULL 
)
go


ALTER TABLE Type_Zapros
	ADD CONSTRAINT XPK���_������� PRIMARY KEY  CLUSTERED (ID_TypeZapros ASC)
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
	ADD CONSTRAINT XPK������ PRIMARY KEY  CLUSTERED (ID_Zapros ASC)
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
('�������������', '111111'),
('�����', '100000')

INSERT INTO [dbo].[Sotrudnik]
           ([Fam]
           ,[Im]
           ,[Otch]
           ,[Ser]
           ,[Nom]
           ,[Mail])
     VALUES
			('�������','�����','���������','5231','521321','borisov@mail.ru'),
			('�������','�����','���������','6421','523152','romanov@mail.ru')


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
           ('����������'),
		   ('��������������')

INSERT INTO [dbo].[Type_Zapros]
           ([Naim])
     VALUES
           ('������'),
		   ('��������')

INSERT INTO [dbo].[Status]
           ([Naim])
     VALUES
           ('� ����������'),
		   ('������������'),
		   ('��������')

INSERT INTO [dbo].[Mehanizm]
           ([Naim]
           ,[Opis]
           ,[ID_Status])
     VALUES
           ('���� ����������', '���������� ������ ���������� � ������ � ���������� � ���� ������', 1),
		   ('���� ���������', '���������� ������ ��������� � ������ � ���������� � ���� ������', 2),
		   ('�������� �����', '����������� ������������ �������� ��������� �� ������ ��� ���������', 3)

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
           ('523123','�������� ����� ����������','��� ������� ���������� ������ �� ����������',1,1,NULL),
		   ('623123','�������� ����� ���������',NULL,2,2,NULL),
		   ('513214','�������������� �������� �������� �����','��� ������� ��������� ��������� ��� ������������',1,3,NULL)


INSERT INTO [dbo].[Zapros]
           ([Nom]
           ,[Naim]
           ,[Opis]
           ,[ID_Sotrudnik]
           ,[ID_TypeZapros]
           ,[DateZapr]
           ,[ID_Test])
     VALUES
           ('521321','������ ���������� ���������','� ������ Contracts ��������� ����������� ������',1,1,NULL,1),
		   ('612362','��������� ����� ���������','��������� ������ Dogovors',2,2,NULL,NULL)


INSERT INTO [dbo].[Reshenie]
           ([Nom]
           ,[Opis]
           ,[ID_Zapros]
           ,[ID_Sotrudnik])
     VALUES
           ('512521', '������ �������� ���������� ���������', 1, 1),
		   ('734521', '��������� ���� ���������', 2, 1)
GO













