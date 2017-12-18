
DROP TABLE IF EXISTS [Users]

GO
DROP TABLE IF EXISTS [Settings]

GO
DROP TABLE IF EXISTS [Favorite_flights]

GO

CREATE TABLE [Users] (
	id int IDENTITY(1,1) NOT NULL,
	login varchar(15) NOT NULL,
	email varchar(25) NOT NULL,
	password varchar(20) NOT NULL,
	permission varchar(1) NOT NULL,
  CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Settings] (
	id int IDENTITY(1,1) NOT NULL,
	idUser int NOT NULL,
	password varchar(25) NOT NULL,
	firstName varchar(20) NOT NULL,
	lastName varchar(50) NOT NULL,
  CONSTRAINT [PK_SETTINGS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Favorite_flights] (
	id int Identity(1,1) NOT NULL,
	iduser int NOT NULL,
	fligthFrom varchar(50) NOT NULL,
	flightTo varchar(50) NOT NULL,
	datefrom varchar(50) NOT NULL,
	price varchar(50) NOT NULL,
  CONSTRAINT [PK_FAVORITE_FLIGHTS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

ALTER TABLE [Settings] WITH CHECK ADD CONSTRAINT [Settings_fk0] FOREIGN KEY ([id]) REFERENCES [Users]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Settings] CHECK CONSTRAINT [Settings_fk0]
GO

ALTER TABLE [Favorite_flights] WITH CHECK ADD CONSTRAINT [Favorite_flights_fk0] FOREIGN KEY ([id]) REFERENCES [Users]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Favorite_flights] CHECK CONSTRAINT [Favorite_flights_fk0]
GO










INSERT INTO Users (login, password, email, permission)
VALUES ('user','user123','user@test.cz','u');

INSERT INTO Users (login, password, email, permission)
VALUES ('Keiko','keiko','n.skypo@gmail.com','u');

INSERT INTO Users (login, password, email, permission)
VALUES ('admin','pass123','admin@test.cz','a');

INSERT INTO Settings (idUser,password,firstName,lastName)
VALUES (3,'keiko','Petr','Noga');

select * from Users
select * from Settings
select * from Favorite_flights
delete  from Users where id= 7
SELECT * FROM Users WHERE email = 'n.skypo@gmail.com' AND password = 'keiko'

INSERT INTO Favorite_flights (idUser,fligthFrom,flightTo,dateFrom,price)
VALUES(1,'Prague','Vienna','17/12/2017','601kč')

EXEC sp_RENAME 'Favorite_flights.fligthFrom' , 'flightFrom', 'COLUMN'