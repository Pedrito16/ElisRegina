using UnityEngine;
using UnityEngine.SceneManagement;

public class LuzColission : MonoBehaviour
{
    [SerializeField] GameObject luz, strongerLuz, interactionW;
    [SerializeField] Animator trianguloAnim;
    bool colidindo;
    void Start()
    {
        interactionW.SetActive(false);
    }
    void Update()
    {
        if(colidindo)
        {
            if(Input.GetKeyDown(KeyCode.W)) 
            {
                Powers.canChangeLocation = true;
                Powers.lastLocationSalva = false;
                SceneManager.LoadScene("City");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            trianguloAnim.SetBool("Colidindo", true);
            strongerLuz.SetActive(true);
            luz.SetActive(false);
            interactionW.SetActive(true);
            colidindo = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            strongerLuz.SetActive(false);
            trianguloAnim.SetBool("Colidindo", false);
            luz.SetActive(true);
            interactionW.SetActive(false);
            colidindo = false;  
        }
    }
}
