/******************************************************************************************************
FileName: HandController.cs
FileType: Visual C# Source file
Size : 26206
Author : Hoang Duc Cong (dhx496@uregina.ca)
Created On : 4/01/2023 9:56:39 AM
Copy Rights : University of Regina
Description : To grab and throw objects
*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandController : MonoBehaviour
{
    public TMP_Text StatusText;

    float speed = 10;

    private GameObject ball;
    private bool canHold;
    // Start is called before the first frame update

    void Start()
    {
        ball = null;
        canHold = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A) ||
            Input.GetKeyDown(KeyCode.LeftControl)) {
            if (canHold) {
                Pickup();
            }
        }

        if (OVRInput.GetUp(OVRInput.RawButton.A) ||
            Input.GetKeyDown(KeyCode.RightControl)) {
            if (!canHold) {
                ThrowDrop();
            }
        }
    }

    void Pickup()
    {
        if (ball == null) return;

        ball.transform.SetParent(transform, true);
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.GetComponent<Rigidbody>().isKinematic = true;

        canHold = false;
    }

    void ThrowDrop()
    {
        if (ball == null) return;

        ball.transform.SetParent(null);
        ball.GetComponent<Rigidbody>().useGravity = true;
        ball.GetComponent<Rigidbody>().isKinematic = false;
        ball.GetComponent<Rigidbody>().velocity = transform.forward * speed;
        
        ball = null;

        //transform.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
        //transform.GetChild(0).parent = null;

        canHold = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (ball == null && other.gameObject.CompareTag("grabbable")) {
            ball = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (canHold) {
            ball = null;
        }
    }
}
