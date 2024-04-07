using System;

namespace Basic_Elevator.Elevator
{
    public static class NameGenerator
    {
        static Random random = new Random();
        public static string GetName()
        {
            string[] names = {"John", "Dave", "Sam", "Jack", "Tom", "Richard", "Laura", "Emily", "Sophia",
                              "Chloe", "Oliver", "Harry", "George", "Noah", "Leo", "Oscar", "Grace", "Ella",
                              "Eva", "Poppy"};
            string[] surnames = {"Johnson", "Smith", "Brown", "Williams", "Jones", "Miller", "Davis", "Garcia",
                                 "Rodriguez", "Wilson", "Anderson", "Martinez", "Taylor", "Moore", "Jackson",
                                 "Martin", "Lee", "Perez", "Thompson", "White"};



            int randomNameIndex = random.Next(names.Length);
            int randomSurnameIndex = random.Next(surnames.Length);

            return names[randomNameIndex] + " " + surnames[randomSurnameIndex];
        }
    }
}
