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







배열, 컬렉션, 인덱서

배열 : 
동시발사 탄환 수량제한(오브젝트풀 패턴) (확정)
소환사 스킬 구현...? (동시에 소환수 4마리 넘으면 안된다던가..)

컬렉션
Stack - 유희왕 체인 개념
Queue - 스타 건물에서 유닛 생산할때

인덱서
- 인벤토리 (확정)
- 공격 쿨타임 제한







class UnitA
{
    public float Hp;
    public float MoveSpeed;
    public float CreateTime = 20f;
}

class UnitB
{
    public float Hp;
    public float MoveSpeed;
    public float CreateTime = 30f;
}

class Factory
{
    Queue<GameObject> FactoryCreateUnit = new Queue<GameObject>();
    public float GetTime = 0f;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            AddCreateUnit(UnitA);
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            AddCreateUnit(UnitB);
        }

        UnitProduct();
    }

    public void AddCreateUnit(GameObject unit)
    {
        FactoryCreateUnit.Enqueue(unit);
    }

    public void UnitProduct()
    {
        if(FactoryCreateUnit.Count != 0)
        {
            GetTime += Time.deltaTime;
            if(FactoryCreateUnit.Peek().CreateTime <= GetTime)
            {
                FactoryCreateUnit.Dequeue;
                GetTime = 0f;
            }
        }
    }
}


