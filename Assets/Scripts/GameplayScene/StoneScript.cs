using UnityEngine;

public class StoneScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lava"))
            Destroy(gameObject);
    }
}
