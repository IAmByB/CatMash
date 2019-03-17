using CatMash.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace CatMash.BusinessLayer
{
    public static class BusinessLayer
    {
        /// <summary>
        /// Décodage et récupération des données concernant les chats
        /// </summary>
        /// <returns>Objet images contenant les données sur les chats</returns>
        public static images GetCats()
        {
            images images = new images();

            try
            {
                // Récupération des données JSON
                List<Image> lstImage = new List<Image>();

                // Appel du DataLayer
                string jsonString = DataLayer.DataLayer.GetImages();

                JToken outer = JToken.Parse(jsonString);
                JArray inner = outer["images"].Value<JArray>();
                foreach(JToken token in inner)
                {
                    lstImage.Add(new Image(token.ToString()));    
                }

                // Construction de l'objet Images
                images.data = new Image[lstImage.Count];
                for(int i=0;i<lstImage.Count;i++)
                {
                    images.data[i] = lstImage[i];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erreur lors de la récupération des données : {0}", ex.Message));
            }
            return images;

        }
    }
}