using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace MyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> mappings = new Dictionary<int, int>();
            mappings.Add(2000, 22);
            mappings.Add(3000, 33);
            string x = @"<Conditions>
  <Condition  FormInputID='boolean1' ValueType='B' Value='false' Operator='=' />
  <Condition VersionStepID='2000' FormInputID='boolean1' ValueType='SSSS' Value='false' Operator='=' />
  <Condition VersionStepID='3000' FormInputID='boolean1' ValueType='B' Value='false' Operator='=' />
  <Condition  FormInputID='boolean1' ValueType='B' Value='false' Operator='=' />
</Conditions>";
            string y = "<Conditions />";
            XElement r = XElement.Parse(y);
            IEnumerable<XElement> a =
    from el in r.Elements("Condition")
    where el.Attribute("VersionStepID")!= null
    select el;

            foreach (XElement el in a) {
            Console.WriteLine(el.Attribute("VersionStepID"));
                if (mappings.ContainsKey((int)el.Attribute("VersionStepID")))
                {
                    el.Attribute("VersionStepID").SetValue(mappings[(int)el.Attribute("VersionStepID")]);
                }
                
         
            }
           
            Console.WriteLine(r.ToString());


            XElement root = XElement.Load("purchase.xml");

            IEnumerable<XElement> address =
                from el in root.Elements("Address")
                where (string)el.Attribute("Type") == "Billing"
                select el;
            foreach (XElement el in address)
                Console.WriteLine(el);

            Console.ReadLine();
        }
    }
}
