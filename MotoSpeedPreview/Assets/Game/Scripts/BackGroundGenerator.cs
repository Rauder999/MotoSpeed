using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGenerator : MonoBehaviour
{
    [SerializeField] private GameObject backGroundPrefab;
    [SerializeField] private GameObject generatePoint;

    List<GameObject> instantiatedBackGround = new List<GameObject>();
    private float generatePointPositionX;
    private float backGroundLength;
   
   
    void Start()
    {
        backGroundLength = backGroundPrefab.GetComponent<SpriteRenderer>().bounds.size.x - 0.2f;
    }

    
    void Update()
    {
        if (transform.position.x > generatePoint.transform.position.x - backGroundLength * 3)
        {
            SpawnBackGround();
            
        }
    }

    private void SpawnBackGround ()
    {
        generatePointPositionX = generatePoint.transform.position.x;
        GameObject backGround = Instantiate(backGroundPrefab, generatePoint.transform.position, Quaternion.Euler(0f,180f,0f));
        instantiatedBackGround.Add(backGround);
        generatePointPositionX +=  backGroundLength * 3;
        generatePoint.transform.position = new Vector3(generatePointPositionX, generatePoint.transform.position.y, generatePoint.transform.position.z);

        if (instantiatedBackGround.Count >= 8)
        {
            Destroy(instantiatedBackGround[0].gameObject);
            instantiatedBackGround.RemoveAt(0);
        }

    }
}
