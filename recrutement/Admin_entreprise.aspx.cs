using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

using System.Globalization;
namespace recrutement
{
    public partial class Admin_entreprise : System.Web.UI.Page
     {
        
        connexion con=null;

        SqlDataReader rd=null;
        string datenow()
        {
            DateTime da=DateTime.Now;
            return da.ToString("dddd dd/MM/yyyy HH:mm:ss.ff", CultureInfo.CreateSpecificCulture("fr-FR"));
        }
        protected void Page_Load(object sender, EventArgs e)

        {
           charger_region();
           charger_servce();
            charger_poste();

        }
        //charger la choix des regions

        void charger_region()
        {

            if (!IsPostBack)
            {

                con = new connexion();

                //selection des regions
                DropDownListereg.Items.Clear();
                DropDownListereg.Items.Add("");
                rd = null;

                rd = con.selectData("select id_region,nom_region from region");


                while (rd.Read())
                {
                    DropDownListereg.Items.Add(rd.GetInt32(0) + " " + rd.GetString(1));

                }
            }
        }

        //je veux charger le service
        void charger_servce()
        {
            if (!IsPostBack)
                
            {
                con = new connexion();
                //selection du service
                DropDownListlisteservices.Items.Clear();
                rd = null;

                rd = con.selectData("select  id_service,nom_service from service");
                DropDownListlisteservices.Items.Add("");
                while (rd.Read())
                {

                    DropDownListlisteservices.Items.Add(rd.GetInt32(0) + " " + rd.GetString(1));

                }


            }

        }
        void charger_poste()
        {
            if(!IsPostBack)
            {
                con = new connexion();
                //selection du poste

                DropDownListlisteposte.Items.Clear();
                rd = null;
                rd = con.selectData("select id_poste,nom_poste from poste");
                DropDownListlisteposte.Items.Add("");
                while (rd.Read())
                {

                    DropDownListlisteposte.Items.Add(rd.GetInt32(0) + " " + rd.GetString(1));
                }
                rd.Close();

            }
        }
           

           
        
           protected void Button3_Click(object sender, EventArgs e)
          {
              con = new connexion();
              if (TextBox2.Text.Length > 0)
              {
                  if (con.modifierData("insert into region (nom_region) values ('" + TextBox2.Text + "') ") > 0)
                  {

                      Response.Redirect("Admin_entreprise.aspx"); 
                  }
                  else
                  {
                      Response.Write("<script language='Javascript'>alert('echec d enregistrement du région peut etre que région existe')</script>");
                  }  

              }


            
             
       
          }

          protected void Button4_Click(object sender, EventArgs e)
          {
              con = new connexion();
              if (TextBox3.Text.Length > 0)
              {
                  if (con.modifierData("insert into service (nom_service) values ('" + TextBox3.Text + "') ") > 0) 
                  {

                      Response.Redirect("Admin_entreprise.aspx");
               
                  }
                  else
                  {
                      Response.Write("<script language='Javascript'>alert('echec d enregistrement du service peut etre que le service existe!!')</script>");


                  }
              }
             
             
             
              
            
          }

          protected void Button5_Click(object sender, EventArgs e)
          {
              con = new connexion();
              if (TextBox4.Text.Length > 0)
              {
                  if (con.modifierData("insert into poste (nom_poste) values ('" + TextBox4.Text + "') ") > 0)
                  {
                      Response.Redirect("Admin_entreprise.aspx");

                  }
                  else
                  {
                      Response.Write("<script language='Javascript'>alert('echec d enregistrement du poste le poste existe deja!!')</script>");

                  } 
                  
              }

          
              
            
          }

        //id d'un entreprise dans drop dowlist d'entreprise
          protected void DropDownListeentre_SelectedIndexChanged(object sender, EventArgs e)
          {
         
          }

        //insersion dans association au region

          protected void Button1_Click(object sender, EventArgs e)
          {
            
              string[] region = DropDownListereg.SelectedItem.ToString().Split(' ');
              string[] service = DropDownListlisteservices.SelectedItem.ToString().Split(' ');
              string[] poste = DropDownListlisteposte.SelectedItem.ToString().Split(' ');
             
              
              //, CultureInfo.CreateSpecificCulture("fr-FR"));
              if ( region[0].Length > 0 && service[0].Length > 0 && poste[0].Length > 0)
              {
            
                  con = new connexion();
                 if (con.modifierData("insert into association_au_region(id_region,id_service,id_poste,date_associe) values('" + Int32.Parse(region[0]) + "','" + Int32.Parse(service[0]) + "','" +Int32.Parse( poste[0]) + "','" + datenow()+ "')")> 0)
                  {

                      Response.Redirect("Admin_entreprise.aspx");
                     
                 }
                 else
                 {
                     Response.Write("<script language='Javascript'>alert('echec d enregistrement veuillez selectionner dans les choix')</script>");


                 }
                 
              }

               else
              {
                 Response.Write("<script language='Javascript'>alert('echec d enregistrement veuillez selectionner dans les choix du drop down list')</script>");
                  
             }
            
          }
        //id d'une region
          protected void DropDownListereg_SelectedIndexChanged(object sender, EventArgs e)
          {
           
          
          }
        //ID service

          protected void DropDownListlisteservices_SelectedIndexChanged(object sender, EventArgs e)
          {
            
          }

          protected void DropDownListlisteposte_SelectedIndexChanged(object sender, EventArgs e)
          {
        
          }

        //cette fonction sert a remplir le greedview
    
       
    }

}