using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapCreater : MonoBehaviour
{
    public GameObject wall;
    public GameObject floor;
    public GameObject door;
    public GameObject lightedFloor;
    public GameObject treasure;
    public GameObject stairs;
    public Transform player;
    public Transform danguonPartsParentTransform;
    public Floor map;
    public PlayerController playerController;
    public Vector3 playerInitialPosition;

    int[,] mapPlan;

    // Start is called before the first frame update
    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        //Debug.Log(currentSceneName);
        if (currentSceneName.Equals("Floor1FScene"))
        {
            mapPlan = map.FloorMap1F();
        }
        else if (currentSceneName.Equals("Floor2FScene"))
        {
            mapPlan = map.FloorMap2F();
        }
        
        DrawMap(mapPlan);
        player.transform.position = playerInitialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void DrawMap(int[,] mapPlan)
    {
        int lenI = mapPlan.GetLength(0);
        int lenJ = mapPlan.GetLength(1);

        for (int i = 0; i < lenI; i++)
        {
            for(int j = 0; j < lenJ; j++)
            {
                if (mapPlan[i,j] == 1)
                {
                    CreateDanguon(i, j, 0.5f, wall);
                }

                if(mapPlan[i,j] == 0)
                {
                    CreateDanguon(i, j, -1.0f, floor);
                }

                if (mapPlan[i, j] == 3)
                {
                    CreateDanguon(i, j, -1.0f, lightedFloor);
                }

                if(mapPlan[i, j] == 4)
                {
                    CreateDanguon(i, j, -1.0f, treasure);
                }

                if (mapPlan[i, j] == 5)
                {
                    CreateDanguon(i, j, -1.0f, stairs);
                }

                if (mapPlan[i, j] == 2)
                {
                    if(mapPlan[i, j-1] == 1 && mapPlan[i, j+1] == 1)//角に扉置いたらエラーなる
                    {
                        //壁と扉が平行になるように回転させる
                        GameObject door1 = CreateDanguon(i, j, -1.0f, door);
                        door1.transform.Rotate(0, 90, 0);
                    }
                    else
                    {
                        CreateDanguon(i, j, -1.0f, door);
                    }
                }
            }
        }
    }

    GameObject CreateDanguon(int x, int z, float y, GameObject prefab)
    {
        GameObject danguonParts = Instantiate(
            prefab,
            new Vector3(x, y, z),
            Quaternion.identity
            );

        danguonParts.transform.parent = danguonPartsParentTransform; //一つのオブジェクトに生成したダンジョンを入れる
        return danguonParts;
    }
}
