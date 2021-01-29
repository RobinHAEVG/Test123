using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CollectionViewSource
{
    public class ViewModel
    {
        public ICollectionView People { get; set; }
        public string FilterValue { get; set; }

        public ViewModel()
        {
            var people = Enumerable.Range(0, 100).Select(i => Person.CreateRandom());
            var collectionView = System.Windows.Data.CollectionViewSource.GetDefaultView(people);
            collectionView.Filter = Filter;

            this.People = collectionView;
        }

        private bool Filter(object obj)
        {
            if (obj == null)
                return false;
            var fv = ((string) obj).ToLowerInvariant();
            //if (!)
            return false;
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDay { get; set; }
        public bool IsMarried { get; set; }
        public int Children { get; set; }

        public static Person CreateRandom()
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var firstnames = new[] { "Robin", "Robert", "Tim", "Alex", "Matthias", "Thomas", "Reiner" };
            var lastnames = new[] { "Kaiser", "Müller", "Schmidt", "Thurgau", "Früh", "Loko", "Wahnsinn" };
            var birthdays = new[] { new DateTime(1987, 4, 12), new DateTime(1992, 6, 18), new DateTime(2001, 11, 23), };
            var bools = new[] { true, false };
            var children = new[] { 0, 1, 2, 3, 4, 5 };

            return new Person()
            {
                Id = rnd.Next(),
                Firstname = firstnames.OrderBy(s => rnd.Next()).First(),
                Lastname = lastnames.OrderBy(s => rnd.Next()).First(),
                BirthDay = birthdays.OrderBy(s => rnd.Next()).First(),
                IsMarried = bools.OrderBy(e => rnd.Next()).First(),
                Children = children.OrderBy(e => rnd.Next()).First(),
            };
        }
    }
}
