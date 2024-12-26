#include <iostream>
#include <vector>
#include <cmath>
#include <cstdlib>
#include <ctime>
#include <limits>

using namespace std;

struct Ant {
    vector<int> path;
    double pathLength;
};

int cityCount;
double alpha, beta, initialPheromone, evaporationRate = 0.64;
int iterationCount;
vector<vector<double>> distanceMatrix;
vector<vector<double>> pheromoneMatrix;
vector<int> bestPath;
double bestPathLength = numeric_limits<double>::infinity();

void generateDistanceMatrix() {
    distanceMatrix.resize(cityCount, vector<double>(cityCount, 0));
    for (int i = 0; i < cityCount; ++i) {
        for (int j = i + 1; j < cityCount; ++j) {
            double distance = rand() % 100 + 1;
            distanceMatrix[i][j] = distance;
            distanceMatrix[j][i] = distance;
        }
    }
}

void printDistanceMatrix() {
    cout << "\nИсходная матрица расстояний между городами:\n";
    for (int i = 0; i < cityCount; ++i) {
        for (int j = 0; j < cityCount; ++j) {
            cout << distanceMatrix[i][j] << " ";
        }
        cout << endl;
    }
}

int selectNextCity(int currentCity, const vector<bool>& visited) {
    vector<double> TransitionProbability(cityCount, 0);
    double totalProbability = 0;

    for (int i = 0; i < cityCount; ++i) {
        if (!visited[i]) {
            double pheromoneLevel = pow(pheromoneMatrix[currentCity][i], alpha);
            double visibility = pow(1.0 / distanceMatrix[currentCity][i], beta);
            TransitionProbability[i] = pheromoneLevel * visibility;
            totalProbability += TransitionProbability[i];
        }
    }

    for (int i = 0; i < cityCount; ++i) {
        TransitionProbability[i] /= totalProbability;
    }

    double randomValue = (rand() % 1000) / 1000.0;
    double cumulativeProbability = 0;
    for (int i = 0; i < cityCount; ++i) {
        if (!visited[i]) {
            cumulativeProbability += TransitionProbability[i];
            if (cumulativeProbability >= randomValue) {
                return i;
            }
        }
    }

    return -1;
}

void updatePheromones(const vector<Ant>& ants) {

    for (int i = 0; i < cityCount; ++i) {
        for (int j = 0; j < cityCount; ++j) {
            pheromoneMatrix[i][j] *= evaporationRate;
        }
    }

    for (const auto& ant : ants) {
        double pheromoneContribution = 1.0 / ant.pathLength;

        for (int i = 0; i < cityCount - 1; ++i) {
            int from = ant.path[i];
            int to = ant.path[i + 1];
            pheromoneMatrix[from][to] += pheromoneContribution;
            pheromoneMatrix[to][from] += pheromoneContribution;
        }

        int from = ant.path[cityCount - 1];
        int to = ant.path[0];
        pheromoneMatrix[from][to] += pheromoneContribution;
        pheromoneMatrix[to][from] += pheromoneContribution;
    }
}


void printBestSolution(int iteration) {
    cout << "Итерация " << iteration + 1 << ": лучший маршрут [";
    for (size_t i = 0; i < bestPath.size(); ++i) {
        cout << bestPath[i];
        if (i < bestPath.size() - 1) cout << " -> ";
    }
    cout << "] длина: " << bestPathLength << endl;
}

void runAntColonyOptimization() {
    srand(time(0));
    generateDistanceMatrix();
    printDistanceMatrix();

    pheromoneMatrix.resize(cityCount, vector<double>(cityCount, initialPheromone));

    for (int iter = 0; iter < iterationCount; ++iter) {
        vector<Ant> ants(cityCount);

        for (auto& ant : ants) {
            ant.path.clear();
            ant.path.push_back(rand() % cityCount);
            ant.pathLength = 0;
        }

        for (auto& ant : ants) {
            vector<bool> visited(cityCount, false);
            visited[ant.path[0]] = true;

            for (int i = 1; i < cityCount; ++i) {
                int currentCity = ant.path[i - 1];
                int nextCity = selectNextCity(currentCity, visited);
                ant.path.push_back(nextCity);
                ant.pathLength += distanceMatrix[currentCity][nextCity];
                visited[nextCity] = true;
            }

            ant.pathLength += distanceMatrix[ant.path[cityCount - 1]][ant.path[0]];

            if (ant.pathLength < bestPathLength) {
                bestPathLength = ant.pathLength;
                bestPath = ant.path;
            }
        }

        updatePheromones(ants);

        printBestSolution(iter);
    }
}

int main() {
    setlocale(LC_ALL, "RUS");
    cout << "Введите количество городов (N): ";
    cin >> cityCount;
    cout << "Введите начальное значение феромонов (значение < 1): ";
    cin >> initialPheromone;
    cout << "Введите значения альфа и бета: ";
    cin >> alpha >> beta;
    cout << "Введите количество итераций: ";
    cin >> iterationCount;

    runAntColonyOptimization();

    return 0;
}
