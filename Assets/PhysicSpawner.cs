using UnityEngine;

public class PhysicSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _objectToSpawn;

    private void Update()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.x = Random.Range(spawnPos.x - 2, spawnPos.x + 2);
        spawnPos.y = Random.Range(spawnPos.y - 2, spawnPos.y + 2);
        spawnPos.z = Random.Range(spawnPos.z - 2, spawnPos.y + 2);
        
        Instantiate(_objectToSpawn, spawnPos, Quaternion.identity).SetActive(true);
    }
}
