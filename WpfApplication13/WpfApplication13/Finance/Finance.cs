using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication13
{
    public class Finance
    {
        public Finance() { 
            try{
            //connect to DB
            }
            catch(Exception ex){
                Logger tmpLogger = new Logger();
                tmpLogger.write(ex.ToString());
            }
        }
        public bool updateMonthlyReport(int month,int year,int id) {
            try
            {
                //update finance table
                return true;
            }
            catch (Exception ex) {
                Logger tempLogger = new Logger();
                tempLogger.write(ex.ToString());
                return false;
            }
        }
        public bool updateYearlyReport(int year, int id) {
            try
            {
                //update finance table
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