using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public Sprite[] possibleSprites;

    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        if (possibleSprites == null || possibleSprites.Length == 0) return;

        int index = Random.Range(0, possibleSprites.Length);
        sr.sprite = possibleSprites[index];
    }
}