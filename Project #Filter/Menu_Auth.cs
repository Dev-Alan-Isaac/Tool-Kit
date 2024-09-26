using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project__Filter
{
    public partial class Menu_Auth : UserControl
    {
        public Menu_Auth()
        {
            InitializeComponent();
        }

        private void Menu_Auth_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Permissions.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Option", new JObject(
                             new JProperty("Readable", true),
                             new JProperty("Writable", false),
                             new JProperty("Executable", false)
                         ))
                     );

                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Permissions.json", jsonContent.ToString());
                }


                break;
            }
        }
    }
}
