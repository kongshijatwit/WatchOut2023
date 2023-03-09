using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Changes scenes while also saving player position
/// </summary>
public class LevelManager : MonoBehaviour
{
   [SerializeField] private Transform player;
   private Dictionary<int, Vector3> startingPosition = new();

    private void Awake()
    {
        SceneManager.sceneLoaded += (Scene s, LoadSceneMode m) =>
        {
            if (startingPosition.ContainsKey(s.buildIndex)) player.position = startingPosition[s.buildIndex];
        };
        DontDestroyOnLoad(gameObject);
    }

    public void LoadNewLevel(int level) {
        startingPosition[SceneManager.GetActiveScene().buildIndex] = player.position;
        SceneManager.LoadScene(level);
    }
}
