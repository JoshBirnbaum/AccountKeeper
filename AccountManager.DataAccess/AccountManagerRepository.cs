using AccountManager.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.Data.SqlClient;

namespace AccountManager.DataAccess;

public class AccountManagerRepository
{
    AccountManagerDBContext context;
	public AccountManagerRepository()
	{
		context = new AccountManagerDBContext();
	}

	public List<Account> GetAllAccounts()
	{
		List<Account> accounts = null;
		try
		{
			accounts = context.Accounts.ToList();
			//accounts = (from a in context.Accounts select a).ToList();
        }
		catch (Exception e)
		{
			accounts = null;
		}
		return accounts;
	}
	public bool AddAccount(Account accnt)
	{
		bool status;
		try
		{
			SqlParameter prmEmail = new SqlParameter("@Email", System.Data.SqlDbType.VarChar, 50);
			prmEmail.Value = accnt.Email;
			SqlParameter prmUserName = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar, 50);
			prmUserName.Value = accnt.UserName;
			SqlParameter prmPassword = new SqlParameter("@Password", System.Data.SqlDbType.VarChar, 50);
			prmPassword.Value = accnt.Password;
            SqlParameter prmAccountName = new SqlParameter("@AccountName", System.Data.SqlDbType.VarChar, 50);
			prmAccountName.Value = accnt.AccountName;

			context.Database.ExecuteSqlRaw("EXEC spAccount_Insert @Email, @UserName, @Password, @AccountName", prmEmail, prmUserName, prmPassword, prmAccountName);
			status = true;
        }
		catch (Exception)
		{
			status = false;
		}
		return status;
	}
}
