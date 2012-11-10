using System;
using System.Reflection;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories;
using GDNET.Utils;

namespace GDNET.DataGeneration.Helpers
{
    internal static class SystemAssistant
    {
        public static void GenerateUsers()
        {
            Console.WriteLine();
            Console.Write(MethodBase.GetCurrentMethod().Name + "...");
            Random random = new Random();

            for (int index = 0; index < 10; index++)
            {
                var email = RandomAssistant.GenerateEmailAddress(random);

                if (DomainRepositories.User.FindByEmail(email) == null)
                {
                    var user = User.Factory.Create(email, "@a1b2c3$", Convert.ToBoolean(random.Next(0, 1)));
                    DomainRepositories.User.Save(user);
                }
            }

            Console.Write("done!");
        }
    }
}
