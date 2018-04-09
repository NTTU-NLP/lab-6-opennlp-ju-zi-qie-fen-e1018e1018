using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using opennlp.tools.sentdetect;
using opennlp.tools.tokenize;

namespace Lab6
{
    class Program
    {
        public static void Main(string[] args)
        {
            DirectoryInfo folder = new DirectoryInfo(@"..\..\..\..\..\Dataset");
            foreach (var fname in folder.GetFiles())
            {
                String line = File.ReadAllText(fname.FullName);
                java.io.InputStream modelIn = new java.io.FileInputStream(@"..\..\..\..\..\en-sent.bin");
                SentenceModel smodel = new SentenceModel(modelIn);
                SentenceDetector detector = new SentenceDetectorME(smodel);
                string[] sents = detector.sentDetect(line);
                using (StreamWriter sw = new StreamWriter(fname.FullName.Replace(fname.FullName.Substring(fname.FullName.Length - 3), "rtf")))
                {
                    foreach (var sent in sents)
                    {
                        sw.WriteLine(sent);
                    }
                }
            }
        }
    }
}
