using Claims_WPF.Commands;
using Claims_WPF.Models;
using Claims_WPF.Models.Wrappers;
using Orders_WPF;
using Orders_WPF.Models.Domains;
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

        private Repository _repository = new Repository();


        public AddEditClaimViewModel(ClaimWrapper claim = null)
        {
            CloseCommand = new RelayCommand(Close, null);
            ConfirmCommand = new RelayCommand(Confirm, null);

            if (claim == null)
            {
                Claim = new ClaimWrapper();
                Claim.DateToRegisterTheClaim = DateTime.Now;
            }
            else
            {
                Claim = claim;
                IsUpdate = true;
            }
            InitTypeOfTasks();
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
            if (!Claim.IsValid)
            {
                return;
            }
            
            
            
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
            _repository.UpdateClaim(Claim);
        }

        private void AddClaim()
        {
            //baza danych
            _repository.AddClaim(Claim);
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
            var typeOfTasks = _repository.GetTypeOfTasks();
            typeOfTasks.Insert(0, new TypeOfTask { Id = 0, Name = "-- brak --" });


            TypeOfTasks = new ObservableCollection<TypeOfTask>(typeOfTasks);

            //SelectedTypeId = 0;
            //ToString poniżej powinno działać a nie działa - sprawdzić
            //Claim.TypeOfTask.Id = 0;
            SelectedTypeId = Claim.TypeOfTask.Id;
        }
    }
}
