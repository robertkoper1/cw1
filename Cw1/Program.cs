using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //int tmp0 = 1;
            //int? tmp1 = null; //? pozwala na nulla
            //double tmp2 = 2.0;
            //string tmp3 = "abc";
            //bool tmp4 = true;
            //var tmp5 = 1; //Automatycznie definiuje zmienną 

            //var tmp6 = "Ala ma kota";
            //var tmp7 = "i psa";

            //var path = @"C:\Users\s18645\Desktop\Cw1";
            //Console.WriteLine($"{tmp6} {tmp7} {tmp1 + tmp7}"); //$-konkatenacja

            //var newPerson = new Person { FirstName = "Robert" };
            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            var httpClient = new HttpClient();

            using (var HttpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {

                    // 2xx
                    if (response.IsSuccessStatusCode)
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();
                        var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                        var matches = regex.Matches(htmlContent);

                        foreach (var match in matches)
                        {
                            Console.WriteLine(match.ToString());
                        }
                    }
                }
            }
        }
    }
}
