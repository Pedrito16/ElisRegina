using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCam;
    public float initialZoomValue;
    // Start is called before the first frame update
    void Start()
    {
        initialZoomValue = cinemachineCam.m_Lens.OrthographicSize;
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cinemachineCam.m_Lens.OrthographicSize = 10;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cinemachineCam.m_Lens.OrthographicSize = initialZoomValue;
        }
    }
}
