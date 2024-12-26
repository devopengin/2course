#include <iostream>
#include <Windows.h>
using namespace std;

const int NODES = 6;
const int INF = INT_MAX;

int distances[NODES][NODES] = {
	{0, 28, 21, 59, 12, 27},
	{7, 0, 24, INF, 21, 9},
	{9, 32, 0, 13, 11, INF},
	{8, INF, 5, 0, 16, INF},
	{14, 13, 15, 10, 0, 22},
	{15, 18, INF, INF, 6, 0}
};


int paths[NODES][NODES] = {
	{0, 2, 3, 4, 5, 6},
	{1, 0, 3, 4, 5, 6},
	{1, 2, 0, 4, 5, 6},
	{1, 2, 3, 0, 5, 6},
	{1, 2, 3, 4, 0, 6},
	{1, 2, 3, 4, 5, 0}
};

void floyd() {
	for (int k = 0; k < NODES; k++) {
		for (int i = 0; i < NODES; i++) {
			if (distances[i][k] == INF) continue;
			for (int j = 0; j < NODES; j++) {
				if (distances[k][j] == INF) continue;
				if (distances[i][j] > distances[i][k] + distances[k][j]) {
					distances[i][j] = distances[i][k] + distances[k][j];
					paths[i][j] = paths[i][k];
				}
			}
		}
	}
}

void printMatrices() {
	cout << "Длины путей:\n\t1\t2\t3\t4\t5\t6\n";
	for (int i = 0; i < NODES; i++) {
		cout << i + 1 << "|\t";
		for (int j = 0; j < NODES; j++) {
			if (distances[i][j] == INF) cout << "INF\t";
			else cout << distances[i][j] << "\t";
		}
		cout << "\n";
	}

	cout << "\nМатрица путей:\n\t1\t2\t3\t4\t5\t6\n";
	for (int i = 0; i < NODES; i++) {
		cout << i + 1 << "|\t";
		for (int j = 0; j < NODES; j++) {
			cout << paths[i][j] << "\t";
		}
		cout << "\n";
	}
}

int main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	floyd();
	printMatrices();

	return 0;
}
