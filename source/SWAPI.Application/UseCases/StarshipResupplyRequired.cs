using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SWAPI.Domain.Entities;
using SWAPI.Infrastructure.Services;

namespace SWAPI.Application.UseCases
{
    public class StarshipResupplyRequired
    {
        public async Task<IEnumerable<Starship>> LoadStarships(StarWarsApiService service)
        {
            var returnListStarships = new List<Starship>();
            var returnFromService = await service.GetStarships();

            while (returnFromService != null)
            {
                returnListStarships.AddRange(returnFromService.Results);

                if (!string.IsNullOrEmpty(returnFromService.Next))
                {
                    returnFromService = await service.GetStarships(returnFromService.Next);
                }
                else
                {
                    returnFromService = null;
                }
            }

            return returnListStarships;
        }

        public void CalculateResupplyRequired(IEnumerable<Starship> listOfStarships, int inputedDistanceMGLT, ConsoleVirtual console)
        {
            console.SetWriteLine("Collection of all the star ships and the total amount of stops required to make the inputed distance:");
            foreach (var starship in listOfStarships)
            {
                var consumablesInHours = starship.TransformConsumableToHours();
                var starshipAutonomy = starship.CalculateAutonomy(inputedDistanceMGLT, consumablesInHours);
                ShowMessageStarship(starship, starshipAutonomy);
            }
        }

        public int ReceiveInputedValue(ConsoleVirtual console)
        {
            var shouldValueValidated = false;
            var inputedValue = string.Empty;
            
            while (!shouldValueValidated)
            {
                console.SetWriteLine("Input the distance in mega lights (MGLT):");

                inputedValue = console.GetInputedValue();

                shouldValueValidated = ValidateInputedValue(inputedValue,console);
            }

            return int.Parse(inputedValue);
        }

        public bool ValidateInputedValue(string inputedValue, ConsoleVirtual console)
        {
            if (int.TryParse(inputedValue, out int validatedValue))
            {
                if (validatedValue < 0)
                {
                    console.SetWriteLine("The number must be greater than 0");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                console.SetWriteLine("Please only numeric, try again");
                return false;
            }
        }

        private void ShowMessageStarship(Starship starship, string autonomy)
        {
            Console.WriteLine($"{starship.Name}:{autonomy}");
        }
    }
}