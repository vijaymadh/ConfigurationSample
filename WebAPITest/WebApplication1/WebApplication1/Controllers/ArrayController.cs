using System.Collections.Generic;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ArrayController : ApiController
    {       
        [HttpGet]
        [ActionName("reverse_array")]
        public string[] ReverseArray()
        {
            return new string[] { "H", "e", "l", "l", "o", " ", "W", "o", "r", "l", "d", "!" };//// this.ReverseArray(new string[] { "H", "e", "l", "l", "o", " ", "W", "o", "r", "l", "d", "!" });
        }

        [HttpPost]
        [ActionName("reverse_array")]
        public string[] ReverseArray(string[] array)
        {

            return array;
        }

        //[HttpPost]
        //[ActionName("reverse_array")]
        //public string[] ReverseArray(string[] array)
        //{

        //    return array;
        //}

        /*


                //[HttpGet]
                //[ActionName("reverse_array_get")]
                //public string[] ReverseArrayGet(IEnumerable<string> array)
                //{            
                //    //var reverser = ReverserFactory.GetInstance().GetStringArrayReverser();

                //    //var reversingTask = Task.Factory.StartNew(() =>
                //    //{
                //    //    array = reverser.Reverse(array.ToArray());
                //    //});

                //    //reversingTask.Wait();
                //    return null;
                //}


                [HttpGet]
                [ActionName("reverse_string_get")]
                public string[] ReverseStringGet(string array)
                {

                    return array.Split(',');
                }

                [HttpPost]

                [ActionName("reverse_string_post")]
                public string[] ReverseStringPost([FromBody]string array)
                {

                    return array.Split(',');
                }*/
    }
}
