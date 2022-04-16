using AccountManagerUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AccountManagerUI.ViewModels
{
    public class MainWindowViewModel
    {
        #region Commands
        private ICommand? _shutdownCommand;
        public ICommand ShutdownCommand
        {
            get
            {
                if (_shutdownCommand == null)
                {
                    _shutdownCommand = new RelayCommand(x => ShutdownApplication());
                }
                return _shutdownCommand;
            }
            set { _shutdownCommand = value; }
        }

        private ICommand? _minimizeCommand;
        public ICommand MinimizeCommand
        {
            get
            {
                if (_minimizeCommand == null)
                {
                    _minimizeCommand = new RelayCommand(x => MinimizeApplication());
                }
                return _minimizeCommand;
            }
            set { _minimizeCommand = value; }
        }

        private ICommand? _resizeCommand;

        public ICommand ResizeCommand
        {
            get
            {
                if (_resizeCommand == null)
                {
                    _resizeCommand = new RelayCommand(x => ResizeApplication());
                }
                return _resizeCommand;
            }
            set { _resizeCommand = value; }
        }
        #endregion

        #region Functions
        private void ShutdownApplication()
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MinimizeApplication()
        {
            System.Windows.Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ResizeApplication()
        {
            if (System.Windows.Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                System.Windows.Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                System.Windows.Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }
        #endregion
    }
}
