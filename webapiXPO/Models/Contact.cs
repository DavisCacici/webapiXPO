
using DevExpress.Xpo;
using System.ComponentModel;

namespace webapiXPO.Models
{
    public class Contact :XPObject
    {
        public Contact(Session session) :base(session) { }
        string name;
        [Size(255)]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }
        string surname;
        [Size(255)]
        public string Surname
        {
            get { return surname; }
            set { SetPropertyValue(nameof(Surname), ref surname, value); }
        }

        int age;
        [Size(5)]
        public int Age
        {
            get { return age; }
            set { SetPropertyValue(nameof(Age), ref age, value); }
        }

        Gender gender;
        public Gender Gender
        {
            get { return gender; }
            set { SetPropertyValue(nameof(Gender), ref gender, value); }
        }
    }

    public enum Gender
    {
        M,
        F
    }
}
