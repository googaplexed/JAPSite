using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAPhotography.Models
{
    public class DirImagesModel
    {
        public int ID { get; set; }

        public string ImageURL { get; set; }

        public IEnumerable<string> Thumbnails { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
