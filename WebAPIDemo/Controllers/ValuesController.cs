using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
       static List<string> strings = new List<string>
        {
            "String0","String1","String2"
        };

        // GET api/values
        public string Get()
        {
           return "Values Controller GET";
        }

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return strings[id];
        //}

        // POST api/values
        public void Post([FromBody]string value)
        {
            strings.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            strings[id]= value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            strings.RemoveAt(id);
        }
        public HttpResponseMessage Get(int id)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine("Hello, World!");
            writer.WriteLine("Hello, World1");
            writer.WriteLine("Hello, World2");
            writer.Flush();
            stream.Position = 0;

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Export.csv" };
            return result;
        }
    }
}
