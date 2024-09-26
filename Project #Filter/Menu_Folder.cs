using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Project__Filter
{
    public partial class Menu_Folder : UserControl
    {
        public Menu_Folder()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Folder.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                        new JProperty("Option", new JObject(
                            new JProperty("Alphabetical", true),
                            new JProperty("Depth", true)
                        ))
                     );


                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Folder.json", jsonContent.ToString());
                }



                break;
            }
        }
    }
}
