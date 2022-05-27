using AccountManagerUI.Core;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AccountManagerUI.ViewModels
{
    public class AccountViewModel : ObservableObject
    {

        public AccountViewModel()
        {
            AccountData data = new();
            Data = data;
            GetAccounts();
        }

        private AccountData Data { get; set; }

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

        private ICommand _copyPasswordCommand;
        public ICommand CopyPasswordCommand
        {
            get
            {
                if (_copyPasswordCommand == null)
                {
                    _copyPasswordCommand = new RelayCommand(CopyPassword);
                }
                return _copyPasswordCommand;
            }
                set { _copyPasswordCommand = value; }
        }


        public async void GetAccounts()
        {
            Accounts = (List<AccountModel>)await Data.GetData();
        }

        private static void CopyPassword(object obj)
        {
            if(obj != null)
            {
                Clipboard.SetText(obj.ToString());
            }
        }

    }
}
