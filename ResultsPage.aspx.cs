using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatMash
{
    public partial class ResultsPage : System.Web.UI.Page
    {
        images images = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Récupération des données en session
                if (Session["cats"] == null)
                {
                    images = BusinessLayer.BusinessLayer.GetCats();
                    Session.Add("cats", images);
                }
                else
                {
                    images = (images)Session["cats"];
                }

                // Affichage des résultats
                displayVoteResults(images, 5);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erreur dans la page de Résultats : {0}", ex.Message));
            }
        }

        /// <summary>
        /// Affichage des chats avec leur score (de 5 en 5)
        /// </summary>
        /// <param name="images"></param>
        protected void displayVoteResults(images images, int nbCatsInLine)
        {
            int compteur = 0;
            foreach (Entities.Image image in images.data)
            {
                if (compteur % nbCatsInLine == 0)
                {
                    if (compteur > 0)
                    {
                        this.Controls.Add(new LiteralControl("<br />")); 
                    }
                
                }
                Image img = new System.Web.UI.WebControls.Image();
                img.Width = 200;
                img.Height = 200;
                img.ImageUrl = image.url;
                img.AlternateText = image.id;
                img.BorderWidth = 1;
                this.Controls.Add(img);
                string txtpoints = " points";
                if (image.points < 2)
                {
                    txtpoints = " point";
                }
                this.Controls.Add(new LiteralControl( " " + image.points + txtpoints+ " "));
                compteur++;
            }
        }

        protected void BtnBackToVote_Click(object sender, EventArgs e)
        {
            Response.Redirect("VotePage.aspx");
        }
    }
}