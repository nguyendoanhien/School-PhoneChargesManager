using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Ghifile
    {
        private static Ghifile instance;
        public static Ghifile Instance
        {
            get
            {
                if (instance == null) instance = new Ghifile();
                return instance;
            }
            private set { Ghifile.instance = value; }
        }
        private Ghifile() { }
        
        public bool Write(string name, string text)
        {
            try
            {
                string txtFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
                string txtDir = Path.GetDirectoryName(txtFile);
                string fullPath = Path.Combine(txtDir, name);
                FileStream fs = new FileStream(fullPath, FileMode.Append);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(text);
                }
                    fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
