using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerManager : MonoBehaviour
{
    public float time = 60f;
    public float timeRemaining = 60f;
    public AudioClip startCountdown = null;
    public AudioClip stopCountdown = null;
    public AudioClip melody = null;
    public UnityEvent onFinished = null;

    private bool isRunning = false;
    private TextMesh timeLabel = null;
    private PointsManager pointsManager = null;
    private AudioSource audioSource = null;

    void Awake()
    {
        GameObject go = GameObject.Find("Timer/Number");
        timeLabel = go.GetComponent<TextMesh>();
        pointsManager = GameObject.Find("PointsManager").GetComponent<PointsManager>();
        audioSource = GetComponentInChildren<AudioSource>();
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

        if ((timeRemaining <= 6) && (timeRemaining > 1)){
            PlayStopCountdown();
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
        PlayMelody();
        onFinished.Invoke();
    }
    
    void UpdateUITimer(){
        string time = StrfTime();
        timeLabel.text = time;
    }

    public void StartGame(){
        // reset time
        isRunning = false;
        timeRemaining = time;
        pointsManager.ResetPoints();
        PlayStartCountdown();
        StartCoroutine(LateGameStart(3f));
    }

    public void ResetTimer(){
        isRunning = false;
        timeRemaining = time;
    }

    private IEnumerator LateGameStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        isRunning = true;
    }

    public string StrfTime(){
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void PlayStartCountdown(){
        audioSource.clip = startCountdown;
        audioSource.Play();
    }

    private void PlayStopCountdown(){
        if (!audioSource.isPlaying){
            audioSource.clip = stopCountdown;
            audioSource.Play();
        }
    }

    private void PlayMelody(){
        audioSource.clip = melody;
        audioSource.Play();
    }

}
