using UnityEngine;
using TMPro;

public class TempoJogado : MonoBehaviour
{
    [SerializeField] TMP_Text contador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.timePlayed >= 1f)
        {
            Timer.timeSecondsPlayed++;
            Timer.timePlayed = 0f;
        }
        if(!PauseClass.Paused)
        {
            Timer.timePlayed += Time.deltaTime;
            if(Timer.timeSecondsPlayed >= 60)
            {
                Timer.timeMinutesPlayed = Timer.timeSecondsPlayed / 60;
                Timer.timeSecondsPlayed = 0;
            }
            contador.text = Timer.timeMinutesPlayed.ToString();
        }else if(PauseClass.Paused) 
        { 
         print(Timer.timePlayed.ToString());
        }
    }
}
public static class Timer
{
    public static float timePlayed;
    public static int timeSecondsPlayed;
    public static int timeMinutesPlayed;
}
