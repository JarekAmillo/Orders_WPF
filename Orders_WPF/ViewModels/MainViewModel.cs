using Claims_WPF.Commands;
using Claims_WPF.Models;
using Claims_WPF.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
//using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Claims_WPF.ViewModels
{
    class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {

            AddTaskCommand = new RelayCommand(AddEditTask, null);
            EditTaskCommand = new RelayCommand(AddEditTask, CanEditDeleteClaim);
            DeleteTaskCommand = new AsyncRelayCommand(DeleteTask, CanEditDeleteClaim);
            RefreshTaskCommand = new RelayCommand(RefreshTask, CanRefreshClaims);

            RefreshClaims();
            InitTypeOfTasks();
        }



        public ICommand AddTaskCommand { get; set; }
        public ICommand EditTaskCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }
        public ICommand RefreshTaskCommand { get; set; }



        public ICommand RefreshClaimsCommand { get; set; }


        private Claim _selectedClaim;
        public Claim SelectedClaim
        {
            get { return _selectedClaim; }
            set
            {
                _selectedClaim = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<Claim> _claims;
        public ObservableCollection<Claim> Claims
        {
            get { return _claims; }
            set
            {
                _claims = value;
                OnPropertyChanged();
            }
        }


        private int _selectedTypeId;
        public int SelectedTypeId
        {
            get { return _selectedTypeId; }
            set 
            { _selectedTypeId = value;
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


        private bool CanRefreshClaims(object obj)
        {
            return true;
        }

        private void RefreshClaims(object obj)
        {
            MessageBox.Show("RefreshClaims");
        }

        private void InitTypeOfTasks()
        {
            TypeOfTasks = new ObservableCollection<TypeOfTask>
            {
            new TypeOfTask { Id = 0, Name = "Wszystkie"},
            new TypeOfTask { Id = 1, Name = "Typ C"},
            new TypeOfTask { Id = 2, Name = "Typ C1"},
            new TypeOfTask { Id = 3, Name = "Typ C2"},
            new TypeOfTask { Id = 4, Name = "Typ D2"}
            };
            SelectedTypeId = 0;
        }

        private void RefreshTask(object obj)
        {
            RefreshClaims();
        }
        private bool CanEditDeleteClaim(object obj)
        {
            return SelectedClaim != null;
        }

        private async Task DeleteTask(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync(
                "Usuwanie zlecenia", $"Czy na pewno chcesz usunąć zlecenie {SelectedClaim.ClaimNumber}?", MessageDialogStyle.AffirmativeAndNegative);

            if (dialog != MessageDialogResult.Affirmative)
            {
                return;
            }

            //usuwanie z bazy danych

            RefreshClaims();
        
        }

        private void AddEditTask(object obj)
        {
            var AddEditTaskWindow = new AddEditClaimView (obj as Claim);
            AddEditTaskWindow.Closed += AddEditTaskWindow_Closed;
            AddEditTaskWindow.ShowDialog();
        }

        private void AddEditTaskWindow_Closed(object sender, EventArgs e)
        {
            RefreshClaims();
        }

        private void RefreshClaims()
        {
            Claims = new ObservableCollection<Claim>
            {
                new Claim
                {
                    ClaimNumber = "KR20/5678/22",
                    TaskNumber = "C/123/2022",
                    TypeOfTask = new TypeOfTask { Id = 1, Name = "C"}
                },

                new Claim
                {
                    ClaimNumber = "PO20/5678/22",
                    TaskNumber = "C/423/2022",
                    TypeOfTask = new TypeOfTask { Id = 2, Name = "C"}
                },

                new Claim
                {
                    ClaimNumber = "GD20/5678/22",
                    TaskNumber = "C/723/2022",
                    TypeOfTask = new TypeOfTask { Id = 3, Name = "C"}
                },
            };
        }
    }
}
