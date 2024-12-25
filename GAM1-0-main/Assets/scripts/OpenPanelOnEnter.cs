using UnityEngine;
using System.Collections;

public class ShowObjectOnEnter : MonoBehaviour
{
    public GameObject objectToShow; // الكائن الذي سيتم عرضه
    public float displayDuration = 3f; // الوقت الذي سيظل فيه الكائن ظاهرًا (بالثواني)

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger with: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected!");

            if (objectToShow != null)
            {
                Debug.Log("Showing object...");
                objectToShow.SetActive(true);

                // بدء Coroutine لإخفاء الكائن بعد فترة
                StartCoroutine(HideObjectAfterDelay());
            }
            else
            {
                Debug.LogWarning("No object assigned to 'objectToShow'!");
            }
        }
    }

    private IEnumerator HideObjectAfterDelay()
    {
        Debug.Log("Waiting for " + displayDuration + " seconds...");
        yield return new WaitForSeconds(displayDuration);

        if (objectToShow != null)
        {
            Debug.Log("Hiding object...");
            objectToShow.SetActive(false);
        }
        else
        {
            Debug.LogWarning("objectToShow is null. Cannot hide object.");
        }
    }
}
