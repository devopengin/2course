#include <iostream>
#include <climits>
#include <string> 
#define T 9

using namespace std;

int minDistance(int dist[], bool sptSet[]) {
	int min = INT_MAX, min_index;

	for (int v = 0; v < T; v++) {
		if (sptSet[v] == false && dist[v] <= min) {
			min = dist[v];
			min_index = v;
		}
	}
	return min_index;
}

void printPath(int dist[]) {
	string vertices = "ABCDEFGHI";

	for (int i = 0; i < T; i++) {
		cout << "До вершины " << vertices[i] << " -- " << dist[i] << endl;
	}
}

// Алгоритм Дейкстры
void algDeikstr(int graph[T][T], int src) {
	int distance[T];
	bool vertex[T];

	for (int i = 0; i < T; i++) {
		distance[i] = INT_MAX;
		vertex[i] = false;
	}

	distance[src] = 0;

	for (int count = 0; count < T - 1; count++) {
		int u = minDistance(distance, vertex);
		vertex[u] = true;

		for (int v = 0; v < T; v++) {
			if (!vertex[v] && graph[u][v] && distance[u] != INT_MAX && distance[u] + graph[u][v] < distance[v]) {
				distance[v] = distance[u] + graph[u][v];
			}
		}
	}

	printPath(distance);
}

bool isValidInput(string input) {
	for (char c : input) {
		if (!isdigit(c)) {
			return false;
		}
	}
	return true;
}

int main() {
	int dot;
	setlocale(LC_ALL, "rus");

	int graph[T][T] = {
		{0, 7, 10, 0, 0, 0, 0, 0, 0},
		{7, 0, 0, 0, 0, 9, 27, 0, 0},
		{10, 0, 0, 0, 31, 8, 0, 0, 0},
		{0, 0, 0, 0, 32, 0, 0, 17, 21},
		{0, 0, 31, 32, 0, 0, 0, 0, 0},
		{0, 9, 8, 0, 0, 0, 0, 11, 0},
		{0, 27, 0, 0, 0, 0, 0, 0, 15},
		{0, 0, 0, 17, 0, 11, 0, 0, 15},
		{0, 0, 0, 21, 0, 0, 15, 15, 0}
	};

	while (true) {
		string input;
		cout << "Введите номер вершины: \n";
		cout << "A - 0, B - 1, C - 2, D - 3, E - 4, F - 5, G - 6, H - 7, I - 8" << endl;
		cin >> input;

		if (isValidInput(input)) {
			dot = stoi(input);
			if (dot >= 0 && dot <= 8) {
				break;
			}
			else {
				cout << "Некорректный номер вершины. Попробуйте снова.\n";
			}
		}
		else {
			cout << "Некорректный ввод. Введите цифру от 0 до 8.\n";
		}
	}

	algDeikstr(graph, dot);

	return 0;
}
