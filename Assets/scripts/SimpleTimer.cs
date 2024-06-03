using UnityEngine;
using UnityEngine.Events;

public class SimpleTimer : MonoBehaviour
{

    float targetTime = 60.0f;
    bool hasStarted = false;

    public UnityEvent timerFinished;

    private void Update()
    {
        if(hasStarted)
        {
            RunTimer();
        }
    }

    public void StartTimer(float pTime)
    {
        if (!hasStarted)
        {
            hasStarted = true;
            targetTime = pTime;
        }
    }

    private void RunTimer()
    {
        targetTime -= Time.deltaTime;
        //Debug.Log("targeTime: {targeTime}");

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }

    void timerEnded()
    {
        //Debug.Log($"timer ended");
        timerFinished?.Invoke();
        hasStarted = false;
    }


}
