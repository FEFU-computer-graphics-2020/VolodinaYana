using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace OGL_tut
{
    public struct Vertex
    {
        public Vertex(Vector3 position, Vector3 color)
        {
            this.position = position;
            this.color = color;
        }

        public Vector3 position;
        public Vector3 color;
    }
}
