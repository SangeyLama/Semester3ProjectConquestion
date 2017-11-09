using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataLayer.DataLayer.Model;

using LogicLayer;
using DataLayer;

namespace WCFConquestion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ConquestionService : IConquestionService
    {

        public void CreatePlayer(string name)
        {
            PlayerController ctr = new PlayerController();
            Player player = ctr.CreatePlayer(name);   
        }
    }
}
