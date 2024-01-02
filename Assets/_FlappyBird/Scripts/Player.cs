using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rh;

    private float jumpForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rh = GetComponent<Rigidbody2D>();
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rh.velocity = new Vector2(0, jumpForce);
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
