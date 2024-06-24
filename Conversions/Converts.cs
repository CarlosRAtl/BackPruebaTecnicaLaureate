using System.IO;
using System.Text;

namespace BackEndPruebaTecnicsLaureate.Conversions
{
    public class Converts
    {
        public string Text(string Text)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(Text);
            string base64Text = Convert.ToBase64String(textBytes);
            return base64Text;
        }

        public string Image(IFormFile Path, string idEmployee)
        {
            string fileName = idEmployee + ".jpg";
            string filePath = @$"../FrontEndPruebaTecnicaLaureate/src/assets/Images/{fileName}";
            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                Path.CopyTo(stream);
            }
            return filePath;
        }
    }
}
