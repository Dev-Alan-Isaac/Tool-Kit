using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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
    public partial class Menu_Name : UserControl
    {
        public Menu_Name()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Names.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Option", new JObject(
                             new JProperty("Alphabetically", true),
                             new JProperty("AlphabeticallyExtension", false)
                         )),
                         new JProperty("Additional", new JObject(
                             new JProperty("Case", true),
                             new JProperty("Special", true)
                         ))
                     );


                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Names.json", jsonContent.ToString());
                }

                break;
            }
        }
    }
}
