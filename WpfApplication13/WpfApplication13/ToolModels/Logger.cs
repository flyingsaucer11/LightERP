using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace WpfApplication13
{
    public class Logger
    {
        string errorMessage { get; set; }

        public Logger() { }
        public Logger(string errorMessage) {
            this.errorMessage = errorMessage;
            string[] errors = errorMessage.Split('\n');
            errorMessage = errors[0];
            errorMessage = DateTime.Now.ToString() + " " + errorMessage;
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            StreamWriter writer = new StreamWriter("logfile.txt",true,Encoding.ASCII);
            writer.WriteLine(errorMessage);
            writer.Close();
        }
        public void write(string str) {
            StreamWriter writer = new StreamWriter("logfile.txt");
            writer.WriteLine(str);
            writer.Close();
            //append with str
            //close log file
        }
    }
}
