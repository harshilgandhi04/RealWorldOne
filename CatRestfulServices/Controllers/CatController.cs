using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        // GET: api/<CatController>
        [HttpGet]
        public IActionResult Get()
        {
            // Get Cat Image from APIEndpoint
            string catApiEndpoint = "https://cataas.com/cat";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(catApiEndpoint);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            //Rotate Image Upside-Down
            System.Drawing.Image image = System.Drawing.Image.FromStream(responseStream);
            image.RotateFlip(RotateFlipType.Rotate180FlipX);

            //Convert Image to byte and return
            Byte[] b = (byte[])new ImageConverter().ConvertTo(image, typeof(byte[]));
            return File(b, "image/jpeg");
        }

        // GET api/<CatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT api/<CatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
