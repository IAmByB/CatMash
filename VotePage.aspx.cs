using System;
using System.Linq;
using System.Web.UI;

namespace CatMash
{
    public partial class VotePage : System.Web.UI.Page
    {
        images images = null;
        int dimension = 300;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["cats"] == null)
                {
                    images = BusinessLayer.BusinessLayer.GetCats();
                    Session.Add("cats", images);
                }
                else
                {
                    images = (images)Session["cats"];
                }

                if (!Page.IsPostBack)
                {
                    updateCats(dimension);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erreur dans la page de Vote : {0}", ex.Message));
            }
        }

        protected void RBVote1_CheckedChanged(object sender, EventArgs e)
        {
            int compteur = 0;
            foreach (Entities.Image image in images.data)
            {
                if (image.url == Image1.ImageUrl)
                {
                    image.points++;
                    break;
                }
                compteur++;
            }
            Session["cats"] =images;
            updateCats(dimension);
        }

        protected void RBVote2_CheckedChanged(object sender, EventArgs e)
        {
            int compteur = 0;
            foreach (Entities.Image image in images.data)
            {
                if (image.url == Image2.ImageUrl)
                {
                    image.points++;
                    break;
                }
                compteur++;
            }
            Session["cats"] = images;
            updateCats(dimension);
        }


        /// <summary>
        /// Mise à jour de l'affichage des chats
        /// </summary>
        private void updateCats(int dimension)
        {
            Random random = new Random();
            int rnd1 = random.Next(0, images.data.Count()-1);
            int rnd2 = random.Next(0, images.data.Count()-1);
            Image1.Width = dimension;
            Image1.Height = dimension;
            Image2.Width = dimension;
            Image2.Height = dimension;
            Image1.ImageUrl = images.data[rnd1].url;
            Image1.AlternateText = images.data[rnd1].points.ToString() + " points";
            Image2.ImageUrl = images.data[rnd2].url;
            Image2.AlternateText = images.data[rnd2].points.ToString() + " points";
            RBVote1.Checked = false;
            RBVote2.Checked = false;
        }

        protected void BtnToResults_Click(object sender, EventArgs e)
        {
            Session.Add("cats", images);
            Response.Redirect("ResultsPage.aspx");
        }

        //protected void BtnVote_Click(object sender, EventArgs e)
        //{
        //    updateCats(dimension);
        //}
    }
}
