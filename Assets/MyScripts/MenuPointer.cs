/******************************************************************************************************
FileName: MenuPointer.cs
FileType: Visual C# Source file
Size : 26206
Author : Hoang Duc Cong (dhx496@uregina.ca)
Created On : 3/31/2023 9:56:39 AM
Copy Rights : University of Regina
Description : To handle raycast
*******************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuPointer : MonoBehaviour
{
    public Button[] buttons = new Button[2];
    public LineRenderer Line;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Line.SetPosition(0, transform.position);
        Line.SetPosition(1, transform.position + (transform.forward * 20));

        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit);

        if (hit.collider)
        {
            if (hit.collider.CompareTag("button"))
            {
                int i = 0;

                if (buttons[0].name == hit.collider.name) {
                    i = 0;
                } else if (buttons[1].name == hit.collider.name) {
                    i = 1;
                }
                buttons[i].Select();
                Line.SetPosition(1, hit.point);

                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    ExecuteEvents.Execute(buttons[i].gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
                }

            }
            else
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
        } else {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void ChangeScene(string sceneName)
    {
        GameManager.GetInstance().PlaySound(GameManager.SOUND_SCENE_CHANGE);
        SceneManager.LoadScene(sceneName);
    }
}
