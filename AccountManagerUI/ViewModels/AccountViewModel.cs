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
            Data = new();
            GetAccounts();
        }

        #region Properties

        private AccountData Data { get; set; }

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
            if(AddUsername != null && AddPassword != null && AddAccountName != null)
            {
                AccountModel account = new AccountModel
                {
                    Email = AddUsername,
                    UserName = AddUsername,
                    Password = AddPassword,
                    AccountName = AddAccountName,
                };
                Console.WriteLine(AddAccountName);
                Data.InsertAccount(account);
                ClearInputs();
                GetAccounts();
            }
        }

        private void RemoveAccount(object obj)
        {
            if (obj != null)
            {
                int id = Int16.Parse(obj.ToString());
                Data.DeleteAccount(id);
                GetAccounts();
            }
        }

        private void ClearInputs()
        {
            AddAccountName = "";
            AddUsername = "";
            AddPassword = "";
        }

        private async void GetAccounts()
        {
            Accounts = (List<AccountModel>)await Data.GetAccounts();
            if(Accounts != null)
            {
                Console.WriteLine(Accounts);
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
