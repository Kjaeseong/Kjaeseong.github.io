#include <iostream>
#include <string>
using namespace std;

int main()
{
    int Testcase;
    cin >> Testcase;

    for(int i = 0; i < Testcase; i++)
    {
        string ox;
        cin >> ox;

        int Score = 0;
        int Count = 1;
        for(int j = 0; j < ox.size(); j++)
        {
            if(ox[j] == 'O')
            {
                Score += Count;
                Count++;
            }
            else
            {
                Count = 1;
            }
        }

        cout << Score << "\n";
    }
}