
using System;
using System.IO;
using System.Net;
using System.Text;

namespace CatMash.DataLayer
{
    public static class DataLayer
    {
        /// <summary>
        /// Récupération des données JSon
        /// </summary>
        /// <returns>Données sous forme de chaine JSon</returns>
        public static string GetImages()
        {
            try
            {
                byte[] buffer = new byte[100];
                StringBuilder stringbuilder = new StringBuilder();
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://latelier.co/data/cats.json");
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream stream = httpWebResponse.GetResponseStream();
                string tempString = null;
                int counter = 0;

                do
                {
                    counter = stream.Read(buffer, 0, buffer.Length);
                    if (counter != 0)
                    {
                        tempString = Encoding.ASCII.GetString(buffer, 0, counter);
                        stringbuilder.Append(tempString);
                    }
                }
                while (counter > 0);
                return stringbuilder.ToString();
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Erreur lors de la récupération des données Json : {0}", ex.Message));
            }
        }
    }
}