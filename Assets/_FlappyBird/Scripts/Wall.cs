
using GameTool;
using UnityEngine;


public class Wall : BasePooling
{
    // Start is called before the first frame updateo
    public float size;
    private float speed = 5f;
    private float[] posY = new float[4];
    private float[] height = new float[4];
    private void OnEnable()
    {
        if (Camera.main != null) size = Camera.main.orthographicSize;
        createBlock();
    }

    private void createBlock()
    {
        height[0] = Random.Range(1, 4);
        height[1] = size - height[0];
        height[2] = Random.Range(1, 4);
        height[3] = size - height[2];

        posY[0] = size - height[0] / 2;
        posY[1] = height[1] / 2;
        posY[2] = -height[2] / 2;
        posY[3] = -size + height[3] / 2;

        for (int i = 0; i < 4; i++)
        {
             BlockTyper blockTyper =(BlockTyper) Random.Range(0, 3);

             var transform1 = transform;
             var position = transform1.position;
            var block = (Block)PoolingManager.Instance.GetObject(NamePrefabPool.Block, transform1, new Vector3(position.x, posY[i], position.z));

            block.blockTyper = blockTyper; // thay doi thong so cua tuong
            block.SetData();
            SpriteRenderer sr = block.gameObject.GetComponent<SpriteRenderer>();
            sr.size = new Vector2(1, height[i]);
            BoxCollider2D boxCollider2D = block.gameObject.GetComponent<BoxCollider2D>();
            boxCollider2D.offset = Vector2.zero;
            boxCollider2D.size = sr.size;
        }
    }

    private void Update()
    {
        var position = transform.position;
        transform.Translate(new Vector3(-speed*Time.deltaTime,position.y,position.z));
    }
}