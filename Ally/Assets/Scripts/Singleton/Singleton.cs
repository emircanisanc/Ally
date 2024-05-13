using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Object
{
    private static T instance;
    public static T Instance{
        get{if(instance == null)
        {instance = FindObjectOfType<T>();}
        return instance;}}
    protected virtual void Awake()
    {
        instance = this as T;
    }

}
