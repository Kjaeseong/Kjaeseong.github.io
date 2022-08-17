class PlayerDeck
{
    int[] MyDeck = new int[45];   
}

class Game
{
    int[] Player1_Hand = new int[7];

    private void Drawpase()
    {
        for(int i = 0; i < Player1_Hand.Length; i++)
        {
            if(Player1_Hand[i] == 0)
            {
                //패의 빈자리에 MyDeck의 랜덤한 카드를 옮겨온다.
                Playuer1_Hand[i] = MyDeck[Random.Range(0, MyDeck.Length)];
            }
        }
    }
}



