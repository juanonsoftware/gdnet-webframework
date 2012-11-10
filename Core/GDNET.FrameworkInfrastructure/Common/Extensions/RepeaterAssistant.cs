using System.Collections.Generic;
using System.Linq;
using GDNET.Framework.Services;
using GDNET.Web.Mvc;

namespace GDNET.WebInfrastructure.Common.Extensions
{
    public static class RepeaterAssistant
    {
        public static Repeater<T> Create<T>(string name)
        {
            return new Repeater<T>()
            {
                Name = name
            };
        }

        public static Repeater<T> EnableHeader<T>(this Repeater<T> repeater, bool value)
        {
            repeater.EnableHeader = value;

            return repeater;
        }

        public static Repeater<T> AddColumns<T>(this Repeater<T> repeater, params string[] columns)
        {
            return repeater.AddColumns(columns.ToList());
        }

        public static Repeater<T> AddColumnWithText<T>(this Repeater<T> repeater, string columnName, string columnTextKeyword)
        {
            string columnText = FrameworkServices.Translation.GetByKeyword(columnTextKeyword);
            return repeater.AddColumn(columnName, columnText);
        }

        public static Repeater<T> AddColumns<T>(this Repeater<T> repeater, IList<string> columns)
        {
            foreach (string aColumn in columns)
            {
                repeater.AddColumn(aColumn);
            }

            return repeater;
        }

        public static Repeater<T> AddEntities<T>(this Repeater<T> repeater, params T[] entities)
        {
            return repeater.AddEntities(entities.ToList());
        }

        public static Repeater<T> AddEntities<T>(this Repeater<T> repeater, IList<T> entities)
        {
            foreach (T anEntity in entities)
            {
                repeater.AddEntity(anEntity);
            }

            return repeater;
        }
    }
}
