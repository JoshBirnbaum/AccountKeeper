using AccountManager.DataAccess;
using AccountManager.DataAccess.Models;
using AccountManagerUI.Core;
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
            GetAccounts();
        }

        #region Properties

        private string _addAccountName;
        public string AddAccountName
        {
            get { return _addAccountName; }
            set 
            { 
                _addAccountName = value;
                NotifyPropertyChanged();
            }
        }

        private string _addUsername;
        public string AddUsername
        {
            get { return _addUsername; }
            set
            {
                _addUsername = value;
                NotifyPropertyChanged();
            }
        }

        private string _addPassword;
        public string AddPassword
        {
            get { return _addPassword; }
            set
            {
                _addPassword = value;
                NotifyPropertyChanged();
            }
        }

        private List<Account> _accounts;
        public List<Account> Accounts
        {
            get { return _accounts; }
            set 
            { 
                _accounts = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Commands

        private ICommand _getNewAccountInfo;
        public ICommand GetNewAccountInfo
        {
            get
            {
                if (_getNewAccountInfo == null)
                {
                    _getNewAccountInfo = new RelayCommand(x => AddAccount());
                }
                return _getNewAccountInfo;
            }
            set { _getNewAccountInfo = value; }
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

        private ICommand _removeAccountCommand;
        public ICommand RemoveAccountCommand
        {
            get
            {
                if (_removeAccountCommand == null)
                {
                    _removeAccountCommand = new RelayCommand(RemoveAccount);
                }
                return _removeAccountCommand;
            }
            set { _removeAccountCommand = value; }
        }


        #endregion

        #region Functions

        private void AddAccount()
        {
            AccountManagerRepository repository = new AccountManagerRepository();
            if (AddUsername != null && AddPassword != null && AddAccountName != null)
            {
                Account account = new Account
                {
                    Email = AddUsername,
                    UserName = AddUsername,
                    Password = AddPassword,
                    AccountName = AddAccountName,
                };
                bool status = repository.AddAccount(account);
                if (status)
                {
                    ClearInputs();
                    GetAccounts();
                }
            }
        }

        private void RemoveAccount(object obj)
        {
            int id = (int)obj;
            if(id > 0)
            {
                AccountManagerRepository repository = new AccountManagerRepository();
                bool status = repository.DeleteAccount(id);
                if (status)
                {
                    GetAccounts();
                }
            }
        }

        private void ClearInputs()
        {
            AddAccountName = "";
            AddUsername = "";
            AddPassword = "";
        }

        private void GetAccounts()
        {
            AccountManagerRepository repository= new AccountManagerRepository();
            Accounts = repository.GetAllAccounts();
            if(Accounts != null)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine(Accounts);
                Console.WriteLine("-------------------");
            }
        }

        private static void CopyPassword(object obj)
        {
            if(obj != null)
            {
                Clipboard.SetText(obj.ToString());
            }
        }

        #endregion
    }
}
