using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]private float startPosX;
    [SerializeField]private float resetPosX;
    [SerializeField]private float speed;
    void Start()
    {
        transform.position = new Vector3(startPosX, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-speed*Time.deltaTime , 0 ,0));
        if (Mathf.Abs(transform.position.x - resetPosX) <= 0.1f)
        {
            transform.position = new Vector3(startPosX, transform.position.y, transform.position.z);
        }
    }
}
