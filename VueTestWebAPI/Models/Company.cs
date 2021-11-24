using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueTestWebAPI.Models {
    public class Company:ModelEntity {   
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
