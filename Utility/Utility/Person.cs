using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Person
    {
        public Person(int age, string description)
        {
            this.Age = age;
            this.Purchase.Description = description;
        }
        [Serializable] // Not required if using MemberwiseClone
        public class PurchaseType
        {
            public string Description;
            public PurchaseType ShallowCopy()
            {
                return (PurchaseType)this.MemberwiseClone();
            }
        }
        public PurchaseType Purchase = new PurchaseType();
        public int Age;
        //// Add this if using nested MemberwiseClone.
        //// This is a class, which is a reference type, so cloning is more difficult.
        //public Person ShallowCopy()
        //{
        //    return (Person)this.MemberwiseClone();
        //}
        //// Add this if using nested MemberwiseClone.
        //// This is a class, which is a reference type, so cloning is more difficult.
        //public Person DeepCopy()
        //{
        //    // Clone the root ...
        //    Person other = (Person)this.MemberwiseClone();
        //    // ... then clone the nested class.
        //    other.Purchase = this.Purchase.ShallowCopy();
        //    return other;
        //}
    }
}
