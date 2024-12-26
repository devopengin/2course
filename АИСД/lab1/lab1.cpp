#include <iostream>
using namespace std;

void hanoi_tower(int n, int from, int to, int sup) {
    if (n == 1) {
        cout << "ѕереместить диск 1 с " << from << " на " << to << " стержень" << endl;
        return;
    }
    hanoi_tower(n - 1, from, sup, to);
    cout << "ѕереместить диск " << n << " с " << from << " на " << to << " стержень" << endl;
    hanoi_tower(n - 1, sup, to, from);
}

int main() {
    setlocale(LC_ALL, "RUS");

    float n, k;
    cout << "¬ведите количество дисков (N): ";
    while (!(cin >> n) || n <= 0 || round(n) != n) {
        cout << "ќшибка! ¬ведите положительное число." << endl;
        cin.clear();
        cin.ignore(10000, '\n');
    }

    cout << "¬ведите номер конечного стержн€ (K): ";
    while (!(cin >> k) || k < 2 || k > 3 || round(k) != k) {
        cout << "ќшибка! ¬ведите число от 2 или 3." << endl;
        cin.clear();
        cin.ignore(10000, '\n');
    }

    hanoi_tower(n, 1, k, 6 - 1 - k);

    return 0;
}
