using UnityEngine;

public static class Service<T> where T : MonoBehaviour {
    private static T instance;

    public static void Set(T newInstance) {
        instance = newInstance;
    }
    public static T Get() {
        if (instance == null) {
            instance = Object.FindObjectOfType<T>();
            if (instance == null)
                instance = new GameObject(nameof(T)).AddComponent<T>();
        }
        return instance;
    }
}