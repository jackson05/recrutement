using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;


namespace recrutement.employer
{

    public partial class add_employeeUI : System.Web.UI.Page
    {

        connexion con = null;


        string datenow()
        {
            DateTime da = DateTime.Now;
            return da.ToString("dddd dd/MM/yyyy HH:mm:ss.ff", CultureInfo.CreateSpecificCulture("fr-FR"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               affiche_gridvieuw();
            }
        }
        


        //affiche les affectation du dropdown list apres avoir clique
        protected void Button1_Click(object sender, EventArgs e)
        {
            affiche_dropdownListe();
            voir_image.Enabled = false;
            detaille.Enabled = false;
        }

        //fonction de recuperation des elements d'affichage et affichage dans le dropdownlist
        void affiche_dropdownListe()
        {
            con = new connexion();
            SqlDataReader rd = con.selectData("SELECT association_au_region.id_ass, region.nom_region, service.nom_service, poste.nom_poste FROM association_au_region INNER JOIN region ON association_au_region.id_region = region.id_region INNER JOIN service ON association_au_region.id_service = service.id_service INNER JOIN poste ON association_au_region.id_poste = poste.id_poste");
            DropDownListAssoc.Items.Clear();
            
            DropDownListAssoc.Items.Add("");
            
            while (rd.Read())
            {
                DropDownListAssoc.Items.Add(rd.GetInt32(0) + "          " + rd.GetString(1) + "       " + rd.GetString(2) + "       " + rd.GetString(3));
           
            }
        }

        //j'affiche dans le grid vieuw
        void affiche_gridvieuw()
        {
            DataTable dtbl = new DataTable();
            con = new connexion();
            using (SqlConnection sqlcon = new SqlConnection(con.chaine))
            {
                sqlcon.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT id_employer,matricule, nom, prenom, profiles, date_naissance, lieu_naissance, mail, tel FROM employer", sqlcon);
                adapt.Fill(dtbl);

            }
            if (dtbl.Rows.Count > 0)
            {
                GridViewemployer.DataSource = dtbl;
                GridViewemployer.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                GridViewemployer.DataSource = dtbl;
                GridViewemployer.DataBind();
                GridViewemployer.Rows[0].Cells.Clear();
                GridViewemployer.Rows[0].Cells.Add(new TableCell());
                GridViewemployer.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                GridViewemployer.Rows[0].Cells[0].Text = "Aucun employer trouve";
                GridViewemployer.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void GridViewemployer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("ajouternouveau"))
            {
                con=new connexion();
                using (SqlConnection sqlcon = new SqlConnection(con.chaine))
                {
                    int a = 0;
                    try
                    {
                        string[] associat = DropDownListAssoc.SelectedItem.ToString().Split(' ');
                        a = Int32.Parse(associat[0]);
                    }catch(Exception ex)
                    {
                        labsucces.Text = "";
                        error.Text = "OOUPS!!!!! Aucune affectation trouve  "+ex;
                    }
                    if (a > 0)
                    {
                        
                        sqlcon.Open();
                        string query = "insert into employer (id_ass,matricule,nom,prenom,profiles,date_naissance,lieu_naissance,mail,tel,date_enreg) values(@id_ass,@matricule,@nom,@prenom,@profiles,@date_naissance,@lieu_naissance,@mail,@tel,@date_enreg)";
                        SqlCommand com = new SqlCommand(query, sqlcon);
                        com.Parameters.AddWithValue("@id_ass", a);
                        com.Parameters.AddWithValue("@matricule", (GridViewemployer.FooterRow.FindControl("textmatriculefooter") as TextBox).Text);
                        com.Parameters.AddWithValue("@nom", (GridViewemployer.FooterRow.FindControl("textnomfooter") as TextBox).Text.ToUpper());
                        com.Parameters.AddWithValue("@prenom", (GridViewemployer.FooterRow.FindControl("textprenomfooter") as TextBox).Text);
                        com.Parameters.AddWithValue("@profiles", (GridViewemployer.FooterRow.FindControl("textprofilefooter") as TextBox).Text);
                        com.Parameters.AddWithValue("@date_naissance", (GridViewemployer.FooterRow.FindControl("textnaissancefooter") as TextBox).Text);
                        com.Parameters.AddWithValue("@lieu_naissance", (GridViewemployer.FooterRow.FindControl("textlieunaissancefooter") as TextBox).Text);
                        com.Parameters.AddWithValue("@mail", (GridViewemployer.FooterRow.FindControl("textmailfooter") as TextBox).Text);
                        com.Parameters.AddWithValue("@tel", (GridViewemployer.FooterRow.FindControl("texttelephonefooter") as TextBox).Text);
                        com.Parameters.AddWithValue("@date_enreg", datenow());
                        if (com.ExecuteNonQuery() > 0)
                        {
                            //Response.Redirect("add_employeeUI.aspx");
                            affiche_gridvieuw();
                            labsucces.Text = "Nouveau element a ete ajoute";
                            error.Text = "";
                            sqlcon.Close();
                        }
                        else
                        {
                            error.Text = "Echec d'ajout du nouveau element";
                            labsucces.Text = "";
                            sqlcon.Close();
                        }

                    }
                    else
                  {
                      labsucces.Text = "";
                      error.Text = "OOUPS!!!!! Aucune affectation trouve";
                 }
                }
                
            }
  

        }

        protected void GridViewemployer_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridViewemployer.EditIndex = e.NewEditIndex;
            
             affiche_gridvieuw();
           
          
        }

        protected void GridViewemployer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            GridViewemployer.EditIndex = -1;
            affiche_gridvieuw();
            
        }


        //returne une image sous forme byte
    

        protected void GridViewemployer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            

            con = new connexion();
            using (SqlConnection sqlcon = new SqlConnection(con.chaine))
            {
                int a = 0;
                try
                {
                    string[] associat = DropDownListAssoc.SelectedItem.ToString().Split(' ');
                    a = Int32.Parse(associat[0]);
                }
                catch (Exception ex)
                {
                    labsucces.Text = "";
                    error.Text = "OOUPS!!!!! Aucune affectation trouve  " + ex;

                }
                if (a > 0)
                {
                    Byte[] byt;
                   
                    sqlcon.Open();
                    string query = "update employer set id_ass=@id_ass,matricule=@matricule,nom=@nom,prenom=@prenom,profiles=@profiles,photo_empl=@photo_empl,date_naissance= @date_naissance,lieu_naissance=@lieu_naissance,mail=@mail,tel=@tel where id_employer=@id";
                    SqlCommand com = new SqlCommand(query, sqlcon);
                    com.Parameters.AddWithValue("@id_ass", a);
                    com.Parameters.AddWithValue("@matricule", (GridViewemployer.Rows[e.RowIndex].FindControl("textmatricule") as TextBox).Text);
                    com.Parameters.AddWithValue("@nom", (GridViewemployer.Rows[e.RowIndex].FindControl("textnom") as TextBox).Text.ToUpper());
                    com.Parameters.AddWithValue("@prenom", (GridViewemployer.Rows[e.RowIndex].FindControl("textprenom") as TextBox).Text);
                    com.Parameters.AddWithValue("@profiles", (GridViewemployer.Rows[e.RowIndex].FindControl("textprofile") as TextBox).Text);
                   
                    //je doit avoir une image sous format png,jpg,jpeg,gif ou bitmap  avant de l'envoyer dans un SGBD
                        if (FileUpload1.HasFile)
                        {
                            HttpPostedFile posted = FileUpload1.PostedFile;
                            string nom_fichier = Path.GetFileName(posted.FileName);
                            string extension_fichier = Path.GetExtension(nom_fichier);
                            int taille_fichier = posted.ContentLength;
                            if (extension_fichier.ToLower() == ".png" || extension_fichier.ToLower() == ".jpg" || extension_fichier.ToLower() == "gif"
                                || extension_fichier.ToLower() == "bmp" || extension_fichier.ToLower() == "jpeg")
                            {
                                Stream stream = posted.InputStream;
                                BinaryReader read_binary = new BinaryReader(stream);
                                byt = read_binary.ReadBytes((int)stream.Length);
                               
                                com.Parameters.AddWithValue("@photo_empl", byt);
                           
                            }
                            else
                            {
                             
                               com.Parameters.AddWithValue("@photo_empl", null);
                         
                            }
                        }
                    com.Parameters.AddWithValue("@date_naissance", (GridViewemployer.Rows[e.RowIndex].FindControl("textnaissance") as TextBox).Text);
                    com.Parameters.AddWithValue("@lieu_naissance", (GridViewemployer.Rows[e.RowIndex].FindControl("textlieunaissance") as TextBox).Text);
                    com.Parameters.AddWithValue("@mail", (GridViewemployer.Rows[e.RowIndex].FindControl("textmail") as TextBox).Text);
                    com.Parameters.AddWithValue("@tel", (GridViewemployer.Rows[e.RowIndex].FindControl("texttelephone") as TextBox).Text);
                    com.Parameters.AddWithValue("@id", Convert.ToInt32(GridViewemployer.DataKeys[e.RowIndex].Value.ToString()));
                    GridViewemployer.EditIndex = -1;
                    if (com.ExecuteNonQuery() > 0)
                    {
                        //Response.Redirect("add_employeeUI.aspx");
                        affiche_gridvieuw();
                        labsucces.Text = "Un element a ete modifie";
                        error.Text = "";
                        sqlcon.Close();
                    }
                    else
                    {
                        error.Text = "Echec de modification de l'element";
                        labsucces.Text = "";
                        sqlcon.Close();
                    }

                }
                else
                {
                    labsucces.Text = "";
                    error.Text = "OOUPS!!!!! Aucune affectation trouve";
                }
            }
            

        }

        protected void GridViewemployer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            con = new connexion();
            using (SqlConnection sqlcon = new SqlConnection(con.chaine))
            {
               

                    sqlcon.Open();
                    string query = "Delete from employer where id_employer=@id";
                    SqlCommand com = new SqlCommand(query, sqlcon);
                  
                    com.Parameters.AddWithValue("@id", Convert.ToInt32(GridViewemployer.DataKeys[e.RowIndex].Value.ToString()));
                    GridViewemployer.EditIndex = -1;
                    if (com.ExecuteNonQuery() > 0)
                    {
                        //Response.Redirect("add_employeeUI.aspx");
                        affiche_gridvieuw();
                        labsucces.Text = "Un element a ete supprime";
                        error.Text = "";
                        sqlcon.Close();
                    }
                    else
                    {
                        error.Text = "Echec de la suppression de l'element";
                        labsucces.Text = "";
                        sqlcon.Close();
                    }

                }

            }
        //display image from  database
        private void displayImage(string requete)
        {
          
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //con = new connexion();
            //SqlDataReader rd = con.selectData("select photo_empl where from employer where(id_empl='" + Convert.ToInt32(GridViewemployer.DataKeys[e.RowIndex].Value.ToString()) + "')");
            //if (rd.HasRows)
            //{
            //    while (rd.Read())
            //    {
            //        byte[] imagedata = ((byte[])rd["photo_empl"]);
            //        string img = Convert.ToBase64String(imagedata, 0, imagedata.Length);
            //        Image1.ImageUrl = "data:photo_empl/png;base64," + img;
            //    }

            //}
        }

        protected void Buttonvoir_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                HttpPostedFile posted = FileUpload1.PostedFile;
                string nom_fichier = Path.GetFileName(posted.FileName);
                string extension_fichier = Path.GetExtension(nom_fichier);
                
                Image1.ImageUrl = nom_fichier;
                error.Text = "";
            }
            else
            {
                labsucces.Text = "";
                error.Text = "Image not found";
            }

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            con = new connexion();
            SqlDataReader rd = con.selectData("select matricule,nom,prenom from employer");
            if (rd.HasRows)
            {
                DropDownListAssoc.Items.Clear();
                DropDownListAssoc.Items.Add("");
                while (rd.Read())
                {
                    DropDownListAssoc.Items.Add(rd.GetString(0) + "     " + rd.GetString(1) + "     " + rd.GetString(2));

                }
                voir_image.Enabled = true;
                detaille.Enabled = true;
            }
            else
            {
                labsucces.Text = "";
                error.Text = "Acun employer trouve";

            }
        }



        //on click pour recuperer la photo d'un employer
        protected void voir_image_Click(object sender, ImageClickEventArgs e)
        {
            string[] matricule_emp = null;
            try
            {
                matricule_emp = DropDownListAssoc.SelectedItem.ToString().Split(' ');
                if (matricule_emp[0].Length > 0)
                {
                    con = new connexion();
                    SqlDataReader rd = con.selectData("select photo_empl from employer where matricule='" + matricule_emp[0] + "'");
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            byte[] imag = (byte[])rd["photo_empl"];
                            string myImage = Convert.ToBase64String(imag, 0, imag.Length);
                            Image1.ImageUrl = "data:photo_empl/png;base64," + myImage;
                            Label_valide.Text = "la photo a ete trouve";
                            label_erreur.Text = "";
                        }
                    }
                    else
                    {

                       label_erreur.Text = "Image non trouve dans le stockage";
                        Label_valide.Text = "";
                    }
                }
                else
                {
                    label_erreur.Text = "selectionnez d'abord un employer dans la liste";
                    Label_valide.Text = "";
                }

            }
            catch (Exception ex)
            {
                label_erreur.Text = "Image non trouve dans le stockage";
                Label_valide.Text= "";
            }

        }

        protected void detaille_Click(object sender, ImageClickEventArgs e)
        {
            string[] matric = null;
            try
            {
                matric=DropDownListAssoc.SelectedItem.ToString().Split(' ');
                if (matric[0].Length > 0)
                {
                    Session["matricul"] = matric;
                    
                }
                else
                {
                    label_erreur.Text = "selectionnez d'abord l'employer";
                    Label_valide.Text = "";
                }
            }
            catch (Exception ex)
            {
            }
           
        }

        

    }
}