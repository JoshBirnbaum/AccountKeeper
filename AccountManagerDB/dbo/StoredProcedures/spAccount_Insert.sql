CREATE PROCEDURE [dbo].[spAccount_Insert]
	@Email nvarchar(50),
	@UserName nvarchar(50),
	@Password nvarchar(50),
	@AccountName nvarchar(50)
AS
begin
	insert into dbo.[Account] (Email, UserName, Password, AccountName)
	values (@Email, @UserName, @Password, @AccountName);
end
