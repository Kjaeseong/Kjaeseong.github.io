#include <iostream>
using namespace std;

int main()
{
    int testcase;
    cin >> testcase;

    for(int i = 0; i < testcase; i++)
    {
        int a, b;
        cin >> a;
        cin >> b;

        cout << a + b << endl;
    }
}