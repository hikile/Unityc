using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private float jumpForce = 20f;
    public float cooldown;
    public float timesShoot = 0.5f;

    public GameObject prefabs;
    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(0, jumpForce);
        }
        
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            PoolingManager.Instance.GetObject(NamePrefabPool.Bullet,position:transform.position).Disable(1);
            cooldown = timesShoot;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            Debug.Log("Collided with Square");

        }
        
    }
}
