using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ÁrvoreStartCutscene : MonoBehaviour
{
    [SerializeField] private GameObject interactionE;
    [SerializeField] private Animator blackScreen;
    bool colidindo;
    void Start()
    {
        interactionE.SetActive(false);
    }
    private void Update()
    {
        if (colidindo)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(blackScreenStart());
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionE.SetActive(true);
            colidindo = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionE.SetActive(false);
            colidindo = false;
        }
    }
    IEnumerator blackScreenStart()
    {
        blackScreen.SetTrigger("Ativar");
        yield return new WaitForSeconds(2.25f);
        SceneManager.LoadScene("CutsceneFinal");
    }
}
