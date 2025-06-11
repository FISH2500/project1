using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RespawnSystem : MonoBehaviour
{
    public WallRespawnObj[] WallObj;//自販機や壁などの生成物を管理するスクリプト。ここにオブジェクトを代入。
    private int Index;//リスポーンさせるときに何番のオブジェクトを生成するかここで決める。
    public Transform StartRange;//生成する範囲の始まり
    public Transform EndRange;//生成する範囲の終わり
    //public GameObject Obj;//リスポーンさせるオブジェ
    public int Amount = 400;//リスポーンさせる数。
    private int MaxAmount = 0;//実行中にこれ以上増やせないか調べるための変数。随時更新される。
    private List<GameObject> ObjList = new List<GameObject>();
    public bool RunEnd = false;//処理が終わったか？
    private float EndTime = 0.7f;//処理が終わる時間。MaxAmountが更新されるとリセットされるタイマーがこれを超えると処理が終わる。
    public float Timer = 0.0f;//タイマー。
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (WallRespawnObj Wall in WallObj)
        {
            Wall.Obj.SetActive(false);
        }

        RunEnd = false;
        StartCoroutine(RespornMethodWhile());
    }

    // Update is called once per frame

    void RespornMethod(){
        float PosX = Random.Range(StartRange.position.x,EndRange.position.x);
        float PosY = Random.Range(StartRange.position.y,EndRange.position.y);
        float PosZ = Random.Range(StartRange.position.z,EndRange.position.z);

        PosX = Mathf.Round(PosX);
        PosY = Mathf.Round(PosY);
        PosZ = Mathf.Round(PosZ);

        float randomAngle = 90f * Random.Range(0, 2);
        WallObj[Index].Obj.transform.rotation = Quaternion.Euler(0f, randomAngle, 0f);

        GameObject Obj2 = Instantiate(WallObj[Index].Obj,new Vector3(PosX,PosY,PosZ),WallObj[Index].Obj.transform.rotation);
        ObjList.Add(Obj2);
        Obj2.SetActive(true);
    }

    IEnumerator RespornMethodWhile()
    {
        Timer = 0.0f;
        int Count = 0;
        Index = 0;
        while (Timer <= EndTime)
        {
            if (WallObj[Index].Amount < Count)
            {
                Index++;
                Count = 0;
            }
            Timer += Time.deltaTime;
            if (Amount > ObjList.Count)
            {
                RespornMethod();
                Count++;
            }
            if (MaxAmount < ObjList.Count)
            {
                MaxAmount = ObjList.Count;
                Timer = 0.0f;
            }
            ObjList.RemoveAll(obj => obj == null);

            yield return null;
        }

        RunEnd = true;
    }
}
