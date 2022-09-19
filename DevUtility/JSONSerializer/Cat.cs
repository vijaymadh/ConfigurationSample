using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConfigurationValidation.JSONSerializer
{
    class Cat
    {
        public Cat(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; private set; }

        [DefaultValue(5)]
        [JsonProperty("age",DefaultValueHandling = DefaultValueHandling.Populate)]
        public int Age { get; private set; }

        [DefaultValue(false)]
        [JsonProperty("male",DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool Male { get; private set; }

    }
}
