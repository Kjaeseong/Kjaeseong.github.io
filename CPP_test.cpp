#include <iostream>
using namespace std;

int main()
{
    int arr[42] = { 0 };
    int Count = 0;

    for(int i = 0; i < 10; i++)
    {
        int Input;
        cin >> Input;

        int Index = Input % 42;
        arr[Index]++;

        if(arr[Index] == 1)
        {
            Count++;
        }
    }

    cout << Count;
}