using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTaskOrganizer
{
    class scripts
    {

        public string SearchInFile(string search)
        {
            try
            {
                using (var sr = new StreamReader("Config.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        if (line.Contains(search))
                            return sr.ReadLine();
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message);
            }
            return String.Empty;
        }

    }
}
