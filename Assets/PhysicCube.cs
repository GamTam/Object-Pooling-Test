using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class PhysicCube : MonoBehaviour
{
    private float _timeToBeAlive = 15f;
    private Rigidbody _rigidbody;
    private ObjectPool<PhysicCube> _pool;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnDisable()
    {
        if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody>();
        
        _rigidbody.isKinematic = true;
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }

    public void Init(Vector3 spawnPos, Vector3 spawnRotation, ObjectPool<PhysicCube> pool)
    {
        if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody>();
        
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;

        transform.position = spawnPos;
        transform.rotation = Quaternion.Euler(spawnRotation);
        
        _rigidbody.isKinematic = false;
        _pool = pool;
        StartCoroutine(WaitToKill());
    }
    
    private IEnumerator WaitToKill()
    {
        yield return new WaitForSeconds(Random.Range(_timeToBeAlive / 2, _timeToBeAlive * 2));
        
        _pool.Release(this);
    }
}
