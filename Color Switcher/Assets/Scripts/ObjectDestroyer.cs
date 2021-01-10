using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject menuPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cyan" || collision.tag == "Magenta" || collision.tag == "Pink" || collision.tag == "Yellow")
        {
            Destroy(collision.gameObject.transform.parent.transform.parent.gameObject);
        }
        if (collision.gameObject.name == "Player")
        {
            menuPanel.SetActive(true);
        }
    }
}
