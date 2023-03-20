using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISmanage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServerManager serverManager = new ServerManager();
            Configuration config = serverManager.GetApplicationHostConfiguration();

            ConfigurationSection applicationPoolsSection = config.GetSection("system.applicationHost/applicationPools");

            ConfigurationElementCollection applicationPoolsCollection = applicationPoolsSection.GetCollection();

            //ConfigurationElement addElement = applicationPoolsCollection.CreateElement("add");
            //addElement["name"] = @"applicationPool1";

            ConfigurationElement addElement = applicationPoolsCollection.GetCollection().SingleOrDefault(n => n.GetAttributeValue("name").ToString() == ".NET v4.5 Classic");
            //addElement["name"] = @"applicationPool1";

            ConfigurationElement processModelElement = addElement.ChildElements["processModel"];
            processModelElement["identityType"] = @"LocalSystem";
            processModelElement["userName"] = @"";
            processModelElement["password"] = @"";
            //applicationPoolsCollection.Add(addElement);

            serverManager.CommitChanges();
        }
    }
}
