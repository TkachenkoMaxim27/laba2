using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Model
{
    public class Employes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public PickupPoints FK_PickupPoint { get; set; }
    }
}
