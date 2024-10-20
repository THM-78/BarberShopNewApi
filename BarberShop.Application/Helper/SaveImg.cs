using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Helper
{
    public class SaveImg
    {
        public static void Save(IFormFile file)
        {
            string paath = Directory.GetCurrentDirectory();
            string mainPath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(paath)), $"BarberShopNewFront/Resources/{file.FileName}");

            using (Stream stream = new FileStream(mainPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
    }
}
