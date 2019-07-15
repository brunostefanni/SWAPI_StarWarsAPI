using System;
using System.Collections.Generic;

namespace SWAPI.Domain.Entities
{
    public class Starship : BaseModel
    {
        public string Name{get; set;}
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string CostInCredits { get; set; }
        public string Length { get; set; }
        public string MaxAtmospheringSpeed { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public string CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public string HyperdriveRating { get; set; }
        public string MGLT { get; set; }
        public string StarshipClass { get; set; }
        public IEnumerable<string> Pilots { get; private set; }        

        private enum CalculateToHours
        {
            hour = 1,
            hours = 1,
            day = 24,
            days = 24,
            week = 168,
            weeks = 168,
            month = 720,
            months = 720,
            year = 8640,
            years = 8640
        }

        public Starship()
        {
            Pilots = new List<string>();
            Films = new List<string>();
        }

        public string CalculateAutonomy(int distance, int consumablesInHours)
        {
            if (consumablesInHours == -1)
            {
                return "unknown";
            }
            bool success = int.TryParse(MGLT, out int intMGLT);
            if (success)
            {
                return ((distance / intMGLT) / consumablesInHours).ToString();
            }
            else
            {
                return "unknown";
            }
        }

        public int TransformConsumableToHours()
        {
            if (Consumables.ToLower().Equals("unknown"))
            {
                return -1;
            }

            var splitConsumable = Consumables.Split(' ');
            int valueInHours = TransformToHour(int.Parse(splitConsumable[0]), splitConsumable[1]);
            return valueInHours;
        }

        private int TransformToHour(int value, string type)
        {
            CalculateToHours typeEnum = (CalculateToHours)System.Enum.Parse(typeof(CalculateToHours), type);
            return ((int)(CalculateToHours)typeEnum) * value;
        }
    }
}