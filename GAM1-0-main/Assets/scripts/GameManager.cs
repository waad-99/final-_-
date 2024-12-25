using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // «” Ì—«œ „ﬂ »… TextMeshPro

public class GameManager : MonoBehaviour
{
    public float timerDuration = 50f;
    private float timer;
    public TextMeshProUGUI timerText; //  €ÌÌ— «·‰Ê⁄ ≈·Ï TextMeshProUGUI
    public string winSceneName = "WinScene";
    public string loseSceneName = "LoseScene";
    private bool objectCollected = false;

    void Start()
    {
        timer = timerDuration;
    }

    void Update()
    {
        if (!objectCollected)
        {
            timer -= Time.deltaTime;
            UpdateTimerText();

            if (timer <= 0)
            {
                LoadScene(loseSceneName);
            }
        }
    }

    void UpdateTimerText()
    {
        //  ÕœÌÀ «·‰’ »«” Œœ«„ TextMeshProUGUI
        timerText.text = Mathf.Ceil(timer).ToString() + " s";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectCollected = true;
            LoadScene(winSceneName);
        }
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
