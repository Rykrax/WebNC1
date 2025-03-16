create database WebNC1
go

use WebNC1
go

create table users (
	UserID int identity(1,1) primary key,
	PhoneNumber varchar(15) unique not null,
	PasswordHash varchar(255) not null,
	FullName nvarchar(255),
	CCCD char(12) unique,
	BirthDate date,
	Email varchar(255) unique,
	Balance int default 0,
	PinCode char(6) not null,
	CreateAt datetime default getdate(),
	StatusUser nvarchar(255),
	RoleUser nvarchar(20) not null default 'user'
)
go

create table banks (
	BankID int identity(1,1) primary key,
	BankName nvarchar(255) not null unique,
	BankImage varchar(255)
)
go

create table bank_accounts (
	AccountNumber varchar(50) not null,
	UserID int not null,
	BankID int not null,
	StatusAccount nvarchar(100),
	constraint PK_bankaccounts primary key (AccountNumber, BankID),
	foreign key (UserID) references users(UserID),
	foreign key (BankID) references banks(BankID)
)
go

create table transactions (
	TransactionID int identity(1,1) primary key,
	SenderUser int not null,
	SenderAccount varchar(50) not null,
	SendBank int not null,
	RecipientUser int not null, 
	RepAccount varchar(50) not null,
	RepBank int not null,
	TransactionType nvarchar(255),
	Amount int,
	CreateAt datetime default getdate(),
	Description nvarchar(255), 
	StatusTransaction nvarchar(255),
	foreign key (SenderAccount, SendBank) references bank_accounts(AccountNumber, BankID),
	foreign key (RepAccount, RepBank) references bank_accounts(AccountNumber, BankID)
)
go