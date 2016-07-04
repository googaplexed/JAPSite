using System;
using System.Web;

namespace JAPhotography.Repositories
{
    public class ImageHandler
    {
        //private readonly ImageContext db = new ImageContext();
        //public int UploadImageInDatabase(HttpPostedFileBase thumbnail, HttpPostedFileBase fullImage, ImageViewModel imageViewModel)
        //{
        //    if (file.InputStream != )
        //        using (var img = Image.FromStream(fullImage.InputStream))
        //        {
        //            imageViewModel.height = img.Height;
        //            imageViewModel.width = img.Width;
        //            imageViewModel.size = fullImage.ContentLength;
        //            imageViewModel.type = Path.GetExtension(fullImage.FileName);
        //        }

        //    imageViewModel.image = ConvertToBytes(fullImage);
        //    imageViewModel.thumbnail = ConvertToBytes(thumbnail);

        //    var saveImage = new ImageModel
        //    {
        //        photoName = imageViewModel.photoName,
        //        photoCaption = imageViewModel.photoCaption,
        //        thumbnail = imageViewModel.thumbnail,
        //        image = imageViewModel.image,
        //        //client = imageViewModel.client,
        //        width = imageViewModel.width,
        //        height = imageViewModel.height,
        //        //type = imageViewModel.type,
        //        size = imageViewModel.size,
        //        dateAdded = DateTime.Now
        //    };

        //    db.DbImages.Add(saveImage);
        //    int i = db.SaveChanges();
        //    if (i == 1)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            //BinaryReader reader = new BinaryReader(image.InputStream);
            //imageBytes = reader.ReadBytes(image.InputStream.Length);
            imageBytes = new Byte[image.ContentLength];
            image.InputStream.Position = 0;
            image.InputStream.Read(imageBytes, 0, image.ContentLength);
            return imageBytes;
        }
    }
}
