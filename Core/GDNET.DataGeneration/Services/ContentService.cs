using System;
using System.Reflection;
using GDNET.Base.Utils;
using GDNET.CastleIntergration.Utils;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Entities.System.ReferenceData;
using GDNET.Domain.Repositories;
using GDNET.Domain.Services;
using GreatApp.Domain.Entities;
using GreatApp.Domain.Repositories;

namespace GDNET.DataGeneration.Services
{
    internal class ContentService : IBusinessService
    {
        private static readonly IContentItemRepository _contentItemRepository = IocAssistant.Resolve<IContentItemRepository>();

        public static void GenerateContentItems()
        {
            Console.WriteLine();
            Console.Write(MethodBase.GetCurrentMethod().Name + "...");
            Random aRandom = new Random();
            Catalog catalogLanguage = DomainRepositories.Catalog.FindByCode(SystemCatalogs.Languages);

            int nbContentItems = aRandom.Next(10, 20);
            for (int index = 0; index < nbContentItems; index++)
            {
                int length = aRandom.Next(15, 50);
                string name = RandomAssistant.GenerateASentence(aRandom, length);
                var ci = ContentItem.Factory.Create(name, true);

                int languageIndex = aRandom.Next(0, catalogLanguage.Lines.Count - 1);
                ci.Language = catalogLanguage.Lines[languageIndex];

                ci.Description = RandomAssistant.GenerateAParagraph(aRandom);

                _contentItemRepository.Save(ci);

                for (int partCounter = 0; partCounter < 10; partCounter++)
                {
                    int partLength = aRandom.Next(15, 50);
                    string partName = RandomAssistant.GenerateASentence(aRandom, length);
                    string details = string.Format("<p>{0}</p>", RandomAssistant.GenerateAParagraph(aRandom));

                    var cp = ContentPart.Factory.Create(partName, details, true);
                    ci.AddPart(cp);
                }
            }

            Console.Write("done!");
        }
    }
}
