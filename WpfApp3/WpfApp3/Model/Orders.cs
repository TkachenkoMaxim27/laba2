using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Model
{
    public class Orders
    {
        public int Id { get; set; }
        public PickupPoints FK_PickupPoint { get; set; }
        public Client FK_Client { get; set; }
        public DateTime date { get; set; }
    }
}
