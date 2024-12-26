#include <iostream>
#include <vector>
#include <algorithm>
#include <cstdlib>
#include <ctime>

using namespace std;

const int PRISONERS = 100;
const int BOXES = 100;
const int MAX_ATTEMPTS = 50;

vector<int> generateBoxes() {
    vector<int> boxes(BOXES);
    for (int i = 0; i < BOXES; ++i) {
        boxes[i] = i + 1;
    }
    random_shuffle(boxes.begin(), boxes.end());
    return boxes;
}

bool RandomSelection(const vector<int>& boxes, int prisonerNumber) {
    for (int attempt = 0; attempt < MAX_ATTEMPTS; ++attempt) {
        if (boxes[rand() % BOXES] == prisonerNumber) {
            return true;
        }
    }
    return false;
}

bool AlgoritmSelection(const vector<int>& boxes, int prisonerNumber) {
    int currentBox = prisonerNumber - 1;
    for (int attempt = 0; attempt < MAX_ATTEMPTS; ++attempt) {
        if (boxes[currentBox] == prisonerNumber) {
            return true;
        }
        currentBox = boxes[currentBox] - 1;
    }
    return false;
}

bool runRound(const vector<int>& boxes, bool (*selectionMethod)(const vector<int>&, int)) {
    for (int prisoner = 1; prisoner <= PRISONERS; ++prisoner) {
        if (!selectionMethod(boxes, prisoner)) {
            return false;
        }
    }
    return true;
}

int main() {
    setlocale(LC_ALL, "RUS");
    srand(time(0));

    cout << "Введите количество раундов: ";
    int rounds;
    cin >> rounds;

    int randomSuccessCount = 0;
    int loopSuccessCount = 0;

    for (int round = 0; round < rounds; ++round) {
        vector<int> boxes = generateBoxes();

        if (runRound(boxes, RandomSelection)) {
            ++randomSuccessCount;
        }

        if (runRound(boxes, AlgoritmSelection)) {
            ++loopSuccessCount;
        }
    }
    cout << "Случайный способ: " << randomSuccessCount << " успешных раундов." << endl;
    cout << "Алгоритм выбора по номеру: " << loopSuccessCount << " успешных раундов." << endl;

    return 0;
}
