using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandspaseGenerator : MonoBehaviour
{
    [SerializeField] private GameObject emptyObject;
    [SerializeField] private GameObject[] roadPrefab;

    EdgeCollider2D edgeCollider;
    Vector2[] points;
    List<GameObject> instantiatedRoad = new List<GameObject>();

    private float roadLength;
    private float emptyObjectPositionX;
    

    private void Start()
    {
       edgeCollider = roadPrefab[0].GetComponent<EdgeCollider2D>();
        points = edgeCollider.points;
        for (int i = 0; i < points.Length - 1; i++) 
        {
            float distance = Vector2.Distance(points[i], points[i + 1]);
            if (distance > roadLength)
            {
                roadLength = distance; break;
            }
        }
        emptyObjectPositionX = emptyObject.transform.position.x;
    }

    private void Update()
    {

        if (transform.position.x >= emptyObjectPositionX - roadLength*2 - 15)
        {
            GenerateRoad();
        }
    }

    public void GenerateRoad()
    {

        GameObject newRoad = Instantiate(roadPrefab[Random.Range(0,roadPrefab.Length)], emptyObject.transform.position, Quaternion.identity) ;
        instantiatedRoad.Add(newRoad);
        emptyObjectPositionX += roadLength * 4 - 1f;
        emptyObject.transform.position = new Vector3(emptyObjectPositionX, emptyObject.transform.position.y, emptyObject.transform.position.z);

       if (instantiatedRoad.Count >= 8)
        {
            Destroy(instantiatedRoad[0].gameObject);
            instantiatedRoad.RemoveAt(0);
        }
    }






}
