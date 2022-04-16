CREATE PROCEDURE [dbo].[spAccount_GetAll]
AS
begin
	select *
	from dbo.[Account];
end
