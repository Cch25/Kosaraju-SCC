using Kosaraju_SCC.Algorithm;
using NUnit.Framework;
using System.Collections.Generic;

namespace KosarajuUnitTests
{
    public class Tests
    {
        private Graph _graph;
        private List<Node> _nodes;
        [SetUp]
        public void Setup()
        {
            _graph = new Graph();
            _nodes = new List<Node>()
            {
                new Node(0, "a"), new Node(1, "b"), new Node(2, "c"), new Node(3, "d"),
                new Node(4, "e"), new Node(5, "f"), new Node(6, "g"), new Node(7, "h")
            };
            foreach (Node node in _nodes)
            {
                _graph.Vertecies.Add(node);
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
            _graph.Adjancencies.Add(_nodes[0], new HashSet<Node> { _nodes[1] });//a
            _graph.Adjancencies.Add(_nodes[1], new HashSet<Node> { _nodes[2], _nodes[4], _nodes[5] });//b
            _graph.Adjancencies.Add(_nodes[2], new HashSet<Node> { _nodes[3], _nodes[6] });//c
            _graph.Adjancencies.Add(_nodes[3], new HashSet<Node> { _nodes[2], _nodes[7] });//d
            _graph.Adjancencies.Add(_nodes[4], new HashSet<Node> { _nodes[0], _nodes[5] });//e
            _graph.Adjancencies.Add(_nodes[5], new HashSet<Node> { _nodes[6] });//f
            _graph.Adjancencies.Add(_nodes[6], new HashSet<Node> { _nodes[5] });//g
            _graph.Adjancencies.Add(_nodes[7], new HashSet<Node> { _nodes[3], _nodes[6] });//h
        }

     
        [Test]
        public void StronglyConnectedComponent_SplitOnClusters_ShouldReturnThreeClusters()
        {
            //Arrange
           
            //Act
            _graph.Kosaraju();
            //Assert
            Assert.AreEqual(_graph.StronglyConnected.Count, 3);
        }


        [Test]
        public void StronglyConnectedComponent_SplitOnClusters_ShouldReturnValues()
        {
            //Act
            _graph.Kosaraju();
            //Assert
            Assert.That(_graph.StronglyConnected[0].Value, Is.EqualTo(new List<string> { "f", "g" }));
            Assert.That(_graph.StronglyConnected[1].Value, Is.EqualTo(new List<string> { "h", "d","c" }));
            Assert.That(_graph.StronglyConnected[2].Value, Is.EqualTo(new List<string> { "e", "a","b" }));
        }


        #region [ Invalid test ]
        //private static readonly object[] _sourceLists =
        //{
        //    new object[] { _graph.StronglyConnected[0], new List<string> {"f","g" } },   
        //    new object[] { _graph.StronglyConnected[1], new List<string> { "h","d","c"} } 
        //};

        //[TestCaseSource(nameof(_sourceLists))]
        //public void StronglyConnectedComponent_SplitOnClusters_ShouldReturnValues(List<string> value, List<string> expectedResult)
        //{
        //    _graph.Kosaraju();
        //    Assert.That(value, Is.EqualTo(expectedResult).IgnoreCase);
        //} 
        #endregion
    }
}