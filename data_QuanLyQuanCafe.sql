CREATE DATABASE QuanLyQuanCafe
GO
USE QuanLyQuanCafe
GO
--tableFood (Ban an)
--Food (Mon an)
--FoodCategory (Loai mon an)
-- Account (Tai khoan)
-- Bill (Hoa don)
-- BillInfo (Chi tiet hoa don)

CREATE TABLE TableFood 
(
	idTF INT IDENTITY PRIMARY KEY,
	nameTF NVARCHAR (100),
	statusTF NVARCHAR(100) DEFAULT N'Trống' -- gia tri: trong || co khach
)
GO

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,
	DisplayName NVARCHAR(100) NOT NULL,
	PassWord NVARCHAR(1000) NOT NULL,
	TypeAcc INT NOT NULL DEFAULT 0 --1:admin ,0: staff
)
GO

CREATE TABLE FoodCategory
(
	idFC INT IDENTITY PRIMARY KEY,
	nameFC NVARCHAR(100)
)
GO

CREATE TABLE Food
(
	idFood INT IDENTITY PRIMARY KEY,
	nameFood NVARCHAR(100) NOT NULL,
	idFC INT NOT NULL,
	price FLOAT NOT NULL
	
	FOREIGN KEY (idFC) REFERENCES dbo.FoodCategory(idFC)
)
GO

CREATE TABLE Bill
(
	idBill INT IDENTITY PRIMARY KEY,
	dateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	dateCheckOut DATE,
	idTF INT NOT NULL,
	statusBill INT NOT NULL DEFAULT 0 --1:da thanh toan, 0:chua thanh toan
	
	FOREIGN KEY (idTF) REFERENCES dbo.TableFood(idTF)
)
GO
 CREATE TABLE BillInfo
 (
	idBI INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	countFood INT NOT NULL DEFAULT 0 -- so luong
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(idBill),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(idFood)
 )
 GO
 ----------------------THEM DU LIEU---------------------------------
use QuanLyQuanCafe
INSERT INTO dbo.Account ( UserName, DisplayName,PassWord,TypeAcc) 

VALUES (N'Truyen', N'NT Thanh Truyen',N'1',1)

INSERT INTO dbo.Account ( UserName, DisplayName,PassWord,TypeAcc) 

VALUES (N'StaffOne', N'Staff One',N'1',0)
INSERT INTO Account ( UserName, DisplayName,PassWord,TypeAcc) 

VALUES (N'StaffTwo', N'Staff Two',N'1',0)
GO

CREATE PROC USP_GetAccountByUserName
@userName nvarchar (100)
AS
BEGIN 
	SELECT * FROM Account WHERE UserName=@userName
END
GO
EXEC USP_GetAccountByUserName @userName=N'Truyen'

INSERT INTO dbo.TableFood ( nameTF,statusTF) 
VALUES (N'', N'')
GO
---Them ban--
DECLARE @i INT = 1
WHILE @i <= 12
BEGIN
	INSERT INTO dbo.TableFood ( nameTF) 
	VALUES (N'Bàn '+CAST(@i AS nvarchar(100)))
	SET @i=@i+1
END
GO 

EXEC USP_GetTableList



SELECT * FROM Account WHERE UserName=N'Truyen' AND PassWord=N'1'
GO

use QuanLyQuanCafe
Go
CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(1000)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName=@userName AND PassWord=@passWord
END
GO
EXEC USP_Login N'Truyen' , N'1'
GO

CREATE PROC USP_GetTableList
AS SELECT * FROM TableFood
GO
UPDATE TableFood SET statusTF=N'Có Khách' WHERE idTF=9
--Them category---
INSERT INTO FoodCategory(nameFC)
VALUES (N'Thức uống')
INSERT INTO FoodCategory(nameFC)
VALUES (N'Đồ ăn')
--Them món ăn
INSERT INTO Food(nameFood,idFC,price)
VALUES (N'Tiramisu',2,30000)
INSERT INTO Food(nameFood,idFC,price)
VALUES (N'Bánh sô cô la',2,30000)
INSERT INTO Food(nameFood,idFC,price)
VALUES (N'Bánh rán',2,20000)
INSERT INTO Food(nameFood,idFC,price)
VALUES (N'Bánh nướng',2,20000)
INSERT INTO Food(nameFood,idFC,price)
VALUES (N'Bánh kem bắp',2,50000)

INSERT INTO Food(nameFood,idFC,price)
VALUES (N'Cà phê đá',1,15000)
INSERT INTO Food(nameFood,idFC,price)
VALUES (N'Cà phê sữa',1,17000)
INSERT INTO Food(nameFood,idFC,price)
VALUES (N'Trà sữa',1,25000)
INSERT INTO Food(nameFood,idFC,price)
VALUES (N'Trà thanh long',1,20000)

---Them bill--
INSERT INTO Bill(dateCheckIn,dateCheckOut,idTF,statusBill)
VALUES (GETDATE(),null,1,0)
INSERT INTO Bill(dateCheckIn,dateCheckOut,idTF,statusBill)
VALUES (GETDATE(),null,2,0)
INSERT INTO Bill(dateCheckIn,dateCheckOut,idTF,statusBill)
VALUES (GETDATE(),GETDATE(),2,1)
--them bill Info
INSERT INTO BillInfo(idBill,idFood,countFood)
VALUES (1,1,2)
INSERT INTO BillInfo(idBill,idFood,countFood)
VALUES (1,3,3)
INSERT INTO BillInfo(idBill,idFood,countFood)
VALUES (1,5,1)

INSERT INTO BillInfo(idBill,idFood,countFood)
VALUES (2,4,1)
INSERT INTO BillInfo(idBill,idFood,countFood)
VALUES (3,7,2)
GO
SELECT*FROM Bill
SELECT*FROM BillInfo
SELECT*FROM Food
SELECT*FROM FoodCategory

SELECT * FROM Bill WHERE idTF=1 and statusBill=0
SELECT * FROM BillInfo WHERE idBill=3
use QuanLyQuanCafe
SELECT f.nameFood,bi.countFood,f.price,f.price*bi.countFood as totalPrice FROM BillInfo as bi, Bill as b, Food as f 
WHERE b.idBill=bi.idBill and bi.idFood=f.idFood and b.statusBill=0 and b.idTF=2

SELECT * FROM FoodCategory
GO
--Insert bill moi vao csdl----
use QuanLyQuanCafe go
Create proc USP_InsertBill
@idTable INT
As
Begin
	Insert into Bill(dateCheckIn,dateCheckOut,idTF,statusBill) Values(GETDATE(),null,@idTable,0)
End
GO
use QuanLyQuanCafe
GO

DROP PROCEDURE USP_InsertBillInfo
--Insert billinfo  moi vao csdl----
CREATE proc USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
As
Begin
	DECLARE @isExistBillInfo INT
	DECLARE @foodCount INT = 1
	SELECT	@isExistBillInfo = idBI, @foodCount = countFood 
	FROM dbo.BillInfo WHERE idBill=@idBill AND idFood = @idFood
	IF(@isExistBillInfo > 0)
	Begin
		DECLARE @newCount INT = @foodCount + @count
		if( @newCount > 0)
			UPDATE dbo.BillInfo SET countFood = @foodCount + @count WHERE idFood = @idFood
		else
			DELETE dbo.BillInfo WHere idBill=@idBill AND idFood = @idFood
	End
	ELSE
	Begin
		Insert dbo.BillInfo(idBill,idFood,countFood) Values(@idBill,@idFood,@count)
	END
End
GO
DELETE FROM BillInfo
DELETE FROM Bill


EXEC USP_InsertBillInfo 1,5,1
SELECT MAX(idBill) FROM Bill

UPDATE TableFood Set statusTF=N'Trong'

USE QuanLyQuanCafe
GO

ALTER TRIGGER UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill = idBill FROM inserted
	DECLARE @idTable INT
	SELECT @idTable = idTF FROM dbo.Bill WHERE idBill=@idBill AND statusBill=0
	UPDATE dbo.TableFood SET statusTF=N'Co khach' WHERE idTF=@idTable
END
GO
---Sua UpdtateBillInfo
ALTER TRIGGER UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill = idBill FROM inserted
	
	DECLARE @idTable INT
	SELECT @idTable = idTF FROM dbo.Bill WHERE idBill=@idBill AND statusBill=0
	
	DECLARE @count int
	Select @count=COUNT(*) from BillInfo where idBill=@idBill
	if(@count>0)
	
		UPDATE dbo.TableFood SET statusTF=N'Co khach' WHERE idTF=@idTable
		
	else
		UPDATE dbo.TableFood SET statusTF=N'Trong' WHERE idTF=@idTable
END
GO
----------Cap nhat hoa don------
ALTER TRIGGER UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill = idBill FROM inserted
	
	DECLARE @idTable INT
	SELECT @idTable = idTF FROM dbo.Bill WHERE idBill=@idBill
	
	DECLARE @count int =0
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idBill=@idBill AND statusBill=0
	IF(@count = 0)
		UPDATE dbo.TableFood SET statusTF=N'Trong' WHERE idTF=@idTable
END
GO

sp_help 'dbo.BillInfo'
DROP Trigger UpdateBillInfo
Select * from Account

--Cap nhat lai tai khoan----
CREATE PROC UpdateAcc
@username NVARCHAR(100), @displayname NVARCHAR(100), @pass NVARCHAR(100),@newpass NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	Select @isRightPass =COUNT(*) From Account Where UserName=@username and PassWord=@pass
	
	If (@isRightPass=1)
	Begin
		If(@newpass = null or @newpass='')
		Begin
			Update Account Set DisplayName=@displayname Where UserName=@username
		End
		Else
			Update Account Set DisplayName=@displayname,PassWord=@newpass Where UserName=@username
	End
END
GO
------Thong ke doanh thu-----
ALTER TABLE Bill ADD totalPrice FLOAT

CREATE PROC USP_GetListBillByDate
@checkin date, @chechkout date
AS
BEGIN
	SELECT t.nameTF,dateCheckIn,dateCheckOut,b.totalPrice
	FROM Bill as b,TableFood as t,BillInfo as bi,Food as f
	WHERE dateCheckIn >='20201201' and dateCheckOut <='20201230' and statusBill=1 and
		b.idTF=t.idTF and bi.idBill=b.idBill and bi.idFood=f.idFood
END
GO
