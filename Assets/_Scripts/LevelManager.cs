using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mouledoux.Mediation;

public class LevelManager : Singleton<LevelManager>
{
    public int levelIndex = 0;
    public List<GameObject> levelPrefabs = new List<GameObject>();
    private GameObject currentLevel;

    private void Start()
    {
        SpawnLevel(0);
    }

    public void SpawnLevel(int index)
    {
        levelIndex = index;
        RestartLevel();
    }

    public void RestartLevel()
    {
        Destroy(currentLevel);
        currentLevel = Instantiate(levelPrefabs[levelIndex], Vector3.zero, Quaternion.identity, transform);
        currentLevel.SetActive(true);
        StartCoroutine(LevelStart(3f));
    }

    public IEnumerator LevelStart(float countdown)
    {
        yield return new WaitForSeconds(countdown);
        Catalogue<int>.NotifySubscribers("LevelStart", levelIndex);
    }
}
