using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAPhotography.ViewModel
{
    public class ImageViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Photo Name")]
        public string photoName { get; set; }
        [Display(Name = "Caption")]
        public string photoCaption { get; set; }
        [Display(Name = "Thumbnail")]
        public byte[] thumbnail { get; set; }
        [Display(Name = "Image")]
        public byte[] image { get; set; }
        [Display(Name = "Client")]
        public string client { get; set; }
        [Display(Name = "File Type")]
        public string type { get; set; }
        [Display(Name = "Width")]
        public int width { get; set; }
        [Display(Name = "Height")]
        public int height { get; set; }
        [Display(Name = "File Size")]
        public int size { get; set; }
        [Display(Name = "Date Added")]
        public DateTime dateAdded { get; set; }
    }
}
