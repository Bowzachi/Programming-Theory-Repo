using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject fishPrefab;
    [SerializeField] private GameObject fishTwoPrefab;
    [SerializeField] private GameObject fishThreePrefab;
    [SerializeField] private GameObject fishFourPrefab;
    [SerializeField] private GameObject sharkPrefab;

    [SerializeField] private GameObject spawnPointsGroup;
    private List<Transform> spawnPointsList = new List<Transform>();

    [SerializeField] private int spawnGroupAmount = 5;
    // Start is called before the first frame update
    void Start()
    {
        MainManager.Instance.OnGameStart += MainManager_OnGameStart;
        foreach (Transform child in spawnPointsGroup.transform)
        {
            spawnPointsList.Add(child);
        }
    }

    private void MainManager_OnGameStart(object sender, System.EventArgs e)
    {
        SetupGame();
    }

    private void SetupGame()
    {
        //spawn groups
        foreach (Transform spawnPoint in spawnPointsList)
        {
            CreateSpawnGroup(spawnPoint);
        }
        //spawn an assortment of fish, Shark being the most rare, with semi random x and z coordinates around the spawnpoint
    }

    private void CreateSpawnGroup(Transform spawnPointTransform)
    {
        for (int i = 0; i < spawnGroupAmount; i++)
        {
            Vector3 randomizedSpawnPosition = GetRandomizedSpawnPosition(spawnPointTransform);
            int fishRandomizer = Random.Range(0, 10);
            switch (fishRandomizer)
            {
                case 0:
                    Instantiate(fishPrefab, randomizedSpawnPosition, spawnPointTransform.localRotation);
                    break;
                case 1:
                    Instantiate(fishPrefab, randomizedSpawnPosition, spawnPointTransform.localRotation);
                    break;
                case 2:
                    Instantiate(fishPrefab, randomizedSpawnPosition, spawnPointTransform.localRotation);
                    break;
                case 3:
                    Instantiate(fishTwoPrefab, randomizedSpawnPosition, spawnPointTransform.localRotation);
                    break;
                case 4:
                    Instantiate(fishTwoPrefab, randomizedSpawnPosition, spawnPointTransform.localRotation);
                    break;
                case 5:
                    Instantiate(fishThreePrefab, randomizedSpawnPosition, spawnPointTransform.localRotation);
                    break;
                case 6:
                    Instantiate(fishThreePrefab, randomizedSpawnPosition, spawnPointTransform.localRotation);
                    break;
                case 7:
                    Instantiate(fishFourPrefab, randomizedSpawnPosition, spawnPointTransform.localRotation);
                    break;
                case 8:
                    Instantiate(fishFourPrefab, randomizedSpawnPosition, spawnPointTransform.localRotation);
                    break;
                case 9:
                    Instantiate(sharkPrefab, randomizedSpawnPosition, spawnPointTransform.localRotation);
                    break;
            }
        }
    }

    private Vector3 GetRandomizedSpawnPosition(Transform spawnPointTransform)
    {
        float offsetX = Random.Range(-2f, 2f);
        float offsetZ = Random.Range(-2f, 2f);
        Vector3 randomizedSpawnPosition = new Vector3(spawnPointTransform.position.x + offsetX, spawnPointTransform.position.y, spawnPointTransform.position.z + offsetZ);
        return randomizedSpawnPosition;
    }
}
