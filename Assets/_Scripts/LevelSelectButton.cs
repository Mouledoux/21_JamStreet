using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    public void SelectLevel(int index)
    {
        LevelManager.Instance.SpawnLevel(index);
    }
}
