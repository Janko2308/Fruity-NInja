using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] fruits;
    public bool spawn = true;

    public float xMin = -3f;
    public float xMax = 3f;
    public float zMin = -3f;
    public float zMax = 3f;

    void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    private IEnumerator SpawnFruit()
    {
        while (spawn)
        {
            float x, z;

            if (UnityEngine.Random.Range(0, 2) == 0) {
                x = UnityEngine.Random.Range(xMin, xMax);
                z = UnityEngine.Random.Range(0, 2) == 0 ? zMin : zMax;
            } else {
                z = UnityEngine.Random.Range(zMin, zMax);
                x = UnityEngine.Random.Range(0, 2) == 0 ? xMin : xMax;
            }

            yield return new WaitForSeconds(5 * (float) Math.Pow(2.71f, -0.05f * Time.timeSinceLevelLoad));
            var fruit = Instantiate(fruits[UnityEngine.Random.Range(0, fruits.Length)], new Vector3(x, -2, z), Quaternion.identity);
            var v = (player.transform.position - fruit.transform.position).normalized * 3.5f;
            v.y = 10;
            fruit.GetComponent<Rigidbody>().AddForce(v, ForceMode.Impulse);
        }
    }
}
