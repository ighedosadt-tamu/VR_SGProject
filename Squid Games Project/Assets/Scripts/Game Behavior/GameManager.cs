using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> portals;
    

    public static GameManager instance;
    private List<string> sceneNames = new List<string>();
    private Dictionary<string, GameObject> nameToPortal = new Dictionary<string, GameObject>();

    public enum State
    {
        completedNavigation,
        completedInteraction,
        completedPassthrough,
        completedHaptics    
    }
    private bool[] currentState = new bool[System.Enum.GetNames(typeof(State)).Length];

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps it alive between scenes
            
        }
        else
        {
            Destroy(gameObject); // Destroys duplicates
        }

        sceneNames.Clear();
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < sceneCount; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            sceneNames.Add(name);
        }
        LoadPortalDictionary();

        
    }

    

    public List<string> GetSceneNames()
    {
        return sceneNames;
    }
    
    public void LoadScene(int scene_index)
    {
         if (scene_index >= 0 && scene_index < sceneNames.Count)
        {
            Debug.Log(scene_index);
            SceneManager.LoadSceneAsync(scene_index);
        }
        else
        {
            Debug.LogWarning("Invalid scene index!");
        }
    }

    public bool[] GetCurrentState() { return currentState; }
    public void SetState(State state, bool status)
    {
        int index = (int)state;
        if (index >= 0 && index < currentState.Length)
        {
            currentState[index] = status;
        }
        else
        {
            Debug.LogWarning("Invalid state index");
        }
    }

    public bool IsStateCompleted(State state)
    {
        int index = (int)state;
        if (index >= 0 && index < currentState.Length)
        {
            return currentState[index];
        }
        Debug.LogWarning("Invalid State");
        return false;
    }

    public void LoadPortalDictionary()
    {
        nameToPortal.Clear();
        foreach (GameObject item in portals)
        {
            nameToPortal.Add(item.name, item);
        }
    }

    public void ProgressState()
    {

    }
}
