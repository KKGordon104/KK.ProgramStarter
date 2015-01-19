using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KK.ProgramStarter.Service
{
    class Configuration
    {
        public static List<ProgramModel> getProgramList()
        {
            try
            {
                List<ProgramModel> pmList = new List<ProgramModel>();

                string line;
                

                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader("PAPS.ini");
                while ((line = file.ReadLine()) != null)
                {
                    string[] splitLine = line.Split(';');

                    ProgramModel pm = new ProgramModel();
                    pm.name = splitLine[0];
                    pm.path = splitLine[1];
                    pm.parameter = splitLine[2];

                    pmList.Add(pm);
                    
                }

                file.Close();

                return pmList;
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public static void saveProgramList(List<ProgramModel> pmList)
        {

        }

    }
}
