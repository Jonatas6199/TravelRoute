create database TravelDb
go
use TravelDb
go
create table [Route](
	Id int identity primary key,
	Origin varchar(20) not null,
	Destination varchar(20) not null,
	[Value] float not null)
