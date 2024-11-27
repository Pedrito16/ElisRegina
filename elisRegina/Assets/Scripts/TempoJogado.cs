using UnityEngine;
using TMPro;

public class TempoJogado : MonoBehaviour
{
    [SerializeField] TMP_Text contador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Timer.timePlayed >= 1f)
        {
            Timer.timeSecondsPlayed++;
            Timer.timePlayed = 0f;
        }
        UpdateTime();
        if (!PauseClass.Paused)
        {
            Timer.timePlayed += Time.deltaTime;
            if(Timer.timeSecondsPlayed >= 60)
            {
                Timer.timeMinutesPlayed += Timer.timeSecondsPlayed / 60;
                Timer.timeSecondsPlayed = 0;
            }
        }else if(PauseClass.Paused) 
        { 
         print(Timer.timePlayed.ToString());
        }
    }
    void UpdateTime()
    {
        contador.text = "Tempo De Jogo: " + Timer.timeMinutesPlayed.ToString("D2") + ":" + Timer.timeSecondsPlayed.ToString("D2");
    }
}
public static class Timer
{
    public static float timePlayed;
    public static int timeSecondsPlayed;
    public static int timeMinutesPlayed;
}
