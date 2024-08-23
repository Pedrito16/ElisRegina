using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PassaFase : MonoBehaviour
{
    public string currentScene;
    public int currentSceneIndex;
    public int nextSceneIndex;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(currentSceneIndex != nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}
