using System.Collections;
using UnityEngine;

public class PhysicCube : MonoBehaviour
{
    private float _timeToBeAlive = 15f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(_timeToBeAlive / 2, _timeToBeAlive * 2));
        
        Destroy(gameObject);
    }
}
