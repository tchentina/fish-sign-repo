using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float spriteHeight;
    public Transform[] backgrounds;

    void Update()
    {
        foreach (Transform bg in backgrounds)
        {
            bg.position += Vector3.down * scrollSpeed * Time.deltaTime;

            if (bg.position.y <= -spriteHeight)
            {
                bg.position += Vector3.up * spriteHeight * 2;
            }
        }
    }
}
