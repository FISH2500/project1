using UnityEngine;

public class FlashByEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject FlashObject;
    private float Timer = 0.0f;
    void start()
    {
        FlashObject.SetActive(false);
    }
    void Update()
    {
        if (Timer > 0.0f)
        {
            Timer -= Time.deltaTime;
            FlashObject.SetActive(true);
        }
        else
        {
            FlashObject.SetActive(false);
        }
    }
    public void FlashPlayer(float Time)
    {
        Timer = Time;
    }
}
