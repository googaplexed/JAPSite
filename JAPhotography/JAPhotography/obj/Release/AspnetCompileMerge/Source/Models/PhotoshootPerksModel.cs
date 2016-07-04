using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAPhotography.Models
{
    public class PhotoshootPerksModel
    {
        public int ID { get; set; }
        public int PhotoshootPerksID { get; set; }
        // How long is the shoot?
        public int ShootLength { get; set; }
        public bool PrintRights { get; set; }
        public string DeliveryFormat { get; set; }
        public string[] PrintSizes { get; set; }
        public string Notes { get; set; }
    }
}
