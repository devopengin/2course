#include <iostream>
#include <Windows.h>
using namespace std;

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	int N, n;
	cout << "Введите вместительность рюкзака: "; cin >> N;
	cout << "Введите количество предметов: "; cin >> n;

	string* name = new string[n];
	int* cost = new int[n];
	int* ves = new int[n];

	for (int i = 0; i < n; i++) {
		cout << "\nВведите название " << i + 1 << " предмета: "; cin >> name[i];
		cout << "Введите стоимость " << i + 1 << " предмета: "; cin >> cost[i];
		cout << "Введите вес " << i + 1 << " предмета: "; cin >> ves[i];
	}

	int** A = new int* [n + 1];
	for (int i = 0; i < n + 1; i++) {
		A[i] = new int[N + 1];
	}

	for (int i = 0; i < n + 1; i++) {
		for (int j = 0; j < N + 1; j++) {
			A[i][j] = 0;
		}
	}

	for (int i = 1; i < n + 1; i++) {
		for (int j = 1; j < N + 1; j++) {
			if (j < ves[i - 1]) {
				A[i][j] = A[i - 1][j];
				cout << A[i][j] << "\t";
			}
			else {
				A[i][j] = max(A[i - 1][j], A[i - 1][j - ves[i - 1]] + cost[i - 1]);
				cout << A[i][j] << "\t";
			}
		}
		cout << "\n";
	}

	cout << "\nМаксимальная стоимость предметов, положенных в рюкзак: " << A[n][N];
	cout << "\nПредметы, положенные в рюкзак: ";

	int i = n, j = N;
	while (i > 0 && j > 0) {
		if (A[i][j] != A[i - 1][j]) {
			cout << name[i - 1] << " ";
			j -= ves[i - 1];
		}
		i--;
	}

	cout << endl;
	for (int i = 0; i < n + 1; i++) {
		delete[] A[i];
	}
	delete[] A;
	delete[] name;
	delete[] cost;
	delete[] ves;
}
