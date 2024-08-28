using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioClip carolinaCarolBela;
    [SerializeField]public AudioSource audiosource;
    public Player player;
    void Start()
    {
        audiosource.clip = carolinaCarolBela;
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
