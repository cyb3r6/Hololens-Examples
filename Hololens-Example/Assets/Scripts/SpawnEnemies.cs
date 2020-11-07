using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject enemyPrefab;
    public List<Transform> spawnTransforms = new List<Transform>();
    private int index;
    private enum spawnDirection { forward, back, left, right, up, down}
    private spawnDirection direction = spawnDirection.forward;
    private void Start()
    {
        StartCoroutine(TimedRaycast());
    }

    Vector3 Direction
    {
        get
        {
            if (direction == spawnDirection.forward) return transform.forward;
            else if (direction == spawnDirection.back) return -transform.forward;
            else if (direction == spawnDirection.left) return -transform.right;
            else if (direction == spawnDirection.right) return transform.right;
            else if (direction == spawnDirection.up) return -transform.right;
            else if (direction == spawnDirection.down) return default;
            else return default;
        }
    }

    private IEnumerator TimedRaycast()
    {
        while (true)
        {
            index = Random.Range(0, 5);
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, transform.forward, out hit))
            {
                SpawnTheThing(hit.point);
                yield return new WaitForSeconds(5f);
            }
            else
            {
                yield return null;
            }
        }
    }

    public void SpawnTheThing(Vector3 position)
    {
        index = Random.Range(0, spawnTransforms.Count);
        GameObject spawnedEnemy = Instantiate(enemyPrefab, position, Quaternion.identity);
    }

    //private IEnumerator SpawnedEnemies()
    //{
    //    while (true)
    //    {
    //SpawnTheThing();
    //yield return new WaitForSeconds(2f);
    //SpawnTheThing();
    //yield return new WaitForSeconds(2f);
    //SpawnTheThing();
    //yield return new WaitForSeconds(2f);
    //SpawnTheThing();
    //yield return new WaitForSeconds(2f);
    //    }
    //}


}
