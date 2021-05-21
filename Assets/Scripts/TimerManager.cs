using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public float time = 60f;
    public float timeRemaining = 60f;
    public bool isRunning = false;
    public TextMesh timeLabel = null;
    public PointsManager pointsManager = null;

    void Awake()
    {
        GameObject go = GameObject.Find("Timer/Number");
        timeLabel = go.GetComponent<TextMesh>();
        pointsManager = GameObject.Find("PointsManager").GetComponent<PointsManager>();
    }

    void Update()
    {
        UpdateUITimer();

        if (isRunning){
            DoCountdown();
        }
    }

    void DoCountdown(){
        if (timeRemaining > 0){
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining <= 0){
            timeRemaining = 0;
            isRunning = false;
            ExecuteTimerTrigger();
        }
    }

    // funkcia ktorá sa vykoná keď dobehne timer
    void ExecuteTimerTrigger(){
        pointsManager.StopCount();
    }
    
    void UpdateUITimer(){
        string time = StrfTime();
        timeLabel.text = time;
    }

    public void StartTimer(){
        // reset time
        timeRemaining = time;

        pointsManager.ResetPoinst();
        isRunning = true;
    }

    public string StrfTime(){
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
