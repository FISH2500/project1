using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }  
    public GameObject VendingCheckText;
    public GameObject VendingCanvas;

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


    void Update()
    {
        
    }
}
