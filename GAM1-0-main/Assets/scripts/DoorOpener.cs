using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Animator doorAnimator; // ��� ���������
    public AudioSource doorAudioSource; // ���� ����� �����
    public AudioClip openSound; // ��� ��� �����
    public AudioClip closeSound; // ��� ����� �����
    private bool isPlayerNearby = false;

    private void OnTriggerEnter(Collider other)
    {
        // ���� �� �� ������� ���� ����� "DoorTrigger" ��� ������ �� �� ���
        if (other.CompareTag("DoorTrigger") && IsPlayerNearby(other))
        {
            isPlayerNearby = true;
            doorAnimator.SetBool("isOpen", true); // ����� ������� �����

            if (openSound != null && doorAudioSource != null)
            {
                doorAudioSource.PlayOneShot(openSound); // ����� ��� �����
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ���� �� �� ������� ���� ����� "DoorTrigger" ��� ������ �� �� ���
        if (other.CompareTag("DoorTrigger") && IsPlayerNearby(other))
        {
            isPlayerNearby = false;
            doorAnimator.SetBool("isOpen", false); // ����� ������� �������

            if (closeSound != null && doorAudioSource != null)
            {
                doorAudioSource.PlayOneShot(closeSound); // ����� ��� �������
            }
        }
    }

    // ���� ������ ������ ��� ��� ��� ������ ������
    private bool IsPlayerNearby(Collider collider)
    {
        return collider.transform.root.CompareTag("Player");
    }
}
