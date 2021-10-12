using System.Linq;

namespace MVC_Task_03.Models
{
    public class SampleData
    {
        public static void Initialize(MobileContext context)
        {
            if (context.Phones.Any()) return;
            
            context.Phones.AddRange(
                new Phone
                {
                    Name = "iPhone X",
                    Company = "Apple",
                    Price = 600
                },
                new Phone
                {
                    Name = "Samsung Galaxy S",
                    Company = "Samsung",
                    Price = 550
                },
                new Phone
                {
                    Name = "Pixel 3",
                    Company = "Google",
                    Price = 500
                }
            );
            context.SaveChanges();
        }
    }
}