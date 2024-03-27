using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates.NullObject
{
    public sealed class NullAnimal : IAnimal
    {
        private static readonly IAnimal nullAnimal = new NullAnimal();
        private NullAnimal() { }
        public string MakeSound()
        {
            return string.Empty;
        }
        public string GetName()
        {
            return String.Empty;
        }
        public static IAnimal Instance
        {
            get
            {
                return nullAnimal;
            }
        }
    }
}
