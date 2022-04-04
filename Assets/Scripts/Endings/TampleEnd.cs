using UnityEngine;

public class TampleEnd : MonoBehaviour
{
    [SerializeField] private GameObject _tampleEndCanvas;
    private bool isHere = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _tampleEndCanvas.SetActive(true);
            isHere = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _tampleEndCanvas.SetActive(false);
            isHere = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isHere)
        {
            ManageEnd.DoEnd(3);
        }
        

    }
}
