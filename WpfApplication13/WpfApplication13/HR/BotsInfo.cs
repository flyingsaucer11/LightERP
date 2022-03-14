using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication13
{
    public class BotsInfo
    {
        public BotsInfo() { 
            //connect to DB
        }
        public bool addNewBot(int id, string name, string catagory) {
            try
            {
                //update BotsInfo table
                return true;
            }
            catch (Exception ex) {
                Logger tempLogger = new Logger();
                tempLogger.write(ex.ToString());
                return false;
            }
        }
        public bool updateBotAmount(int id, int amount) {
            try
            {
                //update BotsInfo table
                return true;
            }
            catch (Exception ex) {
                Logger tempLogger = new Logger();
                tempLogger.write(ex.ToString());
                return false;
            }
        }
    }
}