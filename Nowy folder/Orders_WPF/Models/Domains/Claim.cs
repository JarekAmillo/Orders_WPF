 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders_WPF.Models.Domains
{
    public class Claim
    {
        public Claim()
        {
            //TypeOfTask = new TypeOfTask();
        }


        public int Id { get; set; }
        public string ClaimNumber { get; set; }
        public string TaskNumber { get; set; }
        public int TypeOfTaskId { get; set; }
        public string Comments { get; set; }
        public DateTime DateToRegisterTheClaim { get; set; }


        public TypeOfTask TypeOfTask { get; set; }

    }
}
