using UnityEngine;

public class MudScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerController>()._moveSpeed = 4.2f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Lava"))
        {
            Destroy(gameObject);
        }
    }
}
