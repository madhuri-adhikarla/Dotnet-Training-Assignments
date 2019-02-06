using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            XDocument xmlDoc = XDocument.Load(@"C:\Users\madhuri.a\Documents\generatedMenu.xml");
            XElement ele = xmlDoc.Root;
            // Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            List<string> countries = new List<string>();
            var cnt = from c in ele.Elements()
                      select c;
            foreach (var country in cnt)
            {

                var dataNodes = from s in ele.Elements()
                                where s.Name == country.Name
                                select s.Element("products").Element("bussinessunits");

                DataClasses1DataContext ld = new DataClasses1DataContext();
                product pd = null;
                foreach (var node in dataNodes.Elements<XElement>())
                {
                    string bkey = node.Attribute("id").Value;


                    foreach (var item in node.Elements())
                    {
                        pd = new product();
                        pd.businessunit_id = bkey;
                        pd.product_id = item.Attribute("id").Value;
                        pd.product_name = item.Attribute("name").Value;
                        pd.product_url = item.Attribute("url").Value;
                        ld.products.InsertOnSubmit(pd);
                        ld.SubmitChanges();

                    }

                }




            }



           

            Console.ReadKey(); 
        }
    }
}
