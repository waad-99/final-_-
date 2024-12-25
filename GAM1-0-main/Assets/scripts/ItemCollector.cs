using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public AudioSource pickupSound; // ����� ���� ��� ������ ��� ������ ������
    public GameObject starEffectPrefab; // ����� ������ ���� ���� ��� ������ ������

    private void OnTriggerEnter(Collider other)
    {
        // ������ �� �� ������ ���� �� �������� �� ����� ��� ����� "���"
        if (other.CompareTag("pen"))
        {
            // ����� ��� ��������
            if (pickupSound != null)
            {
                pickupSound.Play();
            }

            // ����� ����� ������
            if (starEffectPrefab != null)
            {
                Instantiate(starEffectPrefab, other.transform.position, Quaternion.identity);
            }

            // ����� ������ �� ������
            Destroy(other.gameObject);
        }
    }
}
