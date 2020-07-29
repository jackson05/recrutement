using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;


namespace recrutement
{
    public class connexion
    {
       internal string chaine =" Data Source=127.0.0.1;Initial Catalog=recrutement;Integrated Security=True";
     
        //bool isconnected()
        //    {
        //        try
        //        {
        //            SqlConnection m = new SqlConnection(chaine);
        //            m.Open();
        //            Console.WriteLine("connected");
        //            return true;

        //        }catch(Exception e)
        //        {
        //            Console.WriteLine("Probleme de connection\n"+e );
        //           return false;
        //        }
        
        //     }
        //insertion,suppression et modification des donnees

        internal int modifierData(string requet)
               {
                   SqlConnection m = new SqlConnection(chaine);
                  
                  try
                        {

                            m.Open();
                            SqlCommand n = new SqlCommand(requet, m);
                            return n.ExecuteNonQuery();


                        }
                         catch(Exception e)
                        {
                            Console.WriteLine("probleme de modification:\n "+e);
                            return -1;
                           
                        }
                    finally
                    {
                        m.Close();
                    }

              }

        //selection des donnees
        internal SqlDataReader selectData(String data) 
        {
            SqlDataReader dr = null;
            SqlConnection m= null;
            try
                {
                m = new SqlConnection(chaine);
                m.Open();
                SqlCommand n = new SqlCommand(data, m);
                dr = n.ExecuteReader();
                
                return dr;
                }
            catch(Exception e)
            {
                Console.WriteLine("probleme de modification:\n " + e);
                m.Close();
                
                return dr;
            }
            
        }


     
    }
}