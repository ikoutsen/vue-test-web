using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueTestWebAPI.Models {
    public class Employee : ModelEntity {
        public string Name { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public bool IsOnHoliday { get; set; }
    }
}