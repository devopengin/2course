#include <iostream>
#include <vector>
#include <string>
#include <algorithm>

using namespace std;


void findLIS(const vector<int>& arr)
{
	int n = arr.size();

	if (n == 0) {
		return;
	}

	vector<vector<int>> LIS(n, vector<int>{});

	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < i; j++)
		{
			if (arr[j] < arr[i] && LIS[j].size() > LIS[i].size())
			{
				LIS[i] = LIS[j];
			}
		}
		LIS[i].push_back(arr[i]);
	}

	sort(LIS.begin(), LIS.end(), [](const vector<int>& a, const vector<int>& b) {
		return a.size() > b.size() || (a.size() == b.size() && &a < &b);
		});

	cout << "\nДлина: " << LIS[0].size() << endl;

	cout << "Максимальная возрастающая подпоследовательность: ";
	for (int i : LIS[0]) {
		cout << i << " ";
	}
	cout << '\n';
}

int main()
{
	setlocale(LC_ALL, "rus");
	vector<int> arr;

	int n;
	cout << "Введите число элементов последовательности: ";
	scanf_s("%d", &n);
	printf_s("Введите %d элементов последовательности: ", n);

	int num;
	for (; n > 0; n--) {
		cin >> num;
		arr.push_back(num);
	}

	findLIS(arr);
	return 0;
}

