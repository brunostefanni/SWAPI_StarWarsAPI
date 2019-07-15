using System;
using System.Net.Http;
using System.Threading.Tasks;
using SWAPI.Application.UseCases;
using SWAPI.Infrastructure.Services;

namespace SWAPI.Application
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var httpClient = new HttpClient();
                var service = new StarWarsApiService(httpClient);
                var consoleVirtual = new ConsoleVirtual();
                var useCaseStarshipResupply = new StarshipResupplyRequired();

                var inputedDistanceMGLT = useCaseStarshipResupply.ReceiveInputedValue(consoleVirtual);

                Console.WriteLine("Please wait, loading...");

                var listOfStarships = await useCaseStarshipResupply.LoadStarships(service);
                useCaseStarshipResupply.CalculateResupplyRequired(listOfStarships, inputedDistanceMGLT, consoleVirtual);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }            
        }
    }

    public class ConsoleVirtual
    {
        public virtual string GetInputedValue()
        {
            return Console.ReadLine();
        }

        public virtual void SetWriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
