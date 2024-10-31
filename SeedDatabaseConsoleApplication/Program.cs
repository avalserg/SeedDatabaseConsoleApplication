using SeedDatabaseConsoleApplication.Models;
using System.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SeedDatabaseConsoleApplication
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string apiUrl = ConfigurationManager.AppSettings["ApiUrl"]!;

            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            await RunSeedingDataAsync(client, apiUrl);


        }
        static async Task RunSeedingDataAsync(HttpClient client, string apiUrl)
        {
            try
            {
                for (int i = 1; i <= 100; i++)
                {
                    var postfix = RandomExtension.RandomPostfixValue();

                    var patient = new Patient
                    {

                        Name = new Name()
                        {
                            Id = Guid.NewGuid(),
                            Use = RandomExtension.RandomUse(),
                            Family = $"PatientFamily{postfix}",
                            Given = new List<string>() { $"Name{postfix}", $"Patronymic{postfix}" }

                        },
                        BirthDate = new Random().GetRandomDate().ToUniversalTime(),
                        Gender = RandomExtension.RandomGender(),
                        Active = RandomExtension.RandomBooleanValue()
                    };

                    var response = await client.PostAsJsonAsync(
                        apiUrl, patient);

                    Console.WriteLine($"№{i} {response.StatusCode} {response.Headers.Location}");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception {e.Data}");
            }


        }
    }
}