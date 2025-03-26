using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    UnityEditor.EditorBuildSettingsScene[] scenes;
    private List<string> scenePaths = new List<string>();
    
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

        scenePaths.Clear();
        scenes = UnityEditor.EditorBuildSettings.scenes;
        int scence_count = scenes.Length;
        Debug.Log(scence_count);
        Debug.Log(SceneManager.loadedSceneCount);

        for (int i = 0; i < scence_count; i++)
        {
            // Debug.Log(scenes[i].path);
            int assets_path_length = 7; // Assets/         
            int extension_path_length = 6; // .unity
            string scene_path = scenes[i].path.Substring(assets_path_length, scenes[i].path.Length - (extension_path_length + assets_path_length));
            scenePaths.Add(scene_path);

            // SceneManager.LoadSceneAsync(scene_path);
        }


    }

    public List<string> GetScenePaths()
    {
        return scenePaths;
    }
    
    public void LoadScene(int scene_index)
    {
        SceneManager.LoadSceneAsync(scenePaths[scene_index]);
    }
}
