using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }  
    public GameObject VendingCheckText;
    public GameObject VendingCanvas;
    public TextMeshProUGUI bulletetx;
    public TextMeshProUGUI allbulletetx;
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

    public void BulletOutPut(int bullete) 
    {
        bulletetx.text = "" + bullete;
    }
    public void AllBulletOutPut(int allbullete)
    {
        allbulletetx.text = "" + allbullete;
    }


    void Update()
    {
        
    }
}
