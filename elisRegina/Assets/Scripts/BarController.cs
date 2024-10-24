using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    [SerializeField] AudioSource barSource;
    void Start()
    {
        if(RodadasSystem.soundtrackTime != 0)
        {
            barSource.time = RodadasSystem.soundtrackTime;
        }
    }
    void Update()
    {
        RodadasSystem.soundtrackTime = barSource.time;
    }
}