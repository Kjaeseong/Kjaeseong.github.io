#include <iostream>
using namespace std;

int main()
{
    int n;
    cin >> n;
    int StartNum = n;

    if(n < 10)
    {
        n *= 10;
    }
    
    for(int i = 0; i >= 0; i++)
    {
        if(i != 0 && n == StartNum)
        {
            cout << i;
            break;
        }

        int a = (n % 10) * 10;
        int b = ((n / 10) + (n % 10)) % 10;
        n = a + b;
    }
}

// 1110