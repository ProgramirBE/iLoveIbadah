Use [master]
go
CREATE DATABASE DhikrCountDB
GO
USE DhikrCountDB
go
CREATE TABLE User_Account (
    id BIGINT PRIMARY KEY IDENTITY(1,1), -- Auto-incrementing primary key
    full_name NVARCHAR(25) NOT NULL,
    email NVARCHAR(50) NOT NULL UNIQUE, -- Ensuring email is unique
	profile_picture IMAGE NULL, -- Base64 encryption for Project!
    password_hash NVARCHAR(255) NULL,
	o_auth_provider NVARCHAR(20) NULL,
	o_auth_id NVARCHAR(255) NULL,
	email_confirmed BIT DEFAULT 0 NOT NULL,
	created_on DATE DEFAULT GETDATE() NOT NULL, -- Automatically sets to the current date
	created_by NVARCHAR(25) NOT NULL,
	last_modified_on DATE DEFAULT GETDATE() NOT NULL,
	last_modified_by NVARCHAR(25) NOT NULL,

	CONSTRAINT UQ_User_Account_email_password_hash UNIQUE (email, password_hash),
	CONSTRAINT CK_User_Account_password_hash_o_auth_id CHECK (password_hash IS NOT NULL OR o_auth_id IS NOT NULL)  -- At least one must be non-NULL
);
GO
CREATE TABLE Dhikr_Type (
    id BIGINT PRIMARY KEY IDENTITY(1,1), -- Auto-incrementing primary key
    full_name NVARCHAR(255) NOT NULL,
	created_on DATE DEFAULT GETDATE() NOT NULL, -- Automatically sets to the current date
	created_by NVARCHAR(25) NOT NULL, -- So user can create his own personal dhirk types just for him
	last_modified_on DATE DEFAULT GETDATE() NOT NULL,
	last_modified_by NVARCHAR(25) NOT NULL
);
GO
CREATE TABLE User_Activity (
    id BIGINT PRIMARY KEY IDENTITY(1,1), -- Auto-incrementing primary key
    User_Account_id BIGINT NOT NULL, -- Foreign key to Users table
    Dhikr_Type_id BIGINT NOT NULL, -- Foreign key to Dhikr table
    performed_at DATE DEFAULT CONVERT(VARCHAR(10), GETDATE(), 120) NOT NULL, -- The date in YYYY-MM-DD format in which the activity occurred
    total_dhikr_performed BIGINT DEFAULT 0 NOT NULL, -- Default count to 0 for new records
    
    CONSTRAINT FK_User_Activity_User_Account_id FOREIGN KEY (User_Account_id) REFERENCES User_Account(id) ON DELETE CASCADE,
    CONSTRAINT FK_User_Activity_Dhikr_id FOREIGN KEY (Dhikr_Type_id) REFERENCES Dhikr_Type(id) ON DELETE CASCADE,
    CONSTRAINT UQ_User_Activity_User_Account_id_performed_at UNIQUE (User_Account_id, performed_at) -- Ensures a unique record per user per day
);
GO
CREATE TABLE User_Dhikr_Count (
    id BIGINT PRIMARY KEY IDENTITY(1,1), -- Auto-incrementing primary key
    User_Account_id BIGINT NOT NULL, -- Foreign key to Users table
    Dhikr_Type_id BIGINT NOT NULL, -- Foreign key to Dhikr table
    total_performed BIGINT DEFAULT 0 NOT NULL, -- Default count to 0 for new records
    
    CONSTRAINT FK_User_Count_User_Account_id FOREIGN KEY (User_Account_id) REFERENCES User_Account(id) ON DELETE CASCADE,
    CONSTRAINT FK_User_Count_Dhikr_id FOREIGN KEY (Dhikr_Type_id) REFERENCES Dhikr_Type(id) ON DELETE CASCADE,
    CONSTRAINT UQ_User_Count_User_Account_id_Dhikr_id UNIQUE (User_Account_id, Dhikr_Type_id) -- Ensures unique record per user and dhikr
);
GO
ALTER DATABASE DhikrCountDB SET READ_WRITE
GO
USE DhikrCountDB
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
