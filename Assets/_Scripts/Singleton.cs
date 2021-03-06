using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance != null) return _instance;
            return FindObjectOfType<T>();
        }
    }

    //Use this for destroy
    protected virtual void OnDestroy()
    {
        Debug.Log("OnDestroy: " + typeof(T));
        _instance = null;
    }
}