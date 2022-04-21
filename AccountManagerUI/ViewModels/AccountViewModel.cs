using AccountManagerUI.Core;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountManagerUI.ViewModels
{
    public class AccountViewModel : ObservableObject
    {

        public AccountViewModel()
        {
            AccountData data = new();
            Data = data;
        }

        public AccountData Data { get; set; }

        private List<AccountModel> _accounts;
        public List<AccountModel> Accounts
        {
            get { return _accounts; }
            set 
            { 
                _accounts = value;
                NotifyPropertyChanged();
            }
        }


        private ICommand _getAccountsCommand;
        public ICommand GetAccountsCommand
        {
            get 
            { 
                if(_getAccountsCommand == null)
                {
                    _getAccountsCommand = new RelayCommand(x => GetAccounts());
                }
                return _getAccountsCommand; 
            }
            set { _getAccountsCommand = value; }
        }

        public async void GetAccounts()
        {
            Accounts = (List<AccountModel>)await Data.GetData();
        }

    }
}
