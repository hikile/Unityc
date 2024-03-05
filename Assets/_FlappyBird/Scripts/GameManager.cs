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
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            PoolingManager.Instance.GetObject(NamePrefabPool.Wall,position: new Vector3(6f,0f,0f)).Disable(10);
            cooldown = timeShoot;
        }

    }

    
}
