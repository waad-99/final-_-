using System.Collections.Generic;
using UnityEngine;

public class ResponsivePlayerManager : MonoBehaviour
{
    public List<Transform> players;                // ����� ��������
    public List<Vector3> targetPositions;          // ����� ���������� ��������� ��� ����
    public Vector2 referenceResolution = new Vector2(1920, 1080); // ����� ��������

    private Vector2 currentResolution;

    void Start()
    {
        if (players == null || players.Count == 0)
        {
            Debug.LogError("No players assigned! Please assign players in the inspector.");
            return;
        }

        if (targetPositions == null || targetPositions.Count != players.Count)
        {
            Debug.LogError("Target positions count must match players count.");
            return;
        }

        // ����� ����� �������� ��� ������� ���������
        SetPlayersToTargetPositions();
    }

    void Update()
    {
        // ���� ��� ���� ��� ������ ����� �����
        if (currentResolution.x != Screen.width || currentResolution.y != Screen.height)
        {
            SetPlayersToTargetPositions();
        }
    }

    void SetPlayersToTargetPositions()
    {
        // ����� ����� �������
        currentResolution = new Vector2(Screen.width, Screen.height);

        // ��� �� ���� �� ������ ������ ��
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] != null) // ���� �� �� ������ �����
            {
                players[i].position = targetPositions[i];
            }
        }

        Debug.Log("Players' positions set to their target positions.");
    }
}
