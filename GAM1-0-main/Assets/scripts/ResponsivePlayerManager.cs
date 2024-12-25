using System.Collections.Generic;
using UnityEngine;

public class ResponsivePlayerManager : MonoBehaviour
{
    public List<Transform> players;                // ŞÇÆãÉ ÇááÇÚÈíä
    public List<Vector3> targetPositions;          // ŞÇÆãÉ ÇáÅÍÏÇËíÇÊ ÇáãÓÊåÏİÉ áßá áÇÚÈ
    public Vector2 referenceResolution = new Vector2(1920, 1080); // ÇáÏŞÉ ÇáãÑÌÚíÉ

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

        // ÊÚííä ãæÇŞÚ ÇááÇÚÈíä Åáì ÇáãæÇŞÚ ÇáãÓÊåÏİÉ
        SetPlayersToTargetPositions();
    }

    void Update()
    {
        // ÊÍŞŞ ÅĞÇ ÊÛíÑ ÍÌã ÇáÔÇÔÉ ÃËäÇÁ ÇááÚÈ
        if (currentResolution.x != Screen.width || currentResolution.y != Screen.height)
        {
            SetPlayersToTargetPositions();
        }
    }

    void SetPlayersToTargetPositions()
    {
        // ÊÍÏíË ÇáÏŞÉ ÇáÍÇáíÉ
        currentResolution = new Vector2(Screen.width, Screen.height);

        // æÖÚ ßá áÇÚÈ İí ÇáãæŞÚ ÇáãÎÕÕ áå
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] != null) // ÊÍŞŞ ãä Ãä ÇááÇÚÈ ãæÌæÏ
            {
                players[i].position = targetPositions[i];
            }
        }

        Debug.Log("Players' positions set to their target positions.");
    }
}
