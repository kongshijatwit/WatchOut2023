using UnityEngine;

/// <summary>
/// This is the script that spawn NPCs
/// </summary>
public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject npcPrefab;
    [SerializeField] private float spawnerRadius = 1;
    [SerializeField] private int spawnAmount;

    void Start()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector2 randomPos = (Vector2)transform.position + Random.insideUnitCircle * spawnerRadius;
            Instantiate(npcPrefab, randomPos, Quaternion.identity);
        }
    }

    //Shows an outline of the spawn radius
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, spawnerRadius);
    }
}
