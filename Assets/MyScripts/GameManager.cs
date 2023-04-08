/******************************************************************************************************
FileName: GameManager.cs
FileType: Visual C# Source file
Size : 26206
Author : Hoang Duc Cong (dhx496@uregina.ca)
Created On : 3/25/2023 9:56:39 AM
Copy Rights : University of Regina
Description : To play noise
*******************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int GAME_LEVEL1 = 0;
    public const int GAME_LEVEL2 = 1;

    public const int SOUND_SCENE_CHANGE = 0;
    public const int SOUND_DESTROY_CUBE = 1;

    public int[] scores = new int[2];
    private int level = 0;

    public AudioClip[] clips = new AudioClip[2];
    public AudioSource source;

    public static GameManager instance;

    public static GameManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print("game Manager");
    }

    public void SetLevel(int level)
    {
        if (level >= 0 && level <= 1)
        {
            this.level = level;
        }
    }

    public int GetLevel()
    {
        return this.level;
    }

    public void IncreaseScore()
    {
        this.scores[level] += 1;
    }

    public int GetScore(int level)
    {
        if (level < 0 || level > 1)
            return 0;

        return scores[level];
    }

    public int GetScore()
    {
        return scores[level];
    }
    
    public void PlaySound(int sound)
    {
        if (sound < 0 || sound > 1)
            return;

        source.PlayOneShot(clips[sound]);
    }
}