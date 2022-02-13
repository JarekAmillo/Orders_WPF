using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_WPF.Models.Wrappers
{
    public class ClaimWrapper
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
    }
}
