CREATE TABLE Sizes(
   Id int not null identity (1,1) primary key,
   SizeName nvarchar(50) not null,

)

CREATE TABLE Categorys(
   Id int not null identity (1,1) primary key,
   CategoryName nvarchar(50) not null,

)

CREATE TABLE Colours(
   Id int not null identity (1,1) primary key,
   ColourName nvarchar(50) not null,

)

CREATE TABLE Brands(
   Id int not null identity (1,1) primary key,
   BrandName nvarchar(50) not null,

)


CREATE TABLE Products ( 
  Id int not null identity (1,1) primary key,
  ProductName nvarchar(100) not null,
  ShortDescription nvarchar(200) not null,
  LongDescription nvarchar(max),
  StockCount int not null,
  Price money not null,
  OldPrize money not null,
  Picture nvarchar(300),
  CategoryId int not null references Categorys(Id),
  ColourId int not null references Colours(Id),
  SizeId int not null references Sizes(Id),
  BrandId int not null references Brands(Id)
  
)
