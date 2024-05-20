namespace Hireko.Model
{
    internal class Service
    {
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public string FreelancerName { get; set; }
        public string ServiceName { get; set; }
        public string Category { get; set; }
        public string Occupation { get; set; }
        public string ServiceDescription { get; set; }
        public string ExperienceLevel { get; set; }
        public string EducationalBackground { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public string ServiceStatus { get; set; }
    }

    internal static class CurrentService
    {
        public static int ServiceId { get; set; }

        public static int SellerId { get; set; }

        public static decimal ServiceFee { get; set; }

        public static decimal Price { get; set; }
    }
}
