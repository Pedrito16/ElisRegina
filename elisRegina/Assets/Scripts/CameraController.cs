using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject lockCam;
    [SerializeField] GameObject player;
    [SerializeField] CinemachineVirtualCamera playerCam;
    float initialZoomValue;
    void Start()
    {
        lockCam = gameObject;
        player = GameObject.FindWithTag("Player");
        playerCam.Follow = player.transform;
        playerCam.LookAt = player.transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCam = FindObjectOfType<CinemachineVirtualCamera>();
            print("colidindo camera");
            playerCam.Follow = lockCam.transform;
            playerCam.LookAt = lockCam.transform;
            if(SceneManager.GetActiveScene().name == "Favela")
            {
                playerCam.m_Lens.OrthographicSize = 11.5f;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCam.Follow = player.transform;
            playerCam.LookAt = player.transform;
            if(SceneManager.GetActiveScene().name == "Favela")
            {
                playerCam.m_Lens.OrthographicSize = initialZoomValue;
            }
        }
    }
}
