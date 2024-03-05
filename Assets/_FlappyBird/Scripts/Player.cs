using GameTool;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private float jumpForce = 10f;
    public float cooldown;
    public float timesShoot = 0.4f;
    public float boundTop = 4.33f;
    public float boundBottom = -4.33f;

    public GameObject prefabs;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic(eMusicName.Game);
        rb = GetComponent<Rigidbody2D>();
        //rh.AddForce(new Vector2(0,1000));// bay lên từ từ vẫn chịu tác dụng của lục hấp dẫn
       // rh.velocity = new Vector2(0, 16); // giả vật lí 
       // gravity scale // lực hấp dẫn
       
       // điều kiện để xảy ra va chạm:
       //1: cả 2 phải có collider
       //2: ít nhất 1 thằng phải có rigidbody
       
       // hình ảnh:- Hiện lên (GUI) +> Image
       //           -Không hiện lên canias +> SpriteREnder
       /*
        * Sorting layer:
        * Order in layer:
        * cái nào co sorting layer cao hơn thì đè lên cái thấp hơn
        * nếu 2 cái cùng sorting layer cái nào có order in layer cap hơn thì đè lên cái kia
        * còn bằng nhau thì roamdom
        */
       cooldown = timesShoot;
    }

    // Update is called once per frame
    // pooling manager
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space))
        {
            AudioManager.Instance.Shot(eSoundName.Jump_Sound);
            rb.velocity = new Vector2(0, jumpForce);
            
        }
        var transform1 = transform;
        if (transform.position.y >= boundTop)
        {
            transform1.position = new Vector2(transform1.position.x, boundTop);
        }

        if (transform.position.y <= boundBottom)
        {
            transform1.position = new Vector2(transform.position.x, boundBottom);
        }
        
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            PoolingManager.Instance.GetObject(NamePrefabPool.Bullet,position:transform.position).Disable(1.5f);
            cooldown = timesShoot;
        }
       

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            
        }
    }
    
}
