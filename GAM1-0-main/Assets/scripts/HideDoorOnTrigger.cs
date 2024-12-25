using UnityEngine;

public class HideDoorOnTrigger : MonoBehaviour
{
    public GameObject[] doorsToHide; // „’›Ê›… ··√»Ê«» «· Ì ”Ì „ ≈Œ›«ƒÂ«
    public AudioSource doorHideSound; // „’œ— «·’Ê  «·–Ì ”Ì „  ‘€Ì·Â

    private bool soundPlayed = false; // „ €Ì— ·  »⁄ „« ≈–«  „  ‘€Ì· «·’Ê  »«·›⁄·
    private bool doorsHidden = false; // „ €Ì— ·  »⁄ „« ≈–«  „ ≈Œ›«¡ «·√»Ê«» »«·›⁄·

    private void OnTriggerEnter(Collider other)
    {
        // «· Õﬁﬁ „‰ √‰ «·ﬂ«∆‰ «·–Ì œŒ· «· —ÌÃ— ÂÊ «··«⁄»
        if (other.CompareTag("Player"))
        {
            // «· Õﬁﬁ ≈–« ·„ Ì „  ‘€Ì· «·’Ê  »«·›⁄·
            if (!soundPlayed)
            {
                //  ‘€Ì· «·’Ê 
                if (doorHideSound != null)
                {
                    doorHideSound.Play();
                }
                else
                {
                    Debug.LogWarning("No AudioSource assigned to doorHideSound. Please check the Inspector.");
                }

                // Ê÷⁄ ⁄·«„… ⁄·Ï √‰Â  „  ‘€Ì· «·’Ê 
                soundPlayed = true;
            }

            // «· Õﬁﬁ ≈–« ·„ Ì „ ≈Œ›«¡ «·√»Ê«» »«·›⁄·
            if (!doorsHidden)
            {
                // «·„—Ê— ⁄·Ï Ã„Ì⁄ «·√»Ê«» ›Ì «·„’›Ê›… Ê≈Œ›«∆Â«
                foreach (GameObject door in doorsToHide)
                {
                    if (door != null) //  Õﬁﬁ „‰ √‰ «·»«» ·Ì” ›«—€« (Null)
                    {
                        door.SetActive(false);
                    }
                    else
                    {
                        Debug.LogWarning("One of the doors in the array is null. Please check the Inspector.");
                    }
                }
                doorsHidden = true;
            }
            //  ⁄ÿÌ· Â–« «·”ﬂ—Ì»  ·„‰⁄  ﬂ—«— «·≈Œ›«¡ («Œ Ì«—Ì)
            //this.enabled = false; // ·«  ⁄ÿ· «·”ﬂ—Ì»  Â‰« Õ Ï   „ﬂ‰ „‰ ≈⁄«œ… ≈ŸÂ«— «·√»Ê«»
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // «· Õﬁﬁ „‰ √‰ «·ﬂ«∆‰ «·–Ì Œ—Ã „‰ «· —ÌÃ— ÂÊ «··«⁄»
        if (other.CompareTag("Player"))
        {
            // ≈⁄«œ…  ⁄ÌÌ‰ «·„ €Ì—« 
            soundPlayed = false;
            doorsHidden = false;

            // «·„—Ê— ⁄·Ï Ã„Ì⁄ «·√»Ê«» ›Ì «·„’›Ê›… Ê≈ŸÂ«—Â«
            foreach (GameObject door in doorsToHide)
            {
                if (door != null)
                {
                    door.SetActive(true);
                }
            }
        }
    }
}