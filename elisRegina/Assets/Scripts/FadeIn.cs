using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    [SerializeField] Animator startAnimation;
    [SerializeField] string parameterName;
    
    void Start()
    {
        StartCoroutine(FadeOutCooldown());
    }
    IEnumerator FadeOutCooldown()
    {
        startAnimation.SetBool(parameterName, false);
        yield return new WaitForSeconds(1f);
        startAnimation.SetBool(parameterName, true);
        
    }
}
