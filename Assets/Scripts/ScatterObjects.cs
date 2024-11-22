using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterObjects : MonoBehaviour
{
    
    public GameObject[] prefabs;
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            if (prefabs.Length == 0 || gameObject == null)
            {
                Debug.LogError("Prefab'lar veya Plane tanýmlanmamýþ!");
                return;
            }
            Debug.Log(gameObject.transform.localScale.z + " - " + gameObject.transform.localScale.x);
            float planeWidth = gameObject.transform.localScale.x * 10; 
            float planeHeight = gameObject.transform.localScale.z * 10; 

            Vector3 planePosition = gameObject.transform.position; 
            Debug.Log(planePosition + " - " + planeWidth
                 + " - " + planeHeight);

           
            float randomX = Random.Range(planePosition.x - planeWidth / 2, planePosition.x + planeWidth / 2);
            float randomZ = Random.Range( planePosition.z - planeHeight / 2, planePosition.z);

            
            float yPosition = planePosition.y + 5;

        
            Vector3 randomPosition = new Vector3(randomX, yPosition, randomZ);
            Debug.Log("random Position " + i + ". obje : " + randomPosition);
           
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject selectedPrefab = prefabs[randomIndex];

            Instantiate(selectedPrefab, randomPosition, Quaternion.identity);
        }

    }
}
