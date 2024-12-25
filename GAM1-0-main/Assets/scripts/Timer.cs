using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // ÇáäÕ ÇáĞí íÚÑÖ ÇáæŞÊ
    public GameObject targetArea;     // ÇáãäØŞÉ ÇáÊí íÌÈ Ãä íÏÎáåÇ ÇááÇÚÈ áÊÔÛíá ÇáãÄŞÊ

    private float startTime;
    private bool timerRunning = false;

    void Update()
    {
        if (timerRunning)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ÇáÊÍŞŞ ããÇ ÅĞÇ ßÇä ÇááÇÚÈ ÏÎá ÇáãäØŞÉ
        if (other.CompareTag("Player") && !timerRunning)
        {
            StartTimer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ÅíŞÇİ ÇáãÄŞÊ ÚäÏ ÎÑæÌ ÇááÇÚÈ
        if (other.CompareTag("Player") && timerRunning)
        {
            StopTimer();
        }
    }

    private void StartTimer()
    {
        timerRunning = true;
        startTime = Time.time;
    }

    private void StopTimer()
    {
        timerRunning = false;
        timerText.text = "0:00.00"; // ÅÚÇÏÉ ÊÚííä ÇáäÕ ÚäÏ ÊæŞİ ÇáãÄŞÊ (ÇÎÊíÇÑí)
    }
}
