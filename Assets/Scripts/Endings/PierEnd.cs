using UnityEngine;

public class PierEnd : MonoBehaviour
{
    [SerializeField] private GameObject _pierEndCanvas;
    private bool isHere = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _pierEndCanvas.SetActive(true);
            isHere = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _pierEndCanvas.SetActive(false);
            isHere = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isHere)
        {
            ManageEnd.DoEnd(1);
        }
        

    }
}
