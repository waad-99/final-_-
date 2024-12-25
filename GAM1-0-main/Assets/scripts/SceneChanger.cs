using UnityEngine;
using UnityEngine.SceneManagement; // للوصول إلى مدير المشاهد

public class SceneChanger : MonoBehaviour
{
    // اسم المشهد الذي تريد الانتقال إليه
    public string sceneName;

    // وظيفة تُستدعى للانتقال إلى مشهد آخر
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
