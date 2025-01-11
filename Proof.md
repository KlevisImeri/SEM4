1. Notice that you can divide the large interval into small intervals by taking the beginning and the end of each interval in order.
2. Notice that each interval represents a clique. 
3. Notice that many of the intervals are repeating the same clique. Notice that the ending of intervals does not matter because the big clique contain the small clique so it only matters when you add a new interval(vertex) and not when you remove it.
4. Now the idea is that in each interval if we order it by weight only the edges connected the close intervals matter. This is because the other edges form the cycle with the edges that matter such that the other edges are the biggest weighted edge in the cycle and as we know that if and edges is the biggest weighted edge in the cycle then it should not be in the minimal weighted tree. 
   This is easy to proof, because if it was then it could have been replaced with another edges which would give less weight. And you can replace with another edges in the cycle because we have a tree and cycles should not exits there so one the lower weight edges is not there. We replace that one the the higher weighted edge.
5. Now we have filtered many edges but still is not enough. We still have n^2. 
6. The next thing to notice is that you only need the edges to the closest interval (vertex) by weight when the interval (vertex) first shows. This its easy to prove that works because we only needed edges which are closest to the neighbor by[4]. For each interval it would be the case that we have edges to the closest neighbors because we have the edges from the previous interval and we insert another interval and the edges closest to that interval, so we only add more edges which are needed for the new interval and its neighbors. (You can easely proof this with recursion). Also [3] is important here.
7. No everytime we add an interval we get 2n edges => enough for Kruskal's;



Let 