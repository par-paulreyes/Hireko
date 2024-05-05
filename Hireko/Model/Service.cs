using System;

namespace Hireko.Database
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Username { get; set; }
        public string ServiceName { get; set; }
        public string Category { get; set; }
        public string Occupation { get; set; }
        public string ServiceDescription { get; set; }
        public string ExperienceLevel { get; set; }
        public string EducationalBackground { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }

        public int GetServiceId()
        {
            return ServiceId;
        }

        public string GetUsername()
        {
            return Username;
        }

        public string GetServiceName()
        {
            return ServiceName;
        }

        public string GetCategory()
        {
            return Category;
        }

        public string GetOccupation()
        {
            return Occupation;
        }

        public string GetServiceDescription()
        {
            return ServiceDescription;
        }

        public string GetExperienceLevel()
        {
            return ExperienceLevel;
        }

        public string GetEducationalBackground()
        {
            return EducationalBackground;
        }

        public decimal GetPrice()
        {
            return Price;
        }

        public decimal GetRating()
        {
            return Rating;
        }
    }
}
