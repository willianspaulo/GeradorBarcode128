using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using Zen.Barcode;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Barcode128JPGController : ControllerBase
    {
        // GET api/Barcode128/35230601253053000268572200000484641234346939
        [HttpGet("{chave}")]
        public FileResult Get(string chave)
        {
            //string barcodeValue = "1234567890"; // O valor do código de barras

            Code128BarcodeDraw barcodeDraw = BarcodeDrawFactory.Code128WithChecksum;
            var barcodeImage = barcodeDraw.Draw(chave, 40); // 40 é a altura da imagem do código de barras em pixels

            // Converter a imagem para Base64
            string base64String;
            using (MemoryStream ms = new MemoryStream())
            {
                barcodeImage.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                //base64String = Convert.ToBase64String(imageBytes);

                return File(imageBytes, "image/jpeg", "code128_barcode.jpg");
            }

        }
    }
}
