using Microsoft.Web.Administration;
using System;

namespace IISmanage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServerManager serverManager = new ServerManager();

            SiteCollection sites = serverManager.Sites;
            foreach (Site site in sites)
            {
                foreach (Application app in site.Applications)
                {
                    Console.WriteLine("Found application with the following path: {0}", app.Path);
                    Console.WriteLine("Virtual Directories:");
                    if (app.VirtualDirectories.Count > 0)
                    {
                        foreach (VirtualDirectory vdir in app.VirtualDirectories)
                        {
                            Console.WriteLine("  Virtual Directory: {0}", vdir.Path);
                            Console.WriteLine("   |-PhysicalPath = {0}", vdir.PhysicalPath);
                            Console.WriteLine("   |-LogonMethod  = {0}", vdir.LogonMethod);
                            Console.WriteLine("   +-UserName     = {0}\r\n", vdir.UserName);
                        }
                    }
                }
                /*
                ConfigurationElementCollection siteCollection = site.GetCollection();
                foreach (ConfigurationElement element in siteCollection)
                {
                    ConfigurationElementCollection virtualDirectoryElement = element.GetCollection();
                    foreach (ConfigurationElement element2 in virtualDirectoryElement)
                    {
                        var PPath  = element2.GetAttribute("physicalPath");
                        var path = element2.GetAttribute("path");
                        Console.WriteLine("Root Vdir {0} have phPath {1}", path.Value, PPath.Value);                        
                    }
                }
                */
            }

            Console.ReadLine();

            //Configuration config = serverManager.GetApplicationHostConfiguration();

            //ConfigurationSection applicationPoolsSection = config.GetSection("system.applicationHost/applicationPools");

            //ConfigurationElementCollection applicationPoolsCollection = applicationPoolsSection.GetCollection();

            //ConfigurationElement addElement = applicationPoolsCollection.CreateElement("add");
            //addElement["name"] = @"applicationPool1";

            //ConfigurationElement addElement = applicationPoolsCollection.GetCollection().SingleOrDefault(n => n.GetAttributeValue("name").ToString() == ".NET v4.5 Classic");
            //addElement["name"] = @"applicationPool1";

            //ConfigurationElement processModelElement = addElement.ChildElements["processModel"];
            //processModelElement["identityType"] = @"LocalSystem";
            //processModelElement["userName"] = @"";
            //processModelElement["password"] = @"";
            //applicationPoolsCollection.Add(addElement);

            //serverManager.CommitChanges();
        }
    }
}
