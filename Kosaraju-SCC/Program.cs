using System.Collections.Generic;

namespace Kosaraju_SCC
{
    class Program
    {
        static void Main()
        {
            Graph g = new Graph();
            List<Node> nodes = new List<Node>()
            {
                new Node(0, "a"), new Node(1, "b"), new Node(2, "c"), new Node(3, "d"),
                new Node(4, "e"), new Node(5, "f"), new Node(6, "g"), new Node(7, "h")
            };

            foreach(Node node in nodes)
            {
                g.Vertecies.Add(node);
            }
            /*
             * [ a,b ]
             * [ b,c ] * [ b,e ] * [ b,f ]
             * [ c,d ] * [ c,f ]
             * [ d,b ] * [ d,h ]
             * [ e,a ] * [ e,f ]
             * [ f,g ]
             * [ g,f ]
             * [ h,d ] * [ h,g ] 
             */

            g.Adjancencies.Add(nodes[0], new HashSet<Node> { nodes[1] });//a
            g.Adjancencies.Add(nodes[1], new HashSet<Node> { nodes[2], nodes[4], nodes[5] });//b
            g.Adjancencies.Add(nodes[2], new HashSet<Node> { nodes[3], nodes[6] });//c
            g.Adjancencies.Add(nodes[3], new HashSet<Node> { nodes[2], nodes[7] });//d
            g.Adjancencies.Add(nodes[4], new HashSet<Node> { nodes[0], nodes[5] });//e
            g.Adjancencies.Add(nodes[5], new HashSet<Node> { nodes[6] });//f
            g.Adjancencies.Add(nodes[6], new HashSet<Node> { nodes[5] });//g
            g.Adjancencies.Add(nodes[7], new HashSet<Node> { nodes[3], nodes[6] });//h

            g.Kosaraju();


        }
    }
}
