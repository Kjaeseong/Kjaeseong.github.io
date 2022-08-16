class Item
{
    public string Name{get;set;}
    public int Count{get;set;}
    public string Effect{get;set;}
​
    public override string ToString()
    {
        return string.Format("(아이템 이름 : {0}, 소지개수 : {1}개, 효과 : {2})", Name, Count, Effect);
    }
}

class ItemList
{
    private Item[] arr;
    public ItemList(int value)
    {
        arr = new Item[value];
    }
​
    public Item this[int index]
    {
        get
        {
            return arr[index];
        }
        set
        {
            if(index >= arr.Length)
            {
                Array.Resize<Item>(ref arr, index + 1);
            }
            arr[index] = value;
        }
    }
​
    public void Print()
    {
        Array.ForEach<Item>(arr, (x) => Console.WriteLine(x));
    }
}

class MainApp
{
    static void Main()
    {
        ItemList itemList = new ItemList(3);
        itemList[0] = new Item()
        {
            Name = "HP 포션",
            Count = 10,
            Effect = "체력을 채워준다."
        };
​
        itemList[1] = new Item()
        {
            Name = "MP 포션",
            Count = 8,
            Effect = "마나를 채워준다."
        };
​
        itemList[2] = new Item()
        {
            Name = "분노 포션",
            Count = 3,
            Effect = "일정 시간동안 공격력을 증가시킨다."
        };
​
        itemList.Print();
    }
}
// 결과
//(아이템 이름 : HP포션, 소지 개수 : 10개, 효과 : 체력을 채워준다.)
//(아이템 이름 : MP포션, 소지 개수 : 8개, 효과 : 마나를 채워준다.)
//(아이템 이름 : 분노 포션, 소지 개수 : 3개, 효과 : 일정 시간동안 공격력을 증가시킨다.)
