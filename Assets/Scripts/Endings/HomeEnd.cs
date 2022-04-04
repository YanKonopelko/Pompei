using UnityEngine;

public class HomeEnd : MonoBehaviour
{
    [SerializeField] private GameObject _homeEndCanvas;
    private bool isHere = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _homeEndCanvas.SetActive(true);
            isHere = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _homeEndCanvas.SetActive(false);
        isHere = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isHere)
        {
            ManageEnd.DoEnd(2);
        }
        

    }
}
