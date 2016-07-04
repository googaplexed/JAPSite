using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAPhotography.Models
{
    public class FileModel
    {
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Thumbnail { get; set; }
        public byte[] Image { get; set; }
        public FileType FileType { get; set; }
        public int ClientId { get; set; }
        public virtual ClientModel Client { get; set; }
        public PhotoshootType PhotoshootType { get; set; }
        [StringLength(100)]
        public string AlbumName { get; set; }
        [StringLength(140)]
        public string Caption { get; set; }
        [StringLength(140)]
        public string Details { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int FileSize { get; set; }
        public DateTime DateAdded { get; set; }
        public bool Active { get; set; }
        public int ViewCount { get; set; }
        public int DownloadCount { get; set; }
    }
}
