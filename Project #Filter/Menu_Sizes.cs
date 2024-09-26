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
    public partial class Menu_Sizes : UserControl
    {
        public Menu_Sizes()
        {
            InitializeComponent();
        }

        private void Menu_Sizes_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Size.json"))
                {
                    var jsonContent = new JObject(
                         new JProperty("Size", new JObject(
                             new JProperty("Small", "100", "MB"),
                             new JProperty("Medium", "100", "MB", "1", "GB"),
                             new JProperty("Large", "1", "GB", "10", "GB"),
                             new JProperty("Very Large", "10", "GB")
                         ))
                    );

                    File.WriteAllText("Config_Size.json", jsonContent.ToString());
                }

              
                break;
            }
        }

        private void button_Saved_Click(object sender, EventArgs e)
        {

        }
     
    }
}
