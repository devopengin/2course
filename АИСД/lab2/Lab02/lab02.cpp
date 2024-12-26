#include <iostream>
#include <stack>
#include <queue>
#include <vector>  // Для использования вектора

using namespace std;

const int n = 10;  // Количество вершин в графе
bool* visitedVertex = new bool[n];  // Массив для отслеживания посещенных вершин

// Матрица смежности графа
int graph[n][n] =
{
    {0, 1, 0, 0, 1, 0, 0, 0, 0, 0},
    {1, 0, 0, 0, 0, 0, 1, 1, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
    {0, 0, 0, 0, 0, 1, 0, 0, 1, 0},
    {1, 0, 0, 0, 0, 1, 0, 0, 0, 0},
    {0, 0, 0, 1, 1, 0, 0, 0, 1, 0},
    {0, 1, 0, 0, 0, 0, 0, 1, 0, 0},
    {0, 1, 1, 0, 0, 0, 1, 0, 0, 0},
    {0, 0, 0, 1, 0, 1, 0, 0, 0, 1},
    {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
};

// Поиск в глубину (DFS) через стек
void DFS(int start) {
    stack<int> nodes;
    vector<int> path;
    fill(visitedVertex, visitedVertex + n, false);
    nodes.push(start);  
    visitedVertex[start] = true;

    while (!nodes.empty()) {
        int node = nodes.top();  
        nodes.pop();
        path.push_back(node);

        
        for (int vertexNeighbor = n - 1; vertexNeighbor >= 0; --vertexNeighbor) {
            if (graph[node][vertexNeighbor] == 1 && !visitedVertex[vertexNeighbor]) {
                nodes.push(vertexNeighbor); 
                visitedVertex[vertexNeighbor] = true;  
            }
        }
    }

    // Выводим путь обхода
    for (size_t i = 0; i < path.size(); ++i) {
        cout << path[i] + 1;  
        if (i != path.size() - 1) { 
            cout << " > "; 
        }
    }
    cout << endl;
}

// Поиск в ширину (BFS)
void BFS(int start) {
    queue<int> q; 
    bool inqueue[n] = { false };  // Массив для отслеживания вершин в очереди
    int parent[n] = { -1 };  // Массив для отслеживания переходов между вершинами

    fill(visitedVertex, visitedVertex + n, false);
    q.push(start); 
    inqueue[start] = visitedVertex[start] = true;  

    while (!q.empty()) { 
        int view_cell = q.front();  
        q.pop();  

        // Проходим по всем соседям вершины
        for (int i = 0; i < n; i++) {
            if (!inqueue[i] && graph[view_cell][i]) {
                q.push(i);  
                inqueue[i] = true;  
                visitedVertex[i] = true; 
                parent[i] = view_cell;  

              
                cout << "Переход: " << view_cell + 1 << " -> " << i + 1 << endl;
            }
        }
    }
}

int main() {
    setlocale(LC_ALL, "RUS"); 
    int start;

    // Вывод матрицы смежности графа
    cout << "Матрица смежности графа: " << endl;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            cout << " " << graph[i][j]; 
        }
        cout << endl;
    }

    // Список рёбер
    cout << "\n-----------------------------" << endl;
    cout << "\nСписок рёбер: " << endl;
    int arr_1[11] = { 1,1,2,2,3,4,4,5,6,7,9 };
    int arr_2[11] = { 2,5,7,8,8,6,9,6,9,8,10 };

    for (int i = 0; i <= n; i++)
    {
        cout << '{' << arr_1[i] << ", " << arr_2[i] << '}' << endl;
    }

    // Список смежности
    cout << "\n-----------------------------" << endl;
    cout << "\nСписок смежности: " << endl;
    int arrEdges[10][10] =
    {
        {2, 5},
        {7, 8},
        {8},
        {6, 9},
        {1, 6},
        {4, 5, 9},
        {2, 8},
        {2, 3, 7},
        {4, 6, 10},
        {9}
    };

    for (int i = 0; i < n; i++)
    {
        cout << i + 1 << "->";

        for (int j = 0; j < n; j++)
        {
            if (arrEdges[i][j] == 0)
            {
                break;
            }
            cout << arrEdges[i][j] << " ";
        }
        cout << endl;
    }
    cout << endl;


    // Поиск в глубину через стек
    cout << "\nПоиск в глубину через стек" << endl;
    cout << "Стартовая вершина >> ";
    cin >> start;  
    cout << "Цепочка переходов в глубину: " << endl;
    DFS(start - 1);

    // Поиск в ширину с выводом переходов
    cout << "\nПоиск в ширину" << endl;
    int start_2;  
    cout << "Стартовая вершина >> ";
    cin >> start_2; 
    cout << "Цепочка переходов в ширину: " << endl;
    BFS(start_2 - 1);  

    delete[] visitedVertex;  
    cout << endl;

    return 0;  
}
