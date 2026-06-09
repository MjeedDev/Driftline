using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Transform lastPlatform;

    private Vector3 lastPosition;
    private Vector3 newPosition;

    private void Start()
    {
        lastPosition = lastPlatform.position;
        StartCoroutine(SpawnPlatform());
    }

    private IEnumerator SpawnPlatform()
    {
        while (true)
        {
            GeneratePosition();
            Instantiate(platformPrefab, newPosition, Quaternion.identity);
            lastPosition = newPosition;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void GeneratePosition()
    {
        newPosition = lastPosition;
        int seed = Random.Range(0, 2);

        if (seed == 0)
        {
            newPosition.x += 2f;
        }
        else
        {
            newPosition.z += 2f;
        }
    }
}
