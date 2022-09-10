#include <iostream>
using namespace std;

int main()
{
    int Dice[3];
    int Count = 1;
    int SameNum;
    int MaxNum = 0;

    for(int i = 0; i < 3; i++)
    {
        cin >> Dice[i];    
        if(Dice[i] > MaxNum)
        {
            MaxNum = Dice[i];
        }
    }

    if(Dice[0] == Dice[1])
    {
        Count++;
        SameNum = Dice[0];
    }
    if(Dice[0] == Dice[2])
    {
        Count++;
        SameNum = Dice[0];
    }
    if(Count <= 1 && Dice[1] == Dice[2])
    {
        Count++;
        SameNum = Dice[1];
    }

    int print = 0;
    switch(Count)
    {
        case 3:
            print = (SameNum * 1000) + 10000;
            break;
        case 2:
            print = (SameNum * 100) + 1000;
            break;
        default:
            print = MaxNum * 100;
            break;
    }
    cout << print;
}