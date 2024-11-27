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
        player = FindObjectOfType<Player>().gameObject;
        playerCam = FindObjectOfType<CinemachineVirtualCamera>();
        playerCam.Follow = player.transform;
        playerCam.LookAt = player.transform;
        initialZoomValue = playerCam.m_Lens.OrthographicSize;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCam.Follow = lockCam.transform;
            playerCam.LookAt = lockCam.transform;
            if(SceneManager.GetActiveScene().name == "Favela")
            {
                playerCam.m_Lens.OrthographicSize = 4.5f;
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
