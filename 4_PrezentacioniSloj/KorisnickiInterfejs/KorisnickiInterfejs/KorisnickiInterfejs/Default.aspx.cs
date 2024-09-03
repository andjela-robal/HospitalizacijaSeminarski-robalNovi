using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KorisnickiInterfejs
{
     public partial class _Default : Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               try
               {
                    if (Global.uspehKonekcije)
                    {
                         lblStatusKonekcije.Text = "USPESNO REALIZOVANA KONEKCIJA!";
                    }
                    else
                    {
                         lblStatusKonekcije.Text = "NEUSPESNA KONEKCIJA!";
                    }
               }
               catch (Exception ex)
               {
                    lblStatusKonekcije.Text = "GREŠKA: " + ex.Message;
               }
          }
     }
}