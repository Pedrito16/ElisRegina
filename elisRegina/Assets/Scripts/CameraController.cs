using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject lockCam;
    [SerializeField] GameObject player;
    [SerializeField] CinemachineVirtualCamera playerCam;
    void Start()
    {
        lockCam = gameObject;
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
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCam.Follow = player.transform;
            playerCam.LookAt = player.transform;
        }
    }
}
