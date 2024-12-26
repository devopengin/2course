#include <iostream>
#include <cstring>
using namespace std;

#define INF 9999
#define VERTEX 8


int G[VERTEX][VERTEX] = {
	{0, 2, 0, 8, 2, 0, 0, 0},
	{2, 0, 3, 10, 5, 0, 0, 0},
	{0, 3, 0, 0, 12, 0, 0, 7},
	{8, 10, 0, 0, 14, 3, 1, 0},
	{2, 5, 12, 14, 0, 11, 4, 8},
	{0, 0, 0, 3, 11, 0, 6, 0},
	{0, 0, 0, 1, 4, 6, 0, 9},
	{0, 0, 7, 0, 8, 0, 9, 0}
};

int main() {
	setlocale(LC_ALL, "RUS");
	int quantity_edge;
	int selected[VERTEX];
	memset(selected, false, sizeof(selected));
	quantity_edge = 0;

	int start_vertex;

	cout << "Введите начальную вершину (от 1 до " << VERTEX << "): ";
	while (!(cin >> start_vertex) || start_vertex < 1 || start_vertex > VERTEX) {
		cout << "Ошибка: введите целое число от 1 до " << VERTEX << ": ";
		cin.clear();
		cin.ignore(10000, '\n');
	}

	start_vertex -= 1;
	selected[start_vertex] = true;
	int x;
	int y;
	while (quantity_edge < VERTEX - 1) {
		int min = INF;
		x = 0;
		y = 0;
		for (int i = 0; i < VERTEX; i++) {
			if (selected[i]) {
				for (int j = 0; j < VERTEX; j++) {
					if (!selected[j] && G[i][j]) {
						if (min > G[i][j]) {
							min = G[i][j];
							x = i;
							y = j;
						}
					}
				}
			}
		}
		cout << (x + 1) << " - " << (y + 1) << " == " << G[x][y] << endl;
		selected[y] = true;
		quantity_edge++;
	}

	return 0;
}
