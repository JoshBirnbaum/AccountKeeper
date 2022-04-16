CREATE PROCEDURE [dbo].[spAccount_Delete]
	@Id int
AS
begin
	delete
	from dbo.[Account]
	where Id = @Id;
end
