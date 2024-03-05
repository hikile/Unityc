using System;
using System.ComponentModel;
using GameTool;
using UnityEngine;

public class Bullet : BasePooling
{
    public float speed = 7;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public float damage;

    private void OnEnable()
    {
        int score = GameData.Instance.score;
        int index = score / 10;
        if (index >= GameData.Instance.bulletData.BulletInfos.Count)
        {
            index = GameData.Instance.bulletData.BulletInfos.Count - 1;
        }
        sr.sprite = GameData.Instance.bulletData.BulletInfos[index].sprite;
        damage = GameData.Instance.bulletData.BulletInfos[index].Damage;
        rb.velocity = new Vector2(speed, 0);
    }

    public void Update_Bullet()
    {
        int score = GameData.Instance.score;
        int index = score / 10;
        if (index >= GameData.Instance.bulletData.BulletInfos.Count)
        {
            index = GameData.Instance.bulletData.BulletInfos.Count - 1;
        }
        sr.sprite = GameData.Instance.bulletData.BulletInfos[index].sprite;
        damage = GameData.Instance.bulletData.BulletInfos[index].Damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            var block = other.gameObject.GetComponent<Block>();
            block.takeDamage(0.75f);
            Debug.Log(damage);
            //Debug.Log(block.curHp);*/
            Disable(0);
        }
    }
}
