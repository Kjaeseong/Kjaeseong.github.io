#include <iostream>
using namespace std;

int main()
{
    int StartNum;
    int x;
    int Count = 0;

    cin >> StartNum;

    x = StartNum;
    do
    {
        x = (x % 10 * 10) + ((x % 10 + x / 10) % 10);
        Count++;
    } while (x != StartNum);

    cout << Count;
}