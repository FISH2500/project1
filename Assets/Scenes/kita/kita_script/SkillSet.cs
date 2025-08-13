
using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SkillSet : MonoBehaviour
{
    public List<GameObject> SkillList=new List<GameObject>();

    public List<GameObject> SkillSelect = new List<GameObject>();

    public List<int> PreviewSkillID=new List<int>();

    

    public static int VendingCount=-1;

    public int VendingID;


    void Start()
    {
        

        VendingCount++;

        VendingID = VendingCount;

        Debug.Log("ID"+VendingID);


        //for (int i = 0; i < 3; i++)//3個のアイテムをセット
        //{
        //    int isSkillID = Random.Range(0, SkillList.Count);
        //    Debug.Log(isSkillID + "をセット");

        //    for(int j = 0; j < 3; j++) 
        //    {
        //        if (PreviewSkillID[j] == isSkillID) isSuffer = true;
        //    }

            

        //    SkillSelect.Add(SkillList[isSkillID]);


        //    //switch (isSkillID)
        //    //{
        //    //    case 0: Debug.Log(isSkillID + "をセット"); SkillSelect.Add(SkillList[isSkillID]); break;

        //    //    case 1: Debug.Log(isSkillID + "をセット"); SkillSelect.Add(SkillList[isSkillID]); break;

        //    //    case 2: Debug.Log(isSkillID + "をセット"); SkillSelect.Add(SkillList[isSkillID]); break;

        //    //    case 3: Debug.Log(isSkillID + "をセット"); SkillSelect.Add(SkillList[isSkillID]); break;

        //    //}




        //}

        List<GameObject> shuffled = new List<GameObject>(SkillList);
        for (int i = 0; i < shuffled.Count; i++)
        {
            int randomIndex = Random.Range(i, shuffled.Count);
            GameObject temp = shuffled[i];
            shuffled[i] = shuffled[randomIndex];
            shuffled[randomIndex] = temp;
        }

        // 最初の3つを追加
        for (int i = 0; i < 3; i++)
        {
            SkillSelect.Add(shuffled[i]);
            Debug.Log(i + ": " + shuffled[i].name + " をセット");

        }


        UIManager.Instance.SkillSelectSet(SkillSelect);//VendingCanvasにスキルUIの表示

        //SkillSetFunc();

    }



    void Update()
    {
        
    }
}
