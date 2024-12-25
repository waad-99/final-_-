using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTouch : MonoBehaviour
{
    // ÇÓã ÇáãÔåÏ ÇáĞí ÊÑíÏ ÇáÇäÊŞÇá Åáíå
    [SerializeField] private string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        // ÊÍŞŞ ÅĞÇ ßÇä ÇáÌÓã ÇáĞí íáãÓ åæ ÇááÇÚÈ
        if (other.CompareTag("Player"))
        {
            // ÇáÇäÊŞÇá Åáì ÇáãÔåÏ ÇáãÍÏÏ
            SceneManager.LoadScene(sceneName);
        }
    }
}