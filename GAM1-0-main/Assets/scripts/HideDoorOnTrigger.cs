using UnityEngine;

public class HideDoorOnTrigger : MonoBehaviour
{
    public GameObject[] doorsToHide; // ������ ������� ���� ���� �������
    public AudioSource doorHideSound; // ���� ����� ���� ���� ������

    private bool soundPlayed = false; // ����� ����� �� ��� �� ����� ����� ������
    private bool doorsHidden = false; // ����� ����� �� ��� �� ����� ������� ������

    private void OnTriggerEnter(Collider other)
    {
        // ������ �� �� ������ ���� ��� ������� �� ������
        if (other.CompareTag("Player"))
        {
            // ������ ��� �� ��� ����� ����� ������
            if (!soundPlayed)
            {
                // ����� �����
                if (doorHideSound != null)
                {
                    doorHideSound.Play();
                }
                else
                {
                    Debug.LogWarning("No AudioSource assigned to doorHideSound. Please check the Inspector.");
                }

                // ��� ����� ��� ��� �� ����� �����
                soundPlayed = true;
            }

            // ������ ��� �� ��� ����� ������� ������
            if (!doorsHidden)
            {
                // ������ ��� ���� ������� �� �������� ��������
                foreach (GameObject door in doorsToHide)
                {
                    if (door != null) // ���� �� �� ����� ��� ������ (Null)
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
            // ����� ��� �������� ���� ����� ������� (�������)
            //this.enabled = false; // �� ���� �������� ��� ��� ����� �� ����� ����� �������
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ������ �� �� ������ ���� ��� �� ������� �� ������
        if (other.CompareTag("Player"))
        {
            // ����� ����� ���������
            soundPlayed = false;
            doorsHidden = false;

            // ������ ��� ���� ������� �� �������� ��������
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