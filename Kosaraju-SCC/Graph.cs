﻿using System;
using System.Collections.Generic;

namespace Kosaraju_SCC
{
    public class Graph
    {
        public HashSet<Node> Vertecies { get; set; }
        public Dictionary<Node, HashSet<Node>> Adjancencies { get; set; }

        public Graph()
        {
            Vertecies = new HashSet<Node>();
            Adjancencies = new Dictionary<Node, HashSet<Node>>();
        }

        public void Kosaraju()
        {
            HashSet<Node> VertexList = new HashSet<Node>();

            foreach (Node node in Vertecies)
            {
                Visit(node, VertexList);
            }

            foreach (Node node in VertexList)
            {
                Assign(node, node);
            }
        }

        private void Visit(Node node, HashSet<Node> VertexList)
        {
            if (node.Color == Node.Colors.White)
            {
                node.Color = Node.Colors.Gray;
                foreach (Node vertex in Adjancencies[node])
                {
                    Visit(vertex, VertexList);
                }
                VertexList.Add(node);
            }
        }

        private void Assign(Node node, Node root)
        {
            if (node.Color != Node.Colors.Black)
            {
                if (node == root)
                {
                    Console.Write("Strongly connected component: ");
                }

                Console.Write($"{node.Name} ");
                node.Color = Node.Colors.Black;

                foreach (Node vertex in Adjancencies[node])
                {
                    Assign(vertex, root);
                }

                if (node == root)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
