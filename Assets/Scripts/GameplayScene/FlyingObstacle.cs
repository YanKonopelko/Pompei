using UnityEngine;

public class FlyingObstacle : MonoBehaviour
{
    public float _movespeed = 2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerController>()._moveSpeed = 2f;
        }
        if (collision.CompareTag("Lava"))
        {
            Destroy(gameObject);
        }
    }
}
