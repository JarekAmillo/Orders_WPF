using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_WPF.Models.Wrappers
{
    public class ClaimWrapper : IDataErrorInfo
    {
        public ClaimWrapper()
        {
            TypeOfTask = new TypeOfTaskWrapper();
        }

        public int Id { get; set; }
        public string ClaimNumber { get; set; }
        public string TaskNumber { get; set; }
        public TypeOfTaskWrapper TypeOfTask { get; set; }
        public DateTime DateToRegisterTheClaim { get; set; }
        public string Comments { get; set; }



        private bool _isClaimNumberValid;
        private bool _isTaskNumberValid;


        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(ClaimNumber):
                        if (string.IsNullOrWhiteSpace(ClaimNumber))
                        {
                            Error = "Pole jest wymagane.";
                            _isClaimNumberValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isClaimNumberValid = true;
                        }
                        break;
                    case nameof(TaskNumber):
                        if (string.IsNullOrWhiteSpace(TaskNumber))
                        {
                            Error = "Pole jest wymagane.";
                            _isTaskNumberValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isTaskNumberValid = true;
                        }
                        break;
                    default:
                        break;
                }

                return Error;
            }

        }


        public string Error { get; set; }

        public bool IsValid
            {
            get
                {
                return _isClaimNumberValid && _isTaskNumberValid && TypeOfTask.IsValid;
                }
            }

    }
}
