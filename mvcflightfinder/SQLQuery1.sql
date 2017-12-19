﻿-- Generated by Oracle SQL Developer Data Modeler 17.3.0.261.1529
--   at:        2017-12-18 23:43:48 CET
--   site:      SQL Server 2012
--   type:      SQL Server 2012



CREATE TABLE BookedFlights 
    (
     Idb INTEGER Identity NOT NULL , 
     "From" VARCHAR (50) NOT NULL , 
     "To" VARCHAR (50) NOT NULL , 
     DateFrom DATETIME NOT NULL , 
     Peoples INTEGER NOT NULL , 
     Price INTEGER NOT NULL , 
     Users_Id INTEGER NOT NULL , 
     DateOfRes DATETIME NOT NULL 
    )
    ON "default"
GO

ALTER TABLE BookedFlights ADD CONSTRAINT BookedFlights_PK PRIMARY KEY CLUSTERED (Idb)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default" 
    GO

CREATE TABLE FavoriteFligths 
    (
     Idf INTEGER Identity NOT NULL , 
	 IdUser INTEGER NOT NULL ,
     "From" VARCHAR (50) NOT NULL , 
     "To" VARCHAR (50) NOT NULL , 
     DateFrom DATETIME NOT NULL , 
     Price INTEGER NOT NULL
     
    )
    ON "default"
GO

ALTER TABLE FavoriteFligths ADD CONSTRAINT FavoriteFligths_PK PRIMARY KEY CLUSTERED (Idf)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default" 
    GO

CREATE TABLE Users 
    (
     Id INTEGER Identity NOT NULL , 
     Nick VARCHAR (25) NOT NULL , 
     Email VARCHAR (25) NOT NULL , 
     password VARCHAR (50) NOT NULL , 
     FirstName VARCHAR (50) NOT NULL , 
     LastName VARCHAR (50) NOT NULL 
    )
    ON "default"
GO

ALTER TABLE Users ADD CONSTRAINT Users_PK PRIMARY KEY CLUSTERED (Id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default" 
    GO

ALTER TABLE BookedFlights 
    ADD CONSTRAINT BookedFlights_Users_FK FOREIGN KEY 
    ( 
     Users_Id
    ) 
    REFERENCES Users 
    ( 
     Id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE FavoriteFligths 
    ADD CONSTRAINT FavoriteFligths_Users_FK FOREIGN KEY 
    ( 
     IdUser
    ) 
    REFERENCES Users 
    ( 
     Id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO



-- Oracle SQL Developer Data Modeler Summary Report: 
-- 
-- CREATE TABLE                             3
-- CREATE INDEX                             0
-- ALTER TABLE                              5
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE DATABASE                          0
-- CREATE DEFAULT                           0
-- CREATE INDEX ON VIEW                     0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE ROLE                              0
-- CREATE RULE                              0
-- CREATE SCHEMA                            0
-- CREATE SEQUENCE                          0
-- CREATE PARTITION FUNCTION                0
-- CREATE PARTITION SCHEME                  0
-- 
-- DROP DATABASE                            0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0




















Drop Table UserToFav
Drop Table users
Drop Table FavoriteFligths
Drop Table BookedFlights



exec PrintDtoForUser 'nog0030'
exec PrintDtoForTable 'FavoriteFligths'

Select * from FavoriteFligths  Where IdUser = 1
Insert INTO Users(Nick,Email,password,FirstName,LastName)
Values('Petr','petr@petr.cz','petr123','Petr','Noga')

Insert INTO FavoriteFligths (IdUser,flyFrom,flyTo,DateFrom,Price)
Values(1,'London','Prague',18-06-12,1250)

INSERT INTO FavoriteFligths VALUES (1,'Vienna', 'Prague', '12/06/2017', 500)

Insert INTO UserToFav (Users_Id,FavoriteFligths_Idf)
Values(2,5)

Select * from Users
Select * from FavoriteFligths 
Select * from UserToFav

select flyFrom,flyTo,DateFrom,Price from FavoriteFligths ff 
Join UserToFav usTofav ON usTofav.FavoriteFligths_Idf = ff.Idf 
JOin Users us ON us.Id = usTofav.Users_Id Where us.Id=1

EXEC sp_RENAME 'BookedFlights.From', 'flyFrom', 'COLUMN'
EXEC sp_RENAME 'BookedFlights.To', 'flyTo', 'COLUMN'

ALTER TABLE FavoriteFligths 
ALTER COLUMN DateFrom VARCHAR(50) 