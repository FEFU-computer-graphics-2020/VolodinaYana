﻿using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using OpenTK;
using System.Globalization;
using System;

namespace OGL_tut
{
    public struct Mesh
    {
        public Vertex[] vertices;
        public int[] indices;

        public Mesh(List<Vertex> verts, List<int> inds)
        {
            vertices = verts.ToArray();
            indices = inds.ToArray();
        }
    }
    class MeshL
    {
        static public Mesh LoadMesh(string path_to_file)
        {
            string content;
            using (var thread = new StreamReader(path_to_file))
            {
                content = thread.ReadToEnd();
            }
            var rows = content.Split('\n');

            var vertices = new List<Vertex>();
            var indices = new List<int>();

            var reg_v = new Regex(@"v ([-\.\d]+) ([-\.\d]+) ([-\.\d]+)");
            var reg_i = new Regex(@"f (\d+)/(\d+)/(\d+) (\d+)/(\d+)/(\d+) (\d+)/(\d+)/(\d+)");

            Random rand = new Random();

            foreach (var row in rows)
            {
                if (reg_v.IsMatch(row))
                {
                    var match = reg_v.Match(row);

                    var vertex = new Vertex(
                        new Vector3(float.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture), float.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture), float.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture)),
                        new Vector3((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble())
                        //new Vector3(0.2f, 0.3f, 0.5f)
                    );
                    vertices.Add(vertex);

                }
                if (reg_i.IsMatch(row))
                {
                    var match = reg_i.Match(row);

                    indices.Add(int.Parse(match.Groups[1].Value) - 1);
                    indices.Add(int.Parse(match.Groups[4].Value) - 1);
                    indices.Add(int.Parse(match.Groups[7].Value) - 1);

                }

            }

            return new Mesh(vertices, indices);



        }

    }
}
