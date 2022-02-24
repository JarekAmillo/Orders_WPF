using Claims_WPF.Models.Wrappers;
using Orders_WPF.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders_WPF.Models.Converters
{
    public static class ClaimConverter
    {

        public static ClaimWrapper ToWrapper (this Claim model)
        {
            return new ClaimWrapper
            {
                Id = model.Id,
                ClaimNumber = model.ClaimNumber,
                TaskNumber = model.TaskNumber,
                TypeOfTask = new TypeOfTaskWrapper
                    { 
                        Id = model.TypeOfTask.Id,
                        Name = model.TypeOfTask.Name
                     },

            };
        }

        public static Claim ToDao(this ClaimWrapper model)
        {
            return new Claim
            {
                Id = model.Id,
                ClaimNumber = model.ClaimNumber,
                TaskNumber = model.TaskNumber,
                TypeOfTaskId = model.TypeOfTask.Id,
            };

        }



    }
}
