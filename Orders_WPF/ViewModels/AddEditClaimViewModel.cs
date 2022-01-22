using Claims_WPF.Commands;
using Claims_WPF.Models;
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
        public AddEditClaimViewModel(Claim claim = null)
        {
            CloseCommand = new RelayCommand(Close, null);
            ConfirmCommand = new RelayCommand(Confirm, null);
            InitTypeOfTasks();

            if (claim == null)
            {
                Claim = new Claim();
            }
            else
            {
                Claim = claim;
                IsUpdate = true;
            }

        }



        public ICommand CloseCommand { get; set; }


        public ICommand ConfirmCommand { get; set; }


        private Claim _claim;
        public Claim Claim
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

        private ObservableCollection<TypeOfTask> _typeOfTasks;
        public ObservableCollection<TypeOfTask> TypeOfTasks
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
                AddStudent();
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

        private void AddStudent()
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
            TypeOfTasks = new ObservableCollection<TypeOfTask>
            {
            new TypeOfTask { Id = 0, Name = "-- brak --"},
            new TypeOfTask { Id = 1, Name = "Typ C"},
            new TypeOfTask { Id = 2, Name = "Typ C1"},
            new TypeOfTask { Id = 3, Name = "Typ C2"},
            new TypeOfTask { Id = 4, Name = "Typ D2"}
            };
            Claim.TypeOfTask.Id = 0;
        }
    }
}
