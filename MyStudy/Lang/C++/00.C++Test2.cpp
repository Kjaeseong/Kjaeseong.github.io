#include <iostream>
using namespace std;

int main()
{
  int Total;
  int N;

  cin >> Total;
  cin >> N;

  for(int i = 0; i < N; i++)
  {
    int Cost;
    int Quantity;
    cin >> Cost;
    cin >> Quantity;

    Total -= Cost * Quantity;
  }

  if(Total == 0)
  {
    cout << "Yes";
  }
  else
  {
    cout << "No";
  }
}