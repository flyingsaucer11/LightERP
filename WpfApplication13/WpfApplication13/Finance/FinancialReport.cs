using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication13
{
    public class FinancialReport
    {
        public FinancialReport() { 
            //connect to DB
        }
        public bool addReport(int id, int month, int year, string catagory, string type, float amount) {
            try
            {
                //update FinancialReport table
                return true;
            }
            catch (Exception ex) {
                Logger tempLogger = new Logger();
                tempLogger.write(ex.ToString());
                return false;
            }
        }
        public bool editReport(int id, int month, int year, string catagory, string type, float amount)
        {
            try
            {
                //update FinancialReport table
                return true;
            }
            catch (Exception ex)
            {
                Logger tempLogger = new Logger();
                tempLogger.write(ex.ToString());
                return false;
            }
        }
        
    }
}
