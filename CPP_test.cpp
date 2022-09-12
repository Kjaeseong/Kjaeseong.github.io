#include <iostream>
using namespace std;

int main()
{
    int arr[1000] = { 0 };
    int Max = 0;
    float result = 0;
    
    int Subject;
    cin >> Subject;

    for(int i = 0; i < Subject; i++)
    {
        cin >> arr[i];

        if(arr[i] > Max)
        {
            Max = arr[i];
        }
    }

    for(int i = 0; i < Subject; i++)
    {
        result += (float)arr[i] / Max * 100;
    }

    cout << result / Subject;
}