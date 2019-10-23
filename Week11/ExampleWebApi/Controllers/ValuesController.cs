using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExampleWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        static string testvalue = "Not set yet";

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", testvalue };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return testvalue + " " + id;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            testvalue = "post " + value;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            testvalue = "put " + value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            testvalue = "delete " + id;
        }
    }
}
