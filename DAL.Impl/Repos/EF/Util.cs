using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Impl.Repos.EF
{
    internal class Util
    {
        private static readonly Random Rnd = new Random();
        private static int _id = 1;

        internal static string GenerateRandomProductName()
        {
            return "Test " + _id++;
        }

        internal static Guid GetGuidOfRandomBrand(IReadOnlyCollection<Guid> brands)
        {
            return brands.ElementAt(Rnd.Next(brands.Count));
        }
        internal static T GetRandomValueFromEnum<T>()
        {
            var members = Enum.GetValues(typeof(T));
            return (T)members.GetValue(Rnd.Next(members.Length));
        }
    }
}
