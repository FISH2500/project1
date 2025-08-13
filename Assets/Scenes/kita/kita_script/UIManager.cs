using UnityEngine;
<<<<<<< Updated upstream

=======
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }  
    public GameObject VendingCheckText;
    public GameObject VendingCanvas;
<<<<<<< Updated upstream

=======
    public TextMeshProUGUI bulletetx;
    public TextMeshProUGUI allbulletetx;
    public SkillSet skillset;
    public List<Transform> Canvas = new List<Transform>();
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    private void Awake()
    {
        Instance = this;
    }

    public void SetVendingCheckUI(bool isCheck)
    {
        VendingCheckText.SetActive(isCheck);
    }

    public void ShowVending(bool isShow)
    {
        VendingCanvas.SetActive(isShow);
    }

<<<<<<< Updated upstream
=======
    public void BulletOutPut(int bullete) 
    {
        bulletetx.text = "" + bullete;
    }
    public void AllBulletOutPut(int allbullete)
    {
        allbulletetx.text = "" + allbullete;
    }

    public void SkillSelectSet(List<GameObject> SkillSelect) 
    {
        for (int j = 0; j < SkillSelect.Count; j++)
        {
            GameObject skill = Instantiate(SkillSelect[j], new Vector3(0, 0, 0), Quaternion.identity, Canvas[j]);

            skill.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;

            skill.SetActive(false);
        }
    }
    public void SkillSetFunc(int VendingID)
    {
        Debug.Log("êUÇÍÇΩé©îÃã@ÇÃIDÇÕ" + VendingID);
        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < Canvas[i].childCount; j++) 
            {
                Canvas[i].GetChild(j).gameObject.SetActive(false);
            }
            
        }
        for (int i = 0; i < 3; i++)
        {
            Canvas[i].GetChild(VendingID).gameObject.SetActive(true);
        }

    }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

    void Update()
    {
        
    }
}
