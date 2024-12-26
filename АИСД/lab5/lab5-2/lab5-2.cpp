#include <iostream>
using namespace std;

#define INF 9999
#define VERTEX 8
int parent[VERTEX];

int find(int i) {
	if (parent[i] != i) {
		parent[i] = find(parent[i]);
	}
	return parent[i];
}

void unionSets(int a, int b) {
	parent[find(a)] = find(b);
}

void kruskal(int graph[VERTEX][VERTEX]) {
	int edgesCount = 0;
	for (int i = 0; i < VERTEX; i++) {
		parent[i] = i;
	}

	while (edgesCount < VERTEX - 1) {
		int minWeight = INF;
		int u = -1, v = -1;

		for (int i = 0; i < VERTEX; i++) {
			for (int j = 0; j < VERTEX; j++) {
				if (graph[i][j] > 0 && graph[i][j] < minWeight) {
					if (find(i) != find(j)) {
						minWeight = graph[i][j];
						u = i;
						v = j;
					}
				}
			}
		}

		unionSets(u, v);
		edgesCount++;
		cout << u + 1 << " - " << v + 1 << " == " << minWeight << endl;
	}
}

int main() {
	setlocale(LC_ALL, "RUS");
	int graph[VERTEX][VERTEX] = {
		{0, 2, 0, 8, 2, 0, 0, 0},
		{2, 0, 3, 10, 5, 0, 0, 0},
		{0, 3, 0, 0,  12, 0, 0, 7},
		{8, 10, 0, 0,14, 3, 1, 0},
		{2, 5, 12, 14, 0, 11, 4, 8},
		{0, 0, 0, 3, 11, 0, 6, 0},
		{0, 0, 0, 1, 4, 6, 0, 9},
		{0, 0, 7, 0, 8, 0, 9, 0}
	};

	cout << "Алгоритм Краскала: " << endl;
	cout << "Рёбра: " << endl;
	kruskal(graph);
	return 0;
}
