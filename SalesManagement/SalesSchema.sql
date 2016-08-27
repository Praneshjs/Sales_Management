Drop TABLE [dbo].[Account]
GO
CREATE TABLE [dbo].[Account] (
    [Id]        INT   IDENTITY(1,1)        NOT NULL,
    [FullName]  VARCHAR (100) NULL,
    [UserName]  VARCHAR (100) Unique NOT NULL,
    [Password]  VARCHAR (30)  NULL,
    [JoinDate]  DATETIME      NULL,
    [ExitDate]  DATETIME      NULL,
	IsAdmin bit,
	IsManager bit,
	IsUser bit,
    [CreatedOn] DATETIME      NULL,
    [CreatedBy] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].Product (
    [Id]        INT   IDENTITY(1,1)        NOT NULL,
    [ProductName]  VARCHAR (100) NULL,
    [Quantity]  INT NOT NULL,
	UnitPrice FLOAT NOT NULL,
    [CreatedOn] DATETIME      NULL,
    [CreatedBy] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



Create table UserRoles
(
Id int identity(1,1) primary key,
RoleName varchar(100),
CreatedOn Datetime
);
insert into UserRoles values ('Dashboard','2016-08-20 21:10:00');
insert into UserRoles values ('Reports','2016-08-20 21:10:00');
insert into UserRoles values ('POS','2016-08-20 21:10:00');
insert into UserRoles values ('Profile','2016-08-20 21:10:00');
insert into UserRoles values ('Inventory','2016-08-20 21:10:00');


Create table UserInRole
(
Id int identity(1,1) primary key,
UserID int references Account(Id),
RoleID int references UserRoles(Id)
);


IF (OBJECT_ID('SP_USERINROLES') IS NOT NULL)
BEGIN
	DROP PROCEDURE SP_USERINROLES
 END
GO
CREATE PROCEDURE SP_USERINROLES
@USERID INT
AS
BEGIN
SELECT ROLENAME FROM USERROLES AS UR
LEFT JOIN USERINROLE AS UIR ON UIR.ROLEID = UR.ID
WHERE UIR.USERID =@USERID;
END


CREATE TABLE SALES
(
ID INT IDENTITY(1,1) PRIMARY KEY,
USERID INT REFERENCES ACCOUNT(ID),
LOGDATE DATETIME,
BILLEDAMOUNT FLOAT,
DELIVERYCHECK BIT
);



CREATE TABLE SALEDETAILS
(
ID INT IDENTITY(1,1) PRIMARY KEY,
SaleD INT REFERENCES SALES(ID) NOT NULL,
ProductID INT REFERENCES PRODUCT(ID),
);