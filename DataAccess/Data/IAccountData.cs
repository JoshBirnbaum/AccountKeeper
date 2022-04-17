using AccountManagerUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManagerUI.Data
{
    public interface IAccountData
    {
        Task DeleteAccount(int id);
        Task<IEnumerable<AccountModel>> GetAccounts();
        Task InsertAccount(AccountModel account);
        Task UpdateAccount(AccountModel account);
    }
}