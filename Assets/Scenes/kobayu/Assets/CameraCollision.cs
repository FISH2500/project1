using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    //カメラが壁を貫通しないためのスクリプト。
    public GameObject Camera;//カメラコンポーネントを持ったオブジェクト。
    public float RayDistance = 10f;
    public LayerMask hitLayer;//ヒット対象レイヤー。このレイヤーを持ったオブジェクトに当たったら実行。
    public GameObject RayOrigin;//Rayの発生元。ForWard方向にRayを発射する。
    private Vector3 EndCameraPos;//最終的なカメラの位置
    public float CameraMoveSpeed;//カメラの動くスピード
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EndCameraPos = Camera.transform.localPosition;
        EndCameraPos.z = -RayDistance;
        Camera.transform.localPosition = EndCameraPos;
    }

    // Update is called once per frame
    void Update()
    {
        //Rayを飛ばして、hitLayerに合ったLayerを持ったオブジェクトにぶつかったらカメラをプレイヤーに近づける。(z座標が０になる。)
        //Rayを飛ばす
        Ray ray = new Ray(RayOrigin.transform.position,-RayOrigin.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,RayDistance,hitLayer)){
            EndCameraPos = hit.point;
            EndCameraPos = Camera.transform.InverseTransformPoint(EndCameraPos);
            Debug.Log("RayHit!!! by CameraCollision(scr)");
        }else{
            Vector3 position = Camera.transform.localPosition;
            position.z = -RayDistance;
            EndCameraPos = position;
        }

        Camera.transform.localPosition = Vector3.Lerp(Camera.transform.localPosition,EndCameraPos,CameraMoveSpeed);
    }
}
