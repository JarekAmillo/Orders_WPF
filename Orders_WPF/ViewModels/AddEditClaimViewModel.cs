using Claims_WPF.Commands;
using Claims_WPF.Models;
using Claims_WPF.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Claims_WPF.ViewModels
{
    class AddEditClaimViewModel :ViewModelBase
    {
        public AddEditClaimViewModel(ClaimWrapper claim = null)
        {
            CloseCommand = new RelayCommand(Close, null);
            ConfirmCommand = new RelayCommand(Confirm, null);
            InitTypeOfTasks();

            if (claim == null)
            {
                Claim = new ClaimWrapper();
            }
            else
            {
                Claim = claim;
                IsUpdate = true;
            }
            
        }


        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }


        private ClaimWrapper _claim;
        public ClaimWrapper Claim
        {
            get { return _claim; }
            set 
            { 
                _claim = value;
                OnPropertyChanged();
            }
        }


        private bool _isUpdate;
        public bool IsUpdate
        {
            get { return _isUpdate; }
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }

        private int _selectedTypeId;
        public int SelectedTypeId
        {
            get { return _selectedTypeId; }
            set
            {
                _selectedTypeId = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TypeOfTaskWrapper> _typeOfTasks;
        public ObservableCollection<TypeOfTaskWrapper> TypeOfTasks
        {
            get { return _typeOfTasks; }
            set
            {
                _typeOfTasks = value;
                OnPropertyChanged();
            }
        }

        private void Confirm(object obj)
        {
            if (!IsUpdate)
            {
                AddClaim();
            }
            else
            {
                UpdateClaim();
            }
            
            //
            CloseWindow(obj as Window);
        }

        private void UpdateClaim()
        {
            //baza danych
        }

        private void AddClaim()
        {
            //baza danych
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }


        private void CloseWindow(Window window)
        {
            window.Close();
        }

        private void InitTypeOfTasks()
        {
            TypeOfTasks = new ObservableCollection<TypeOfTaskWrapper>
            {
            new TypeOfTaskWrapper { Id = 0, Name = "-- brak --"},
            new TypeOfTaskWrapper { Id = 1, Name = "Typ C"},
            new TypeOfTaskWrapper { Id = 2, Name = "Typ C1"},
            new TypeOfTaskWrapper { Id = 3, Name = "Typ C2"},
            new TypeOfTaskWrapper { Id = 4, Name = "Typ D2"}
            };
            SelectedTypeId = 0;
        }
    }
}
