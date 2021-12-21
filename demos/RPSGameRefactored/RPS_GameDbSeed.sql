SELECT * FROM Players;
Truncate table Players;
SELECT * FROM Rounds;
SELECT * FROM Games;
CREATE SCHEMA RpsGame;
CREATE DATABASE RpsGameDb;

CREATE TABLE Players
(
	PlayerId int PRIMARY KEY NOT NULL IDENTITY(1,1),
	Fname NVARCHAR(20) NOT NULL,
	Lname NVARCHAR(20) NOT NULL,
	Wins INT NOT NULL DEFAULT 0,
	Losses INT NOT NULL DEFAULT 0,
	CONSTRAINT RecordNotNeg CHECK(Wins > 0 AND Losses > 0)
);

--add a date column
--ALTER TABLE Players
--ADD DateAdded DateTime DEFAULT(GetDate());

--ALTER TABLE Players
--ADD TestValue int;

INSERT INTO Players VALUES
	('Max','HeadRoom',5,2),
	('Arely','Moore',2,5),
	('Maya','Moore',7,0);

SELECT * FROM Players;
DROP TABLE Players;

--Below the code for creating and seeding Game Table
CREATE TABLE Games
(
	GameId int PRIMARY KEY NOT NULL IDENTITY(1,1),
	Player1 int NOT NULL FOREIGN KEY REFERENCES Players(PlayerId),
	Player2 int NOT NULL FOREIGN KEY REFERENCES Players(PlayerId),
	DateAdded DateTime DEFAULT(GetDate())
);

SELECT * FROM Games;

--add a dateadded column
ALTER TABLE Games
ADD DateAdded DateTime DEFAULT(GetDate());

--add a winnder column
ALTER TABLE Games
ADD GameWinner int NOT NULL FOREIGN KEY REFERENCES Players(PlayerId);


INSERT INTO Games (Player1, Player2)
VALUES(7,4);

CREATE TABLE Rounds
(
	RoundId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Player1Choice int NOT NULL,
	Player2Choice int NOT NULL,
	GameId INT NOT NULL FOREIGN KEY REFERENCES Games(GameId),
	DateAdded DateTime DEFAULT(GetDate())
);

INSERT INTO Rounds (Player1Choice, Player2Choice, GameId)
VALUES (1,2,1),(1,2,1);

CREATE TABLE Choices
(
	ChoiceId int PRIMARY KEY NOT NULL IDENTITY(1,1),
	ChoiceValue NVARCHAR(20) NOT NULL,
	-- add dateAdded
);

INSERT INTO Choices (ChoiceValue)
VALUES('PAPER'), ('ROCK'), ('SCISSORS');

SELECT * FROM Choices;