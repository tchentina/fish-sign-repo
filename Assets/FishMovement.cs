using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 1f;
    public float changeInterval = 5f;

    private Vector3 direction;
    private SpriteRenderer spriteRenderer;
    private float timer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        PickNewDirection();
        float scaleMultiplier = Random.Range(1f, 2f);
        transform.localScale *= scaleMultiplier;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            speed = Random.Range(0.5f, 1.5f);
            PickNewDirection();
            timer = 0f;
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }

    void PickNewDirection()
    {

        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        spriteRenderer.flipX = direction.x > 0;

    }
}