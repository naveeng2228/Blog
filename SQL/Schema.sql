CREATE TABLE Roles
(
RoleID INT IDENTITY CONSTRAINT PK_Roles PRIMARY KEY,
Title VARCHAR(50), 
Role_Description VARCHAR(200), 
CreatedDate  VARCHAR(50),
CreatedTime  VARCHAR(50),
ModifiedDate VARCHAR(50),
ModifiedTime VARCHAR(50),
Status_Ind  INT
);




CREATE TABLE Users
(
Userid INT IDENTITY CONSTRAINT PK_Users PRIMARY KEY,
Username VARCHAR(100),
password_nme VARCHAR(100),
RoleID INT CONSTRAINT FK_Roles_RoleID REFERENCES Roles(RoleID),
Full_Name VARCHAR(100),
CreatedDate VARCHAR(50),
CreatedTime  VARCHAR(50),
CreatedBy   INT CONSTRAINT FK_Users_CreatedBy REFERENCES Users(Userid),
ModifiedDate  VARCHAR(50),
ModifiedTime  VARCHAR(50),
ModifiedBy  INT CONSTRAINT FK_Users_ModifiedBy REFERENCES Users(Userid),
Status_ind INT
);


CREATE TABLE Permission
(
PermissionID INT IDENTITY CONSTRAINT PK_Permission PRIMARY KEY, 
RoleId INT CONSTRAINT FK_Permission_Roles_RoleId REFERENCES Roles(RoleID),
Title VARCHAR(100),
CreatedDate  VARCHAR(50),
CreatedTime VARCHAR(50),
CreatedBy   INT CONSTRAINT FK_Users_Permission_CreatedBy REFERENCES Users(Userid),
ModifiedDate  VARCHAR(50),
ModifiedTime VARCHAR(50),
ModifiedBy INT CONSTRAINT FK_Users_Permission_ModifiedBy REFERENCES Users(Userid),
Status_Ind INT
);


CREATE TABLE Categories
(
CategoryID INT IDENTITY CONSTRAINT PK_Categories  PRIMARY KEY ,
Title VARCHAR(200),
Remarks VARCHAR(300),
CreatedDate VARCHAR(50),
CreatedTime VARCHAR(50),
CreatedBy INT CONSTRAINT FK_Users_Categories_CreatedBy REFERENCES Users(Userid),
ModifiedDate VARCHAR(50),
ModifiedTime VARCHAR(50),
ModifiedBy INT CONSTRAINT FK_Users_Categories_ModifiedBy REFERENCES Users(Userid),
Status_Ind INT
);

CREATE TABLE SubCategories 
(
SubCategoryID INT IDENTITY CONSTRAINT PK_Sub_Categories PRIMARY KEY,
CategoryID INT CONSTRAINT FK_Categories_Sub_Categories_CategoryID REFERENCES Categories(CategoryID),
Title VARCHAR(100),
Remarks VARCHAR(300),
CreatedDate  VARCHAR(50),
CreatedTime VARCHAR(50),
CreatedBy  INT CONSTRAINT FK_Users_SubCategories_CreatedBy REFERENCES Users(Userid),
ModifiedDate VARCHAR(50),
ModifiedTime VARCHAR(50),
ModifiedBy INT CONSTRAINT FK_Users_SubCategories_ModifiedBy REFERENCES Users(Userid),
Status_Ind INT
);

CREATE TABLE Posts
(
Post_NBR INT IDENTITY,
Post_Id VARCHAR(10)  CONSTRAINT PK_Posts PRIMARY KEY,
PostTitle VARCHAR(200),
ShortDescription VARCHAR(300),
FullDescription VARCHAR(MAX),
CategoryID INT CONSTRAINT FK_Posts_Categories_CategoryID REFERENCES Categories(CategoryID),
SubCategoryID INT CONSTRAINT FK_Posts_Sub_Categories_SubCategoryID REFERENCES SubCategories(SubCategoryID),
UniqueURL VARCHAR(300),
SEOTitle VARCHAR(100),
SEODescription VARCHAR(500),
SEOKeywords VARCHAR(1000),
CreatedDate VARCHAR(50),
CreatedTime VARCHAR(50),
CreatedBy  INT CONSTRAINT FK_Users_Posts_CreatedBy REFERENCES Users(Userid),
ModifiedDate VARCHAR(50),
ModifiedTime VARCHAR(50),
ModifiedBy  INT CONSTRAINT FK_Users_Posts_ModifiedBy REFERENCES Users(Userid),
Status_Ind INT
);

 

 
