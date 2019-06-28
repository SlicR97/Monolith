using Monolith.DAL.Models;
using System;
using System.Windows.Media.Imaging;

namespace MonolithBurgers.Modules.Overview.Models
{
   public class ProductModel
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string ImageUrl { get; set; }
      public BitmapImage BitmapImage 
      { 
         get
         { 
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(ImageUrl, UriKind.Absolute);
            bitmap.EndInit();
            return bitmap;
         } 
      }

      public Category Category { get; set; }
      public SizeModel Size { get; set; }
   }
}
