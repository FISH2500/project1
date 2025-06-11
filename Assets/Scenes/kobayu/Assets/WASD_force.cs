using UnityEngine;

public class WASD_force : MonoBehaviour
{
    public float movespeed;//動くスピード。
    private Rigidbody rb;//リジッドボディ。
    public bool W;//Wが押されているか？
    public bool S;//Sが押されているか？
    public bool A;//Aが押されているか？
    public bool D;//Dが押されているか？
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 V = new Vector3(0,0,0);
        if(W){
            V.z = movespeed;
        }else if(S){
            V.z = -movespeed;
        }
        if(A){
            V.x = movespeed;
        }else if(D){
            V.x = -movespeed;
        }

        rb.AddForce(V);
    }
}
