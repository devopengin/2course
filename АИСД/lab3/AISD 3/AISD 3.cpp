#include <iostream>
#include <limits>

using namespace std;

constexpr int SIZE = 9;

int graph[SIZE][SIZE] = {
	{0, 7, 10, 0, 0, 0, 0, 0, 0},
	{7, 0, 0, 0, 0, 9, 27, 0, 0},
	{10, 0, 0, 0, 31, 8, 0, 0, 0},
	{0, 0, 0, 0, 32, 0, 0, 17, 21},
	{0, 0, 31, 32, 0, 0, 0, 0, 0},
	{0, 9, 8, 0, 0, 0, 0, 11, 0},
	{0, 27, 0, 0, 0, 0, 0, 0, 15},
	{0, 0, 0, 17, 0, 11, 0, 0, 15},
	{0, 0, 0, 21, 0, 0, 15, 15, 0},
};

int minDistance(const int dist[], const bool visited[])
{
	int min = INT32_MAX;
	int min_index = -1;

	for (int node = 0; node < SIZE; node++)
	{
		if (!visited[node] && dist[node] <= min)
		{
			min = dist[node];
			min_index = node;
		}
	}
	return min_index;
}

void DijkstraAlgorithm(int startNode)
{
	int distance[SIZE];
	bool visited[SIZE];

	for (int i = 0; i < SIZE; ++i)
	{
		distance[i] = INT32_MAX;
		visited[i] = false;
	}

	distance[startNode] = 0;

	for (int count = 0; count < SIZE - 1; ++count)
	{
		int minIndex = minDistance(distance, visited);
		visited[minIndex] = true;

		for (int node = 0; node < SIZE; ++node) {
			if (!visited[node] && graph[minIndex][node] && distance[minIndex] != INT32_MAX &&
				distance[minIndex] + graph[minIndex][node] < distance[node])
			{
				distance[node] = distance[minIndex] + graph[minIndex][node];
			}
		}
	}

	const char nodes[SIZE] = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };
	
	for (int i = 0; i < SIZE; i++)
	{
		cout << "Минимальное расстояние до вершины " << nodes[i] << " " << distance[i] << endl;
	}
}

int charToIndex(char node) {

	node = toupper(node);
	if (node >= 'A' && node <= 'I') {
		return node - 'A';
	}
	return -1;
}

int main() {

	setlocale(LC_ALL, "Ru");

	char node;
	int startVertex;

	cout << "Введите символ вершины (A-I): ";
	cin >> node;
	startVertex = charToIndex(node);
	if (startVertex == -1)
	{
		cout << "Неверная вершина\n";
		return 0;
	}

	DijkstraAlgorithm(startVertex);

	return 0;
}
