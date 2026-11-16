using UnityEngine;
using UnityEngine.Pool;

public class PhysicSpawner : MonoBehaviour
{
    [SerializeField] private int _poolSize = 10;
    [SerializeField] private ObjectPool<PhysicCube> _objectPool;

    private void Start()
    {
        _objectPool = new ObjectPool<PhysicCube>(
            CreateCube,
            OnTakeFromPool,
            OnReturnedToPool,
            OnDestroyPoolObject,
            true,
            _poolSize,
            512
        );
    }

    private PhysicCube CreateCube()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent<Rigidbody>();

        PhysicCube physic = cube.AddComponent<PhysicCube>();
        cube.SetActive(false);
        return physic;
    }

    private void OnTakeFromPool(PhysicCube cube)
    {
        cube.gameObject.SetActive(true);
    }
    
    private void OnReturnedToPool(PhysicCube cube)
    {
        cube.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(PhysicCube cube)
    {
        Destroy(cube.gameObject);
    }
    
    private void Update()
    {
        Debug.Log(_objectPool.CountActive);

        if (_objectPool.CountActive < _poolSize)
        {
            Vector3 spawnPos = transform.position;
            spawnPos.x = Random.Range(spawnPos.x - 2, spawnPos.x + 2);
            spawnPos.y = Random.Range(spawnPos.y - 2, spawnPos.y + 2);
            spawnPos.z = Random.Range(spawnPos.z - 2, spawnPos.y + 2);

            PhysicCube cube = _objectPool.Get();
            cube.Init(spawnPos, Vector3.zero, _objectPool);
        }
    }
}
