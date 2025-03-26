create database WebNC1
go

use WebNC1
go

-- create table users (
-- 	UserID int identity(1,1) primary key,
-- 	PhoneNumber varchar(15) unique,
-- 	PasswordHash varchar(255) not null,
-- 	FullName nvarchar(255),
-- 	CCCD char(12) unique,
-- 	BirthDate date,
-- 	Email varchar(255) unique,
-- 	Balance int default 0,
-- 	PinCode char(6),
-- 	CreateAt datetime default getdate(),
-- 	StatusUser nvarchar(255),
-- 	RoleUser nvarchar(20) not null default 'user'
-- )
-- go

-- ALTER TABLE users 
-- ALTER COLUMN CCCD CHAR(12) NULL;
-- ALTER TABLE users 
-- ADD CONSTRAINT unique_cccd UNIQUE (CCCD);


-- ALTER TABLE users 
-- ADD CONSTRAINT unique_email UNIQUE (Email);
-- CREATE UNIQUE INDEX unique_phonenumber ON users (PhoneNumber) WHERE PhoneNumber IS NOT NULL;
-- CREATE UNIQUE INDEX unique_cccd ON users (CCCD) WHERE CCCD IS NOT NULL;

CREATE TABLE users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    PhoneNumber VARCHAR(15) NULL, -- Cho phép NULL
    PasswordHash VARCHAR(255) NOT NULL,
    FullName NVARCHAR(255),
    CCCD CHAR(12) NULL, -- Cho phép NULL
    BirthDate DATE,
    Email VARCHAR(255) NULL, -- Cho phép NULL
    Balance INT DEFAULT 0,
    PinCode CHAR(6),
    CreateAt DATETIME DEFAULT GETDATE(),
    StatusUser NVARCHAR(255),
    RoleUser NVARCHAR(20) NOT NULL DEFAULT 'user'
);

-- Tạo các UNIQUE INDEX chỉ áp dụng cho giá trị KHÁC NULL
CREATE UNIQUE INDEX unique_phonenumber ON users (PhoneNumber) WHERE PhoneNumber IS NOT NULL;
CREATE UNIQUE INDEX unique_cccd ON users (CCCD) WHERE CCCD IS NOT NULL;
CREATE UNIQUE INDEX unique_email ON users (Email) WHERE Email IS NOT NULL;

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

--reset id
DBCC CHECKIDENT ('users', RESEED, 0);
