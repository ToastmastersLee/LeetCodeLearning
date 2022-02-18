using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLearning11
{
    public class _1791FindsCenterofStarGraph
    {
        //[[1,2],[2,3],[4,2]]
        // int[,] numbers = { {1, 2}, {3, 4}, {5, 6} };
        /*
         * 
            [[1,2],[2,3],[4,2]]

            degree[edge[0]]++;

            degree[edge[1]]++;


            Round 1: 
	            edge[0] = 1
	            edge[1] = 2

		            degree[1]++
		            degree[2]++

            Round 2: 
	            edge[0] = 2
	            edge[1] = 3

		            degree[2]++
		            degree[3]++

            Round 3: 
	            edge[0] = 4
	            edge[1] = 2

		            degree[4]++
		            degree[2]++
         */
        public int FindCenter()
        {
            //int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            //var aa = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            //edges = aa;

            int[][] edges = new int[3][];

            edges[0] = new int[] { 1, 2 };
            edges[1] = new int[] { 2, 3 };
            edges[2] = new int[] { 4, 2 };

            int n = edges.Length + 1;
            int[] degree = new int[n + 1];
            foreach (var edge in edges)
            {
                degree[edge[0]]++;
                degree[edge[1]]++;
            }
            for (int i = 0; ; i++)
            {
                if (degree[i] == n - 1)
                {
                    return i;
                }
            }
        }
    }
}
