CREATE PROCEDURE [dbo].[spAccount_Update]
	@Id int,
	@Email nvarchar(50),
	@UserName nvarchar(50),
	@Password nvarchar(50),
	@AccountName nvarchar(50)
AS
begin
	update dbo.[Account] 
	set Email = @Email, Username = @UserName,
	Password = @Password, AccountName = @AccountName
	where Id = @Id
end
