using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JARVIS.Option
{
    public class DefaultOptionResolver : IOptionResolver
    {
        public double Version => 0.0;

        public async Task Resolve()
        {
            Console.WriteLine("Option was not matched! :(");
        }
    }
}
