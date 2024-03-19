using System;
using UnityEditor;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public int skinNr;
    public Skins[] skins;
    public SpriteRenderer SpriteRenderer;
    public GameObject x;
    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        SkinChoice();
    }

    void SkinChoice()
    {
        if (SpriteRenderer.sprite.name.Contains("frame"))
        {
            string spriteName = SpriteRenderer.sprite.name;
            spriteName = spriteName.Replace("frame-", "");
            int spriteNr = int.Parse(spriteName);

            SpriteRenderer.sprite = skins[skinNr].Sprites[spriteNr];
        }
    }

    public void backButton()
    {
        skinNr--;
        if (skinNr < 0)
        {
            skinNr = 3;
        }
    }

    public void nextButton()
    {
        skinNr++;
        if (skinNr > 3)
        {
            skinNr = 0;
        }
    }
    
    void st()
    {
        if (x != null)
        {
           // PrefabUtility.SavePrefabAsset(x,"");
            
        }
        else
        {
            Debug.LogWarning("No GameObject selected!");
        }
    }

    [Serializable]
    public struct Skins
    {
        public Sprite[] Sprites;
    }
}
