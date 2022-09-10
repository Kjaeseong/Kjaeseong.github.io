#include <iostream>
using namespace std;

int main()
{
    int Index;
    int Max = 0;

    for(int i = 1; i <= 9; i++)
    {
        int num;
        cin >> num;

        if(num > Max)
        {
            Max = num;
            Index = i;
        }
    }

    cout << Max << "\n" << Index;
}