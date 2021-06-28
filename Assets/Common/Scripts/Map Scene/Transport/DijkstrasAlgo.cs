using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DijkstrasAlgo : MonoBehaviour
{
    [SerializeField] private PlaceTransport _placeTransport;
    private static int[,] _graph = null;
    private static int _nodeCount;
    private static List<int> _shortestpath = new List<int>();
    

    public struct Node
    {
        public bool permanant;
        public int distFromSrc;
        public int parent;
    }

    private void Awake()
    {
        _graph = _placeTransport.Graph;
    }

    public int GetTimeToTransport(int origin, int target)
    {
        return Dijkstra(origin, target);
    }

    private static int Dijkstra(int origin, int target)
    {
        _nodeCount = _graph.GetLength(0);

        Node[] nodeSet = new Node[_nodeCount];

        for(int i = 0; i < _nodeCount; i++)
        {
            nodeSet[i].distFromSrc = int.MaxValue;
            nodeSet[i].permanant = false;
        }

        nodeSet[origin].distFromSrc = 0;
        nodeSet[origin].parent = -1;

        //min distance
        for(int count = 0; count < _nodeCount - 1; count++)
        {
            int u = MinDistance(nodeSet);
            nodeSet[u].permanant = true;

            if(u == target)
            {
                break;
            }

            for(int v = 0; v < _nodeCount; v++)
            {
                if(!nodeSet[v].permanant && _graph[u, v] != 0 && nodeSet[u].distFromSrc != int.MaxValue &&
                    nodeSet[u].distFromSrc + _graph[u, v] < nodeSet[v].distFromSrc)
                {
                    nodeSet[v].distFromSrc = nodeSet[u].distFromSrc + _graph[u, v];
                    nodeSet[v].parent = u;
                }
            }
        }

        ////get path
        //ShortestPath(nodeSet, target);
        //_shortestpath.Reverse();

        return nodeSet[target].distFromSrc;
    }

    private static int MinDistance(Node[] nodeSet)
    {
        int min = int.MaxValue;
        int min_index = -1;
        for(int i = 0; i < _nodeCount; i++)
        {
            if(nodeSet[i].permanant == false && nodeSet[i].distFromSrc <= min)
            {
                min = nodeSet[i].distFromSrc;
                min_index = i;
            }
        }
        return min_index;
    }

    private static void ShortestPath(Node[] nodeSet, int dest)
    {
        if (nodeSet[dest].parent != -1)
        {
            _shortestpath.Add(dest);
            ShortestPath(nodeSet, nodeSet[dest].parent);
        }
        else
        {
            _shortestpath.Add(dest);
            return;
        }
    }
}
