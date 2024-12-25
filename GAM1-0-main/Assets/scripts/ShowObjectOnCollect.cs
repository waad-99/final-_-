using UnityEngine;
using System.Collections;

public class ShowObjectOnCollect : MonoBehaviour
{
    public GameObject objectToShow; // ������ ���� ���� ����
    public int itemsToCollect = 3; // ��� ������� �������� ������ ������
    public float displayDuration = 5f; // ��� ��� ������ ��������
    private int itemsCollected = 0; // ��� ������� ���� �� ����� ��� ����
    private bool isObjectVisible = false; // ����� ����� ���� ������

    private void OnTriggerEnter(Collider other)
    {
        // ���� �� �� ������ ���� ��� ������� ���� ������� "pen"
        if (other.CompareTag("pen"))
        {
            Debug.Log("Collected item: " + other.name);

            // ����� ��� ������� ���� �� �����
            itemsCollected++;

            // ����� ������ ���� �� ����
            Destroy(other.gameObject);

            // ���� ��� �� ��� ����� ������� �� �������
            if (itemsCollected >= itemsToCollect && !isObjectVisible) // ���� �� ��� ���� ������ ������
            {
                Debug.Log("Collected enough items!");

                // ���� �� �� ������ ������ ���� �����
                if (objectToShow != null)
                {
                    Debug.Log("Showing object...");
                    objectToShow.SetActive(true);
                    isObjectVisible = true; // ����� ���� ������ ��� true

                    // ��� Coroutine ������ ������ ��� ����
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
            isObjectVisible = false; // ����� ����� ���� ������ ��� false
        }
        else
        {
            Debug.LogWarning("objectToShow is null. Cannot hide object.");
        }
    }
}