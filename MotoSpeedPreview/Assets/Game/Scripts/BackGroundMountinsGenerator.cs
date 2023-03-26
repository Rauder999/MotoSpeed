using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMountinsGenerator : MonoBehaviour
{

    [SerializeField] private GameObject mountainPrefab;
    [SerializeField] private GameObject generatePoint2;

    List<GameObject> instantiatedMountains = new List<GameObject>();
    private float generateMountainPositionX;
    private float mountainLength;


    void Start()
    {
        mountainLength = mountainPrefab.GetComponent<SpriteRenderer>().bounds.size.x - 0.4f;
    }


    void Update()
    {
        if (transform.position.x > generatePoint2.transform.position.x - mountainLength * 2)
        {
            SpawnMountain();

        }
    }

    private void SpawnMountain()
    {
        generateMountainPositionX = generatePoint2.transform.position.x;
        GameObject mountain = Instantiate(mountainPrefab, generatePoint2.transform.position, Quaternion.identity);
        instantiatedMountains.Add(mountain);
        generateMountainPositionX += mountainLength * 2;
        generatePoint2.transform.position = new Vector3(generateMountainPositionX, generatePoint2.transform.position.y, generatePoint2.transform.position.z);

        if (instantiatedMountains.Count >= 6)
        {
            Destroy(instantiatedMountains[0].gameObject);
            instantiatedMountains.RemoveAt(0);
        }

    }
}
