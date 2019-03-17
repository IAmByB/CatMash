using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace CatMash.Entities
{

    [Serializable]
    public class Image
    {
        public string url { get; set; }
        public string id { get; set; }
        public int points { get; set; }

        public Image()
        {
        }

      

        public Image(string infos)
        {
            // En l'absence de base de données, les points attribués à chaque chat sont simulés par une valeur aléatoire
            Random random = new Random(DateTime.Now.Millisecond);
            Thread.Sleep(1);
            int rnd = random.Next(0,99);

            JToken outer = JToken.Parse(infos);
            id = outer["id"].Value<string>();
            url = outer["url"].Value<string>();
            points = rnd;
        }
    }
}