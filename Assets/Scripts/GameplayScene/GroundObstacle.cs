using UnityEngine;

public class GroundObstacle : MonoBehaviour
{
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
