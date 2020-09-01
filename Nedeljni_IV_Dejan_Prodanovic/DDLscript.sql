--we create database  
CREATE DATABASE SocialNetworkDb;

GO

use SocialNetworkDb;

GO

 --we delete tables in case they exist
DROP TABLE IF EXISTS tblUser;
DROP TABLE IF EXISTS tblPost;
DROP TABLE IF EXISTS tblFriendRequests;
DROP TABLE IF EXISTS tblFriends;
DROP TABLE IF EXISTS tblLikedPosts;
DROP TABLE IF EXISTS tblUserPosts;


--we create table tblUser
 CREATE TABLE tblUser (
    UserID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    FirstName varchar(50),
	LastName varchar(50),
	Gender varchar(50),
	DateOfBirth date,
	Location varchar(50),
    Email varchar(50),
	Username varchar(50),
	Password varchar(50)
 
);
--we create table tblSector 
 CREATE TABLE tblPost (
    PostID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	DateOfPost date,
	PostText varchar(200),
	NumberOfLikes int,
	UserID int FOREIGN KEY REFERENCES tblUser(UserID)  
);

CREATE TABLE tblFriendRequests (
   
	SendUserId int FOREIGN KEY REFERENCES tblUser(UserID),
	RecieveUserId int FOREIGN KEY REFERENCES tblUser(UserID)  ,
	primary key(SendUserId,RecieveUserId)
	);

CREATE TABLE tblFriends (
   
	FirstUserId int FOREIGN KEY REFERENCES tblUser(UserID),
	SecondUserId int FOREIGN KEY REFERENCES tblUser(UserID)  ,
	primary key(FirstUserId,SecondUserId)
	);

CREATE TABLE tblLikedPosts (
   
	UserId int FOREIGN KEY REFERENCES tblUser(UserID),
	PostId int FOREIGN KEY REFERENCES tblPost(PostID)  ,
	primary key(UserId,PostId)
	);