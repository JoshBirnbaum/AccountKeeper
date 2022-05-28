using System;

namespace DataAccess;

public class AccountData
{
    public static async Task<IEnumerable<AccountModel>> GetAccounts()
    {
        SqlDataAccess sda = new SqlDataAccess();
        object accounts = await sda.LoadData<AccountModel, dynamic>("dbo.spAccount_GetAll", new { });
        return (IEnumerable<AccountModel>)accounts;
    }

    public static async Task InsertAccount(AccountModel account)
    {
        SqlDataAccess sda = new SqlDataAccess();
        await sda.SaveData("dbo.spAccount_Insert", new {account.Email, account.UserName, account.Password, account.AccountName});
    }

    public static async Task DeleteAccount(int id)
    {
        SqlDataAccess sda = new SqlDataAccess();
        await sda.SaveData("dbo.spAccount_Delete", new { Id = id });
    }
}
