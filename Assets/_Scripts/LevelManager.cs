using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mouledoux.Mediation;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject opionMenu;

    public int levelIndex = 0;

    public List<GameObject> levelPrefabs = new List<GameObject>();
    private GameObject currentLevel;

    private void Start()
    {
        foreach(GameObject l in levelPrefabs)
        {
            l.SetActive(false);
        }

        SpawnLevel(0);
        Catalogue<int>.Subscription RestartSub = new Catalogue<int>.Subscription(
            "RestartLevel", (int i) => RestartLevel()).Subscribe();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            opionMenu.SetActive(!opionMenu.activeSelf);
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
