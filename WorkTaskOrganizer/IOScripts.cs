using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace WorkTaskOrganizer
{
    public class IOScripts
    {
        private const string defaultConfigFileName = "TempConfigName.txt";
        private const string defaultTaskTemplateFileName = "TempTaskTemplateName.xml";

        public static string SearchInFile(string search, string fileName = defaultConfigFileName)
        {
            try
            {
                using (var sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        if (line.Replace(":","") == search)
                            return sr.ReadLine();
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message);
            }
            return String.Empty;
        }

        public static void CheckExistsConfigFile(string fileName = defaultConfigFileName)
        {
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, "Workspace path:\n\nDefault explorer:\nexplorer.exe");
                MessageBox.Show("Created config file, please edit this.");
            }
        }

        public static void SerializeTaskTemplate(List<TaskTemplate> tasks, string fileName = defaultTaskTemplateFileName)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<TaskTemplate>));
            StreamWriter myWriter = new StreamWriter(fileName);
            mySerializer.Serialize(myWriter, tasks);
            myWriter.Close();
        }

        public static List<TaskTemplate> DeserializeTaskTemplate(string fileName = defaultTaskTemplateFileName)
        {
            List<TaskTemplate> tasks = new List<TaskTemplate>();
            try
            {
                var mySerializer = new XmlSerializer(typeof(List<TaskTemplate>));
                var myFileStream = new FileStream("TempName.xml", FileMode.Open);
                tasks = (List<TaskTemplate>)mySerializer.Deserialize(myFileStream);
                myFileStream.Close();
                return tasks;
            }
            catch
            {                
                MessageBox.Show($"Created xaml file: {fileName}");
                IOScripts.SerializeTaskTemplate(new List<TaskTemplate>(), fileName);
            }
            return new List<TaskTemplate>();
        }



    }
}
