#include <iostream>
using namespace std;

void hanoi_tower(int n, int from, int to, int sup) {
    if (n == 1) {
        cout << "����������� ���� 1 � " << from << " �� " << to << " ��������" << endl;
        return;
    }
    hanoi_tower(n - 1, from, sup, to);
    cout << "����������� ���� " << n << " � " << from << " �� " << to << " ��������" << endl;
    hanoi_tower(n - 1, sup, to, from);
}

int main() {
    setlocale(LC_ALL, "RUS");

    float n, k;
    cout << "������� ���������� ������ (N): ";
    while (!(cin >> n) || n <= 0 || round(n) != n) {
        cout << "������! ������� ������������� �����." << endl;
        cin.clear();
        cin.ignore(10000, '\n');
    }

    cout << "������� ����� ��������� ������� (K): ";
    while (!(cin >> k) || k < 2 || k > 3 || round(k) != k) {
        cout << "������! ������� ����� �� 2 ��� 3." << endl;
        cin.clear();
        cin.ignore(10000, '\n');
    }

    hanoi_tower(n, 1, k, 6 - 1 - k);

    return 0;
}
