using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetScene : MonoBehaviour
{
    [SerializeField] RoundsController roundsController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
