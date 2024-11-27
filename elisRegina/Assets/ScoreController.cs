using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI comentarioText;
    [SerializeField] string[] comentarios;
    void Start()
    {
        scoreText.text = "Seu tempo: " + Timer.timeMinutesPlayed.ToString("D2") + ":" + Timer.timeSecondsPlayed.ToString("D2");
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.timeMinutesPlayed >= 12)
        {
            comentarioText.text = comentarios[2];
            comentarioText.color = Color.yellow;
        }
        else if(Timer.timeMinutesPlayed >= 8)
        {
            comentarioText.text = comentarios[1];
            comentarioText.color = Color.yellow;
        }
        else if(Timer.timeMinutesPlayed <= 5)
        {
            comentarioText.text = comentarios[0];
            comentarioText.color = Color.green;
        }
    }
    public void VoltarBTN()
    {
        SceneManager.LoadScene("MenuScene");
        Timer.timeMinutesPlayed = 0;
        Timer.timePlayed = 0;
        Timer.timeSecondsPlayed = 0;
    }
}
