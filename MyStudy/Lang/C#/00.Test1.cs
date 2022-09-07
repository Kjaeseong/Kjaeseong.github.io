//클라이언트

public class Player
{
    public int Damage = 10;
    public int HP { get; private set; } = 100;

    public PhotonView photonView;


    // 플레이어의 HP를 볼 수 있는 UI
    public Animator HpSlider; 
    
    // 플레이어의 애니메이터
    // TakenDamage 라는 Trigger 타입의 파라미터 있음.
    private Animator _animator;
    private bool _attack;

    private void Start() 
    {
        GetPhoton();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Enemy")
        {
            TakeDamage(Damage);
        }
    }

    void Update()
    {
        InputKey();
    }

    [PunRPC]
    public void Attack()
    {

    }

    [PunRPC]
    public void TakeDamage(int damage)
    {

    }

    private void GetPhoton()
    {
        photonView = photonView.Get(this);
    }

    private bool InputKey()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            return true; 
        } 
        else {
            return false; 
        }
    }
}