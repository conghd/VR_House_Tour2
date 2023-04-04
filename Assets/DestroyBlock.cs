/******************************************************************************************************
FileName: DestroyBlock.cs
FileType: Visual C# Source file
Size : 26206
Author : Hoang Duc Cong (dhx496@uregina.ca)
Created On : 3/20/2023 9:56:39 AM
Copy Rights : University of Regina
Description : Detect collision and destroy objects
*******************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyBlock : MonoBehaviour
{
    // An array of two elements to store 2 materials
    public Material[] matArray = new Material[2];

    public TMP_Text statusText;

    // Start is called before the first frame update
    void Start()
    {
       // Leave empty
    }

    // Update is called once per frame
    void Update()
    {
       // Leave empty 
    }

    void OnCollisionEnter(Collision collision)
    {
        // Compare the cylinder's material and object's material if they are the same
        // Then destroy the object
        if (GetComponent<Renderer>().sharedMaterial == collision.gameObject.GetComponent<Renderer>().sharedMaterial)
        {
            Destroy(collision.gameObject);
            GameManager.GetInstance().PlaySound(GameManager.SOUND_DESTROY_CUBE);
            GameManager.GetInstance().IncreaseScore();

            statusText.text = "" + GameManager.GetInstance().GetScore();
        }
    }
}
