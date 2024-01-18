using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float cooldown;
    private float timeShoot = 5f;
    void Start()
    {
        cooldown = timeShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0)
        {
            cooldown = timeShoot;
            PoolingManager.Instance.GetObject(NamePrefabPool.Wall, null, new Vector3(5f, 0f, 0f)).Disable(10f);
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
