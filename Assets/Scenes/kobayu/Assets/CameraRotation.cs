using UnityEngine;
using UnityEngine.InputSystem;


public class CameraRotation : MonoBehaviour
{
    public GameObject playerObj;//プレイヤーオブジェクト。
    public float sensitveMove = 0.8f;//カメラ感度。
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current == null || Keyboard.current == null)
            return; // デバイスが無ければ抜ける
        
        //カメラをマウスに合わせて回転させ、playerも同じく回転させる。(カメラをplayerの子オブジェクトにした場合。)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //float rotateX = Input.GetAxis("Mouse X") * sensitveMove;
        //float rotateY = Input.GetAxis("Mouse Y") * -sensitveMove;
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();//マウスの移動量を測定。
        float rotateX = mouseDelta.x * sensitveMove;
        float rotateY = mouseDelta.y * -sensitveMove;

        
        transform.Rotate(rotateY,0.0f,0.0f);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,0.0f,0.0f);

        //Vector3 EulerAngles = transform.eulerAngles;
        //EulerAngles.z = 0.0f;
        //transform.eulerAngles = EulerAngles;

        if(playerObj != null){
            playerObj.transform.Rotate(0.0f,rotateX,0.0f);
        }
    }
}
