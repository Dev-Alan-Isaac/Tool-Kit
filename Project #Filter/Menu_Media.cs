using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Project__Filter
{
    public partial class Menu_Media : UserControl
    {
        public Menu_Media()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Media.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Option", new JObject(
                             new JProperty("Duration", true),
                             new JProperty("Resolution ", false),
                             new JProperty("Frame_Rate", false),
                             new JProperty("Codec", false),
                             new JProperty("Audio", false),
                             new JProperty("Aspect", false),
                             new JProperty("BitDepth", false)
                         ))
                    );


                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Media.json", jsonContent.ToString());
                }

                break;
            }
        }

    }
}
