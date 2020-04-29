using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Opengl
{
    public class ProgClass
    {

        static void Main(string[] args)
        {
            var application = new AppClass(800, 600, "«<»>");
            application.Run(60);
        }
    }
}
