using System;

namespace DataAccess;

public class AccountData
{
    public AccountData()
    {
        DataAccess = new();
    }
    private SqlDataAccess DataAccess { get; set; }
    public async Task<IEnumerable<AccountModel>> GetAccounts()
    {
        object accounts = await DataAccess.LoadData<AccountModel, dynamic>("dbo.spAccount_GetAll", new { });
        return (IEnumerable<AccountModel>)accounts;
    }

    public async void InsertAccount(AccountModel account)
    {
        await DataAccess.SaveData("dbo.spAccount_Insert", new {account.Email, account.UserName, account.Password, account.AccountName});
    }

    public async void DeleteAccount(int id)
    {
        await DataAccess.SaveData("dbo.spAccount_Delete", new { Id = id });
    }
}
