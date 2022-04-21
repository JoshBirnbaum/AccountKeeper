using System;

namespace DataAccess;

public class AccountData
{
    public async Task<IEnumerable<AccountModel>> GetData()
    {
        SqlDataAccess sda = new SqlDataAccess();
        object accounts = await sda.LoadData<AccountModel, dynamic>("dbo.spAccount_GetAll", new { });
        return (IEnumerable<AccountModel>)accounts;
    }
}
