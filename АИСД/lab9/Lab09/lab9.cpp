#include <iostream>
#include <vector>
#include <algorithm>
#include <limits.h>
#include <Windows.h>
#include <time.h>

using namespace std;

int V = 5;
#define GENES ABCDE
#define START 0

int child = 0;
int populationSize = 0;
int evoCount = 0;
double mutationChance = 0;

typedef vector<vector<int>> Matrix;
Matrix cities = {
	{ INT_MAX, 25, 40, 31, 27 },
	{ 25, INT_MAX, 14, 19, 25 },
	{ 12, 17, INT_MAX, 5, 1 },
	{ 31, 30, 6, INT_MAX, 6 },
	{ 12, 36, 1, 6, INT_MAX }
};


struct marshrut {
	string path;
	int lenght;
};

int rand_num(int start, int end)
{
	int r = end - start;
	int rnum = start + rand() % r;
	return rnum;
}

bool contains(string s, char ch)
{
	for (int i = 0; i < s.size(); i++) {
		if (s[i] == ch)
			return true;
	}
	return false;
}

string mutatedGene(string path)
{
	while (true) {
		int r = rand_num(1, V);
		int r1 = rand_num(1, V);
		if (r1 != r) {
			char temp = path[r];
			path[r] = path[r1];
			path[r1] = temp;
			break;
		}
	}
	return path;
}



string create_path()
{
	string path = "0";
	while (true) {
		if (path.size() == V) {
			path += path[0];
			break;
		}
		int temp = rand_num(1, V);
		if (!contains(path, (char)(temp + 48)))
			path += (char)(temp + 48);
	}
	return path;
}

int calculate_lenght(string path)
{

	int f = 0;
	for (int i = 0; i < path.size() - 1; i++) {
		if (cities[path[i] - 48][path[i + 1] - 48] == INT_MAX)
			return INT_MAX;
		f += cities[path[i] - 48][path[i + 1] - 48];
	}
	return f;
}

bool lessthan(struct marshrut t1,
	struct marshrut t2)
{
	return t1.lenght < t2.lenght;
}

marshrut childGene(marshrut dad, marshrut mom)
{
	marshrut child;
	int r = rand_num(1, V);
	child.path = dad.path.substr(0, r);
	string mom_path = mom.path.substr(r + 1);
	for (char ch : mom_path)
	{
		if (!contains(child.path, ch)) {
			child.path += ch;
		}
	}


	if (child.path.size() != V) {
		for (int i = r; i < dad.path.size(); i++) {
			if (!contains(child.path, dad.path[i])) {
				child.path += dad.path[i];
			}
		}
	}

	child.path += child.path[0];
	child.lenght = calculate_lenght(child.path);
	return child;
}

void addCity() {
	vector<int> newDistances(V, INT_MAX);
	vector<int> newDistances2(V, INT_MAX);


	for (int i = 0; i < V; ++i) {
		cout << "���������� � ������ " << i + 1 << " : ";
		cin >> newDistances[i];
	}
	for (int i = 0; i < V; ++i) {
		cout << "���������� �� ������ " << i + 1 << " : ";
		cin >> newDistances2[i];
	}
	for (int i = 0; i < V; ++i) {
		cities[i].push_back(newDistances2[i]);
	}

	newDistances.push_back(INT_MAX);
	cities.push_back(newDistances);
	V++;
}

void deleteCity(int cityIndex) {

	for (int i = 0; i < V; ++i) {
		cities[i].erase(cities[i].begin() + cityIndex);
	}
	cities.erase(cities.begin() + cityIndex);

	V--;
}

void print(Matrix matrix)
{
	for (auto i : matrix)
	{
		for (auto el : i)
		{
			if (el != INT_MAX)cout << el << "\t";
			else cout << "INF" << "\t";
		}
		cout << endl;
	}
}



int main()
{
	setlocale(LC_ALL, "ru");
	srand(time(0));
	int input = 0;
	cout << "\n c�������� ������� �������: \n";
	print(cities);
	cout << endl;
	while (true) {

		cout << "1 - ������������� ������� �������\n";
		cout << "2 - ��������� ������������ ��������\n";
		cin >> input;
		switch (input) {
		case 1: {
			cout << "1 - �������� �����\n";
			cout << "2 - ������ �����\n";
			cin >> input;
			switch (input) {
			case 1: {

				addCity();
				cout << "\n ����� ������� �������: \n";
				print(cities);
				break;
			}
			case 2: {
				std::cout << "\n����� ���������� ������ (�� 1 �� " << V << "): \n";
				cin >> input;
				deleteCity(input - 1);
				cout << "\n ����� ������� �������: \n";
				print(cities);
				break;
			}
			}
			break;
		}
		case 2: {
			cout << "������ ���������: ";
			cin >> populationSize;
			cout << "����������� �������(� ���������,���������� ������): ";
			cin >> mutationChance;
			cout << "���������� ����������� � ����� ���������: ";
			cin >> child;
			cout << "���������� ��������: ";
			cin >> evoCount;

			int gen = 1;
			int mutated_counter = 0;

			vector<struct marshrut> population;
			struct marshrut temp;

			for (int i = 0; i < populationSize; i++) {
				temp.path = create_path();
				temp.lenght = calculate_lenght(temp.path);
				population.push_back(temp);
			}

			cout << "\n��������� ���������: " << endl;
			cout << "���� ��������� \t||����� ����\n";
			for (int i = 0; i < populationSize; i++)
				cout << population[i].path << "\t\t\t"
				<< population[i].lenght << endl;
			cout << "\n";


			sort(population.begin(), population.end(), lessthan);

			while (gen <= evoCount) {
				mutated_counter = 0;
				cout << endl << "������ ����: " << population[0].path;
				cout << " ��� �����: " << population[0].lenght << "\n\n";

				vector<struct marshrut> new_population;

				for (int i = 0; i < child; i++) {

					struct marshrut p1 = population[i];

					while (true)
					{
						int dad_id = rand_num(0, populationSize - 1);
						int mom_id = rand_num(0, populationSize - 1);
						if (dad_id != mom_id)
						{
							marshrut new_marshrut = childGene(population[dad_id], population[mom_id]);

							new_population.push_back(new_marshrut);
							new_marshrut = childGene(population[mom_id], population[dad_id]);
							new_population.push_back(new_marshrut);
							break;
						}
					}
				}

				for (int i = 0; i < populationSize - 1; i++) {

					struct marshrut p1 = population[i];

					if (rand_num(0, 100) < mutationChance) {
						mutated_counter++;
						while (true)
						{
							string new_path = mutatedGene(p1.path);
							struct marshrut new_marshrut;
							new_marshrut.path = new_path;
							new_marshrut.lenght = calculate_lenght(new_marshrut.path);

							if (new_marshrut.lenght <= population[i].lenght) {
								new_population.push_back(new_marshrut);
								break;
							}
							else {
								new_marshrut.lenght = INT_MAX;
								new_population.push_back(new_marshrut);
								break;
							}
						}
					}
				}

				for (int i = 0; i < child + mutated_counter; i++)
				{
					population.push_back(new_population[i]);
				}
				sort(population.begin(), population.end(), lessthan);

				for (int i = 0; i < child + mutated_counter; i++)
				{
					population.pop_back();
				}

				cout << "��������� " << gen << " \n";
				cout << "���� ��������� \t||����� ����\n";

				for (int i = 0; i < populationSize; i++)
					cout << population[i].path << "\t\t\t"
					<< population[i].lenght << endl;
				gen++;
			}
			cout << "\n\n�������� ����������� �������: ";
			cout << population[0].path;
			cout << "\n\n";
			return 0;
		}
		}
	}
}