using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float velociadeDoCenario;

    void Update()
    {
        MovimentarCenario();
    }
    void MovimentarCenario()
    {
        Vector2 deslocamento = new Vector2(Time.time * velociadeDoCenario, 0);
      
    }
}
