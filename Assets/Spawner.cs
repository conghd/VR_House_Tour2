/******************************************************************************************************
FileName: Spawner.cs
FileType: Visual C# Source file
Size : 26206
Author : Hoang Duc Cong (dhx496@uregina.ca)
Created On : 3/20/2023 9:56:39 AM
Copy Rights : University of Regina
Description : The class is to spawn objects in every two seconds
*******************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // An arrays of two objects that are prefabs to be used to spawn objects
    public GameObject[] gameObjects = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        // Call the Spawn method in every two seconds
        InvokeRepeating("Spawn", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
       // Leave empty 
    }

    void Spawn()
    {
        // Random position
        float x = Random.Range(0.20f, 0.40f);
        float y = Random.Range(0.30f, 0.50f);
        float z = Random.Range(0.90f, 1.10f);

        // Random object (blue or red)
        int index = Random.Range(0, 2);
        var position = new Vector3((index == 0 ? -x : x), y, z);

        Instantiate(gameObjects[index], position, Quaternion.identity);
    }
}
