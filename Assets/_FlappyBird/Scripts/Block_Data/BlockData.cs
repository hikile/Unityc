using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Block Data",menuName = "Data/Block Data")] 

public class BlockData : ScriptableObject
{
    // Start is called before the first frame updat
    public List<BlockSprite> listblockSprite;
    
}
[Serializable]
public class BlockSprite
{
    public BlockTyper BlockTyper;
    public SpriteInfos SpriteInfos;
    
}
[Serializable]
public class SpriteInfos
{
    public List<Sprite> listBlockSprite;
    public float maxHp;
}

public enum BlockTyper // dsach lke
{
    Wood =0,
    Stone = 1,
    Metal =2
}