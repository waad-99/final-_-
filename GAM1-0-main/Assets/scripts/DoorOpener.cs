using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Animator doorAnimator; // —»ÿ «·√‰Ì„Ì‘‰
    public AudioSource doorAudioSource; // „—Ã⁄ ·„’œ— «·’Ê 
    public AudioClip openSound; // ’Ê  › Õ «·»«»
    public AudioClip closeSound; // ’Ê  ≈€·«ﬁ «·»«»
    private bool isPlayerNearby = false;

    private void OnTriggerEnter(Collider other)
    {
        //  Õﬁﬁ „‰ √‰ «· —ÌÃ— ÌÕ„· «· «Ã "DoorTrigger" Ê√‰ «··«⁄» ÂÊ „‰ œŒ·
        if (other.CompareTag("DoorTrigger") && IsPlayerNearby(other))
        {
            isPlayerNearby = true;
            doorAnimator.SetBool("isOpen", true); //  ‘€Ì· √‰Ì„Ì‘‰ «·› Õ

            if (openSound != null && doorAudioSource != null)
            {
                doorAudioSource.PlayOneShot(openSound); //  ‘€Ì· ’Ê  «·› Õ
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //  Õﬁﬁ „‰ √‰ «· —ÌÃ— ÌÕ„· «· «Ã "DoorTrigger" Ê√‰ «··«⁄» ÂÊ „‰ Œ—Ã
        if (other.CompareTag("DoorTrigger") && IsPlayerNearby(other))
        {
            isPlayerNearby = false;
            doorAnimator.SetBool("isOpen", false); //  ‘€Ì· √‰Ì„Ì‘‰ «·≈€·«ﬁ

            if (closeSound != null && doorAudioSource != null)
            {
                doorAudioSource.PlayOneShot(closeSound); //  ‘€Ì· ’Ê  «·≈€·«ﬁ
            }
        }
    }

    // œ«·… „”«⁄œ… ·· Õﬁﬁ „„« ≈–« ﬂ«‰ «··«⁄» ﬁ—Ì»«
    private bool IsPlayerNearby(Collider collider)
    {
        return collider.transform.root.CompareTag("Player");
    }
}
