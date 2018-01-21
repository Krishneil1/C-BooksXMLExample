using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BooksXMLEg
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(catalog));
            string[] Documents = Directory.GetFiles("../../Data/");
            string DocumentPath = Documents[0];
            var total = 0.0;
            double min= 1000.00, max=0.0;
            DateTime booksPublishedIn2001 = new DateTime(2001, 1, 1);
            DateTime booksPublishedIn2000 = new DateTime(2000, 12, 31);
            int numbooksPublishedIn2000 = 0 ;
            int numbooksPublishedIn2001 = 0;
            try
            {
                using (var filestream = new FileStream(DocumentPath, FileMode.Open))
                {
                    catalog result = (catalog)serializer.Deserialize(filestream);
                    if(result.books.Count > 0)
                    {
                        for (var index = 0; index < result.books.Count; index++)
                        {
                            total = (result.books[index].price)+total;
                            if (result.books[index].price < min)
                            {
                                min = result.books[index].price;
                            }
                            if (result.books[index].price > max)
                            {
                                max = result.books[index].price;
                            }
                            if(result.books[index].publish_date < (booksPublishedIn2001))
                            {
                                numbooksPublishedIn2000++;
                            }
                            if (result.books[index].publish_date > (booksPublishedIn2000))
                            {
                                numbooksPublishedIn2001++;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception file not found", e);
            }
            Console.WriteLine("Total ${0}",total);
            Console.WriteLine("Min ${0}", min);
            Console.WriteLine("Max ${0}", max);
            Console.WriteLine("Books published in 2000  :{0}", numbooksPublishedIn2000);
            Console.WriteLine("Books published in 2001  :{0}", numbooksPublishedIn2001);
            Console.WriteLine("Enter to Exit!");
            Console.ReadKey();
        }
    }
}
