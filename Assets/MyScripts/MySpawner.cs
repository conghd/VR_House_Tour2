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

public class MySpawner : MonoBehaviour
{
    public const int TYPE_TABLE = 0;
    public const int TYPE_SOFA = 1;
    public const int TYPE_TV_TABLE = 2;
    public const int TYPE_TORCHERE = 3;
    public const int TYPE_BED1 = 4;
    public const int TYPE_BED2 = 5;
    public const int NUM_TABLES = 4;
    public const int NUM_SOFAS = 4;
    public const int NUM_TV_TABLES = 2;
    public const int NUM_TORCHERES = 3;
    public const int NUM_BED1 = 3;
    public const int NUM_BED2 = 3;
    public GameObject[] tables = new GameObject[NUM_TABLES];
    public GameObject[] sofas = new GameObject[NUM_SOFAS];
    public GameObject[] tvTables = new GameObject[NUM_TV_TABLES];
    public GameObject[] torcheres = new GameObject[NUM_TORCHERES];
    public GameObject[] bed1s = new GameObject[NUM_BED1];
    public GameObject[] bed2s = new GameObject[NUM_BED2];
    int tableIndex = -1, sofaIndex = -1, tvTableIndex = -1, torchereIndex = -1, bed1Index = -1, bed2Index = -1;
    GameObject table = null, sofa = null, tvTable = null, torchere = null, bed1 = null, bed2 = null;


    static MySpawner instance;
    public static MySpawner GetInstance() { return instance; }
    void Start()
    {
        //source = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        tableIndex = sofaIndex = tvTableIndex = torchereIndex = bed1Index = bed2Index = -1;
        ChangeFurniture(TYPE_TABLE);
        ChangeFurniture(TYPE_SOFA);
        ChangeFurniture(TYPE_TV_TABLE);
        ChangeFurniture(TYPE_TORCHERE);
        ChangeFurniture(TYPE_BED1);
        ChangeFurniture(TYPE_BED2);
    }


    void Update()
    {
       // Leave empty 
    }

    void Spawn()
    {
    }

    public void ChangeFurniture(int type) {
        if (type == TYPE_TABLE) {
            if (table != null) {
                table.transform.parent = null;
                Destroy(table);
            }
            //tableIndex = (tableIndex + 1) % NUM_TABLES;
            table = Instantiate(tables[++tableIndex % NUM_TABLES]);
            table.transform.parent = gameObject.transform;
        } else if (type == TYPE_SOFA) {
            if (sofa!= null) {
                sofa.transform.parent = null;
                Destroy(sofa);
            }

            sofa = Instantiate(sofas[++sofaIndex % NUM_SOFAS]);
            table.transform.parent = gameObject.transform;
        } else if (type == TYPE_TV_TABLE) {
            if (tvTable!= null) {
                tvTable.transform.parent = null;
                Destroy(tvTable);
            }

            tvTable = Instantiate(tvTables[++tvTableIndex % NUM_TV_TABLES]);
            tvTable.transform.parent = gameObject.transform;
        } else if (type == TYPE_TORCHERE) {
            if (torchere!= null) {
                torchere.transform.parent = null;
                Destroy(torchere);
            }

            torchere = Instantiate(torcheres[++torchereIndex % NUM_TORCHERES]);
            torchere.transform.parent = gameObject.transform;
        } else if (type == TYPE_BED1) {
            if (bed1 != null) {
                bed1.transform.parent = null;
                Destroy(bed1);
            }

            bed1 = Instantiate(bed1s[++bed1Index % NUM_BED1]);
            bed1.transform.parent = gameObject.transform;
        } else if (type == TYPE_BED2) {
            if (bed2 != null) {
                bed2.transform.parent = null;
                Destroy(bed2);
            }

            bed2 = Instantiate(bed2s[++bed2Index % NUM_BED2]);
            bed2.transform.parent = gameObject.transform;
        }
    }
}
