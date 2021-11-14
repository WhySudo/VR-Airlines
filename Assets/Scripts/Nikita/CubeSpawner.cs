using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private CubeAction cubePrefab;

    [SerializeField]
    private float radius = 5;

    private Vector3 GeneratePosition() {
        float rad = Random.Range(0, radius);
        float zen = Random.Range(0, Mathf.PI);
        float az = Random.Range(0, 2f * Mathf.PI);

        return new Vector3(Mathf.Sin(zen) * Mathf.Cos(az), Mathf.Sin(zen) * Mathf.Sin(az), Mathf.Cos(zen)) * rad;
    }

    public void SpawnCube() {
        var spawnedObject = Instantiate(cubePrefab, transform);
        spawnedObject.transform.position = transform.position + GeneratePosition();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
