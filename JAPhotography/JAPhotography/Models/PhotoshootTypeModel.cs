using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAPhotography.Models
{
    //public class PhotoshootTypeModel
    //{
    //    public int ID { get; set; }
    //    public string PhotoshootType { get; set; }
    //    public decimal Price { get; set; }
    //    public int SampleImageID { get; set; }
    //    // This type of photoshoot is currently active
    //    public bool ActiveType { get; set; }        
    //}

    public enum PhotoshootType
    {
        Senior = 1,
        Nature = 2
    }
}
