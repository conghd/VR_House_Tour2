/******************************************************************************************************
FileName: PhysicsTest.cs
FileType: Visual C# Source file
Size : 26206
Author : Hoang Duc Cong (dhx496@uregina.ca)
Created On : 4/01/2023 9:56:39 AM
Copy Rights : University of Regina
Description : To enable gravity of some objects
*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B)) {
            rb.useGravity = true;
        }
    }
}