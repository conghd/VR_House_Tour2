/******************************************************************************************************
FileName: SceneChange.cs
FileType: Visual C# Source file
Size : 26206
Author : Hoang Duc Cong (dhx496@uregina.ca)
Created On : 3/25/2023 9:56:39 AM
Copy Rights : University of Regina
Description : To change scenes
*******************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChange : MonoBehaviour
{
    public string CurrentSceneName;
    public string NextSceneName;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (CurrentSceneName == "Level1Scene")
        {
            GameManager.GetInstance().SetLevel(GameManager.GAME_LEVEL1);
        }
        else if (CurrentSceneName == "Level2Scene")
        {
            GameManager.GetInstance().SetLevel(GameManager.GAME_LEVEL2);
        }

        scoreText.text = "" + GameManager.GetInstance().GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("Button A Pressed");
            // Play the sound
            GameManager.GetInstance().PlaySound(GameManager.SOUND_SCENE_CHANGE);

            // Change the scene
            SceneManager.LoadScene(NextSceneName);
        }
    }
}