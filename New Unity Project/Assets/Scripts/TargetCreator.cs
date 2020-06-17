using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCreator : MonoBehaviour
{
    public int maxTargets = 6;
    public Target targetPrefab;
    public float creationSpeed = 0.5f;

    private int numberOfTargetCreated;

    private void Start()
    {
        numberOfTargetCreated = 0;
        InvokeRepeating("CreateTarget", 0f, creationSpeed);
    }

    private void CreateTarget()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float randomX = Random.Range(0f, screenWidth);
        float randomY = Random.Range(0f, screenHeight);

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(randomX, randomY, 10f));

        Instantiate(targetPrefab, worldPosition, Quaternion.identity);
    }
}
