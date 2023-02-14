using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CQRS_read_infraestrutura.Persistence.People
{
    [Flags]
    public enum PersonClass
    {
        Comum,
        Admin
    }

    public class Person
    {
        public int id { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PersonClass Class { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person (int id, PersonClass personClass, string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");

            this.id = id;
            Class = personClass;
            Name = name;
            Age = age;
        }

        public Person(PersonClass personClass, string name, int age)
        {
            this.id = -1;
            Class = personClass;
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{this.Class}: [Class]{this.Class}, [Name]{this.Name}, [Age]{this.Age}";
        }
    }
}
