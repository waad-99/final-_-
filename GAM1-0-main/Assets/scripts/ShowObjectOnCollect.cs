using UnityEngine;
using System.Collections;

public class ShowObjectOnCollect : MonoBehaviour
{
    public GameObject objectToShow; // «·ﬂ«∆‰ «·–Ì ”Ì „ ⁄—÷Â
    public int itemsToCollect = 3; // ⁄œœ «·⁄‰«’— «·„ÿ·Ê»… ·≈ŸÂ«— «·ﬂ«∆‰
    public float displayDuration = 5f; // „œ… ⁄—÷ «·ﬂ«∆‰ »«·ÀÊ«‰Ì
    private int itemsCollected = 0; // ⁄œœ «·⁄‰«’— «· Ì  „ Ã„⁄Â« Õ Ï «·¬‰
    private bool isObjectVisible = false; // „  »⁄ ·Õ«·… ŸÂÊ— «·ﬂ«∆‰

    private void OnTriggerEnter(Collider other)
    {
        //  Õﬁﬁ „‰ √‰ «·⁄‰’— «·–Ì œŒ· «·„’«œ„ ·œÌÂ «·⁄·«„… "pen"
        if (other.CompareTag("pen"))
        {
            Debug.Log("Collected item: " + other.name);

            // “Ì«œ… ⁄œœ «·⁄‰«’— «· Ì  „ Ã„⁄Â«
            itemsCollected++;

            //  ⁄ÿÌ· «·ﬂ«∆‰ «·–Ì  „ Ã„⁄Â
            Destroy(other.gameObject);

            //  Õﬁﬁ ≈–«  „ Ã„⁄ «·⁄œœ «·„ÿ·Ê» „‰ «·⁄‰«’—
            if (itemsCollected >= itemsToCollect && !isObjectVisible) //  Õﬁﬁ „‰ ⁄œ„ ŸÂÊ— «·ﬂ«∆‰ »«·›⁄·
            {
                Debug.Log("Collected enough items!");

                //  Õﬁﬁ „‰ √‰ «·ﬂ«∆‰ «·„—«œ ⁄—÷Â „ı⁄Ì‰
                if (objectToShow != null)
                {
                    Debug.Log("Showing object...");
                    objectToShow.SetActive(true);
                    isObjectVisible = true; //  ⁄ÌÌ‰ Õ«·… «·ŸÂÊ— ≈·Ï true

                    // »œ¡ Coroutine ·≈Œ›«¡ «·ﬂ«∆‰ »⁄œ › —…
                    StartCoroutine(HideObjectAfterDelay());
                }
                else
                {
                    Debug.LogWarning("No object assigned to 'objectToShow'!");
                }
            }
            else if (itemsCollected < itemsToCollect)
            {
                Debug.Log("Items collected: " + itemsCollected + "/" + itemsToCollect);
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
            isObjectVisible = false; // ≈⁄«œ…  ⁄ÌÌ‰ Õ«·… «·ŸÂÊ— ≈·Ï false
        }
        else
        {
            Debug.LogWarning("objectToShow is null. Cannot hide object.");
        }
    }
}