using NSubstitute;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TestUtility
{
    public class TestHelper
    {
        /// <summary>
        /// Version1
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="d"></param>
        /// <param name="l"></param>
        public static void SettingMockDbSet<T>(DbSet<T> d, List<T> l) where T : class
        {
            var q = l.AsQueryable();
            d.AsQueryable().Provider.Returns(q.Provider);
            d.AsQueryable().Expression.Returns(q.Expression);
            d.AsQueryable().ElementType.Returns(q.ElementType);
            d.AsQueryable().GetEnumerator().Returns(q.GetEnumerator());
        }

        /// <summary>
        /// Version2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="d"></param>
        /// <param name="l"></param>
        public static DbSet<T> GetMockDbSet<T>(List<T> l) where T : class
        {
            var d = Substitute.For<DbSet<T>, IQueryable<T>>();
            var q = l.AsQueryable();
            d.AsQueryable().Provider.Returns(q.Provider);
            d.AsQueryable().Expression.Returns(q.Expression);
            d.AsQueryable().ElementType.Returns(q.ElementType);
            d.AsQueryable().GetEnumerator().Returns(q.GetEnumerator());
            return d;
        }
    }
}
