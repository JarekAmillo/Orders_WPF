using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders_WPF.Models.Domains
{
    public class TypeOfTask
    {
        public TypeOfTask()
        {
            Claims = new Collection<Claim>();
        }

        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection <Claim> Claims { get; set; }
    }
}
