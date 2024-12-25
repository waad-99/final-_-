using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToScene : MonoBehaviour
{
    public string sceneName; // اسم المشهد الذي تريد العودة إليه

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("اسم المشهد غير محدد في المكون!");
        }
    }
}
