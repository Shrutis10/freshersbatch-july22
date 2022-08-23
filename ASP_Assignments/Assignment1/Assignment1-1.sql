create database Match;

create table FootBallLeague 
(
	MatchID int NOT NULL PRIMARY KEY,
	TeamName1 nvarchar(50), 
	TeamName2 nvarchar(50), 
	MStatus nvarchar(50), 
	WinningTeam nvarchar(50), 
	Points int
)

CREATE PROCEDURE spData 
@MatchId int,
@TeamName1 nvarchar(50),
@TeamName2 nvarchar(50),
@MStatus nvarchar(50),
@WinningTeam nvarchar(50),
@Points int
AS 
BEGIN
	insert into FootBallLeague(MatchId,TeamName1,TeamName2,MStatus,WinningTeam,Points)
	values (@MatchId,@TeamName1,@TeamName2,@MStatus,@WinningTeam,@Points)
END


exec spData 1006,'Brazil','France','Win','Brazil',4;


CREATE PROCEDURE spRetrieveWinning
AS
BEGIN
select WinningTeam from FootBallLeague where TeamName1 = WinningTeam or TeamName2 = WinningTeam
END

ALTER PROCEDURE spRetrieveWinning
AS
BEGIN
select MatchID, WinningTeam from FootBallLeague where TeamName1 = WinningTeam or TeamName2 = WinningTeam
END

exec spRetrieveWinning



CREATE PROCEDURE spMatchesPlayedByJapan
AS
BEGIN
select * from FootBallLeague where TeamName1 = 'Japan' or TeamName2 = 'Japan'
END

exec spMatchesPlayedByJapan

Insert into FootBallLeague
values (1001,'Italy','France','Win','France',4)

Insert into FootBallLeague
values (1002,'Brazil','Portugal','Draw',null,2)

Insert into FootBallLeague
values (1003,'England','Japan','Win','England',4)

Insert into FootBallLeague
values (1004,'USA','Russia','Win','Russia',4)

Insert into FootBallLeague
values (1005,'Portugal','Italy','Draw',null,2)

Insert into FootBallLeague
values (1006,'Brazil','France','Win','Brazil',4)

Insert into FootBallLeague
values (1007,'England','Russia','Win','Russia',4)

Insert into FootBallLeague
values (1008,'Japan','USA','Draw',null,2)


select * from FootBallLeague;

CREATE VIEW Match_View AS 
SELECT TeamName1,TeamName2, MStatus
FROM FootBallLeague
WHERE MStatus = 'Draw';

select * from Match_View;