using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class enemyRespawnSystem : MonoBehaviour
{
    public GameObject[] Enemy;//生成する敵。
    public int Amount;//全体でどれくらい敵を生成するか？
    public Transform StartRange;//生成する範囲の始まり
    public Transform EndRange;//生成する範囲の終わり
    private List<GameObject> EnemyList = new List<GameObject>();
    private RespawnSystem RespawnSystem_scr;//壁を生成するシステム。
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RespawnSystem_scr = FindObjectOfType<RespawnSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!RespawnSystem_scr.RunEnd) return;
        
        if (Amount >= EnemyList.Count)
        {
            RespornMethod();
        }
        EnemyList.RemoveAll(obj => obj == null);
    }

    void RespornMethod()
    {
        float PosX = Random.Range(StartRange.position.x, EndRange.position.x);
        float PosY = Random.Range(StartRange.position.y, EndRange.position.y);
        float PosZ = Random.Range(StartRange.position.z, EndRange.position.z);

        PosX = Mathf.Round(PosX);
        PosY = Mathf.Round(PosY);
        PosZ = Mathf.Round(PosZ);

        float randomAngle = 90f * Random.Range(0, 2);

        int Index = Random.Range(0, Enemy.Length);

        GameObject Obj2 = Instantiate(Enemy[Index], new Vector3(PosX, PosY, PosZ), Enemy[Index].transform.rotation);
        EnemyList.Add(Obj2);
        Obj2.SetActive(true);
    }
}
