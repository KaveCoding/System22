using System.Collections;

namespace PackageHandler.Tests
{
    public class ClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var list = new List<object[]>
            {
                new object[] { 0, 3770 },
                new object[] { 1, 3770 },
                new object[] { 2, 3770 },
                new object[] { 3, 5655 },
                new object[] { 8, 15080 },
                new object[] { 20, 37700 }
            };

            return list.GetEnumerator();
        }

        //Kör metoden ovan så att man får tillbaka object arrayerna när man instansierar klassen
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
