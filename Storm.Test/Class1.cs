using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Test
{
    class Class1
    {
        public void Example()
        {
            var generator = Generator.FromConnectionString("server=localhost;database=dbname;user id=user;password=pass;");
            generator.Generate();
        }
    }
}
