using UnityEngine;
using UnityEngine.SceneManagement;

public class BarDeFora : MonoBehaviour
{
    [SerializeField] GameObject interactionW;
    bool colidindo;
    [SerializeField] Player player;
    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colidindo)
        {
            interactionW.SetActive(true);
            if(Input.GetKeyDown(KeyCode.W))
            {
                SceneManager.LoadScene("Bar");
                Powers.unlockPower = false;
                Powers.previousSavedLocation = player.GetComponent<Transform>().position;
                Powers.previousLocationSalva = true;
            }
        }
        else
        {
            interactionW.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            colidindo = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            colidindo = false;
        }
    }
}
