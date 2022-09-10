#include <iostream>
using namespace std;

int main()
{
    while(1)
    {
        int a, b;
        cin >> a;
        cin >> b;

        if(cin.eof())
        {
            break;
        }

        cout << a + b << endl;
    }
}