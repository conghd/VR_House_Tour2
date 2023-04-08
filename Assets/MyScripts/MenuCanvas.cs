/******************************************************************************************************
FileName: MenuCanvas.cs
FileType: Visual C# Source file
Size : 26206
Author : Hoang Duc Cong (dhx496@uregina.ca)
Created On : 3/31/2023 9:56:39 AM
Copy Rights : University of Regina
Description : To update scores
*******************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuCanvas: MonoBehaviour
{
    public TMP_Text[] scoreTextboxes = new TMP_Text[2];

    // Start is called before the first frame update
    void Start()
    {
        scoreTextboxes[0].text = "" + GameManager.GetInstance().scores[0];
        scoreTextboxes[1].text = "" + GameManager.GetInstance().scores[1];
    }

    // Update is called once per frame
    void Update()
    {
        
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log("Button A was pressed");
            //textbox.text = "Button A Pressed";
        }

        if (OVRInput.GetUp(OVRInput.RawButton.B))
        {
            Debug.Log("Button B was pressed");
            //textbox.text = "Button B Released";
        }
    }
}
