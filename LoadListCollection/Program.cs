using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadListCollection
{
    class Program
    {
        static void Main(string[] args)
        {

            var msgList = CreateCollection(typeof(IMessageType));

            foreach (var item in msgList)
            {
                if (item.IsClass)
                {
                    IMessageType obj =(IMessageType) Activator.CreateInstance(item);

                    Console.WriteLine(obj.ShowName("dynamic"));
                }
            }

          

            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }

        private static IEnumerable<Type> CreateCollection(Type itemType)
        {

            
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => itemType.IsAssignableFrom(p));

            return types;
        }
    }


    public interface IMessageType {

        string ShowName(string name);
    }


    public class EmailMessage : IMessageType
    {

        public string ShowName(string msg) {

            return "Email " + msg;
        }
    }


    public class SmsMessage : IMessageType
    {

        public string ShowName(string msg)
        {

            return "SMS " + msg;  
        }
    }

}
