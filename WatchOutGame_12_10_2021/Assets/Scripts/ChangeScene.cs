using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles transitioning between levels and stores player position. 
/// Should be placed on doors and entrances rather than the player itself
/// </summary>
public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private VectorValue playerStorage;
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private Vector2 playerPosition;
    [SerializeField] private bool initialize;

    /// <summary>
    /// Changes the scene to another based on its name
    /// </summary>
    /// <param name="sceneName">Name of the scene being transitioned to</param>
    public void ChangeSceneTo(string sceneName)
    {
        // -- I don't know why this is here -- //
        if(initialize) //basically if the scene change
        {
            playerInventory.clear();
        }
        // -- End of I Don't Know segment -- //

        playerStorage.initialValue = playerPosition;
        SceneManager.LoadScene(sceneName);
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // In case an NPC triggers we check for the Player tag
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            ChangeSceneTo(sceneName);
        }
    }
}
