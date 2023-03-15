using AccountManager.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.FileSystemGlobbing.Internal;

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
}
