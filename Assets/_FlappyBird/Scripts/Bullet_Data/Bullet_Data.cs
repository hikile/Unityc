using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;
[CreateAssetMenu(fileName = "BulletData",menuName = "Data / Bullet Data")]
public class Bullet_Data : ScriptableObject
{
    public List<BulletInfo> BulletInfos;
}

[Serializable]
public class BulletInfo
{
    public float Damage;
    public Sprite sprite;
}