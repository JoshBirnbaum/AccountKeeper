using AccountManagerUI.DbAccess;
using AccountManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagerUI.Data;

public class AccountData : IAccountData
{
    private readonly ISqlDataAccess _db;
    public AccountData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<AccountModel>> GetAccounts() =>
        _db.LoadData<AccountModel, dynamic>("dbo.spAccount_GetAll", new { });

    public Task InsertAccount(AccountModel account) =>
        _db.SaveData("dbo.spAccount_Insert",
            new { account.Email, account.UserName, account.Password, account.AccountName });

    public Task UpdateAccount(AccountModel account) =>
        _db.SaveData("dbo.spAccount_Update", account);

    public Task DeleteAccount(int id) =>
        _db.SaveData("dbo.spAccount_Delete", new { Id = id });
}
