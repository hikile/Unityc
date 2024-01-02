using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rh;

    private float jumpForce = 4;
    // Start is called before the first frame update
    void Start()
    {
        rh = GetComponent<Rigidbody2D>();
        rh.AddForce(new Vector2(0,1000));// bay lên từ từ vẫn chịu tác dụng của lục hấp dẫn
       // rh.velocity = new Vector2(0, 16); // giả vật lí 
       // gravity scale // lực hấp dẫn
       
       // điều kiện để xảy ra va chạm:
       //1: cả 2 phải có collider
       //2: ít nhất 1 thằng phải có rigidbody
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(0))
        {
            rh.velocity = new Vector2(0, jumpForce);
        }
    }
}
