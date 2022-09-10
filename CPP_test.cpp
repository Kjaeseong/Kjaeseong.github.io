#include <iostream>
using namespace std;

int main()
{
    int Testcase;
    cin >> Testcase;

    for(int i = 1; i <= Testcase; i++)
    {
        int a, b;
        cin >> a >> b;

        cout << "Case #" << i << ": " << a + b << endl;
    }
}