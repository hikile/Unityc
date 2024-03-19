using GameTool;
using UnityEngine;

public class Block : BasePooling
{
    // Start is called before the first frame update
    public BlockTyper blockTyper;
    public eSoundName sound;
    private float maxHP;
    public float curHp;
    private SpriteRenderer sr;
    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        Disable(10f);
    }

    public void SetData()
    {
        maxHP = GameData.Instance.blockData.listblockSprite[(int)blockTyper].SpriteInfos.maxHp;
        curHp = maxHP;
        sr.sprite = GameData.Instance.blockData.listblockSprite[(int)blockTyper].SpriteInfos.listBlockSprite[2];
        SetShortSFX();
    }
  

    public void takeDamage(float damages)
    {
        curHp -= damages;
        setSprite();
        AudioManager.Instance.Shot(sound);
    }

    public void setSprite()
    {
        if (curHp / maxHP <= 2f / 3 && curHp/maxHP > 1f/3)
        {
            sr.sprite = GameData.Instance.blockData.listblockSprite[(int)blockTyper].SpriteInfos.listBlockSprite[1];
        }
        else if (curHp / maxHP <= 1f / 3 && curHp/maxHP >=0f)
        {
            sr.sprite = GameData.Instance.blockData.listblockSprite[(int)blockTyper].SpriteInfos.listBlockSprite[0];
        }

        if (curHp <= 0)
        {
            GameMenu.Instance.UpdateScore((int)(blockTyper) +1);
            Disable();
        }
    }

    public void SetShortSFX()
    {
        if (blockTyper == BlockTyper.Wood)
        {
            sound = eSoundName.Wood_Sound;
        }  
        else if (blockTyper == BlockTyper.Stone)
        {
            sound = eSoundName.Stone_Sound;

        }
        else
        {
            sound = eSoundName.Metal_Sound;

        }
    }
}
