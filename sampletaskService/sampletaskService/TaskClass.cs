using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

using System.Threading;

namespace sampletaskService
{
    public class AutoFun
    {
       
        public AutoFun()
        {           
        }

        public void TaskRun(string funType)
        {
            try
            {
                switch (funType)
                {
                    case "task1":                      
                        break;
                    case "task2":                      
                        break;                  
                }
            }
            catch
            {
            }
        }

       

    }
}
