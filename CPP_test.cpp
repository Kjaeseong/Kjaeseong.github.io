#include <iostream>
using namespace std;

int main()
{
    int Testcase;
    cin >> Testcase;

    for(int i = 0; i < Testcase; i++)
    {
        int Students;
        cin >> Students;

        int Score[1000];
        float Average = 0;
        for(int j = 0; j < Students; j++)
        {
            cin >> Score[j];
            Average += Score[j];
        }
        Average /= Students;

        int Count = 0;
        for(int j = 0; j < Students; j++)
        {
            if(Score[j] > Average)
            {
                Count++;
            }
        }
    
        cout << (float)(Count / Students) * 100 << "\n";
    }




}