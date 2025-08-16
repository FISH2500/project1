using UnityEngine;

public class enemy_com : MonoBehaviour
{
    ///ピレイヤーを見つける方法////
    /// 前方にRayを飛ばす
    /// プレイヤーに当たったらプレイヤーを追いかける。
    /// Rayの範囲から外れたらプレイヤーを追跡するのをやめる。
    public Animator EnemyAni;//敵のアニメーター。
    public Vector3 EnemyV;//敵が動く方向。アニメーターによって制御。
    public bool EnemyLookAt;//敵はプレイヤーを常に見るか？アニメーターによって制御。
    private GameObject Player;//プレイヤーのゲームオブジェクト。
    public Transform RayOrigin;//Rayを飛ばす元オブジェクト。z軸方向にRayを飛ばす。
    public float RayDstns = 100f;//Rayの長さ。敵の視力の良さ。
    public float WallRayDstns = 5f;//壁があるか調査する時の光線の長さ。
    private bool LookWall = false;//壁の直前にいるか？
    public float WallTurnAngle = 10;//壁があるとき、Uターンする速度。
    public float RotateAngle = 5;//プレイヤーが見つからないとき、常にこの角度に回る。
    private Rigidbody rb;//リジッドボディ。
    public float AttackDstns = 10;//攻撃する距離。
    private float EnemyWarningTimer;//敵がプレイヤーを見失ったのち、警戒する時のタイマー。
    public float EnemyWarningTime;//敵がプレイヤーを見失ったのち、警戒する時間。これが過ぎてから初めてプレイヤーを見失う。
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        SearchPlayerMethod();
        SearchWallMethod();
        EnemyMoveAndLookMethod();
        CanIAttackMethod();
    }

    void SearchPlayerMethod()//プレイヤーを見つけるメソッド。
    {
        Vector3 RayDirection = RayOrigin.forward;
        Vector3 RayOriginPo = RayOrigin.position;

        RaycastHit[] hits = Physics.RaycastAll(RayOriginPo, RayDirection, RayDstns);

        System.Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Wall"))
            {
                Player = null;
                return;
            }
            else if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("PlayerRayHit!!");
                Player = hit.collider.gameObject;
                return;
            }
        }
        Player = null;
    }
    void SearchWallMethod()//壁が前にあるか調べる
    {
        Vector3 RayDirection = RayOrigin.forward;
        Vector3 RayOriginPo = RayOrigin.position;

        RaycastHit[] hits = Physics.RaycastAll(RayOriginPo, RayDirection, WallRayDstns);

        System.Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Wall"))
            {
                LookWall = true;
                return;
            }

        }
        LookWall = false;
    }


    void EnemyMoveAndLookMethod()//敵を動かしたり向きを変えたりする。
    {
        rb.AddRelativeForce(EnemyV);
        if (Player != null)
        {
            EnemyAni.SetBool("PlayerLook", true);
            if (EnemyLookAt)
            {
                transform.LookAt(Player.transform);
            }
            EnemyWarningTimer = 0;
        }
        else
        {
            if (EnemyWarningTimer > EnemyWarningTime)
            {
                EnemyAni.SetBool("PlayerLook", false);
            }
            else
            {
                EnemyWarningTimer += Time.deltaTime;
            }

            if (LookWall)
            {
                transform.Rotate(0, WallTurnAngle * Time.deltaTime, 0);
            }
            else
            {
                transform.Rotate(0, RotateAngle * Time.deltaTime, 0);
            }
        }
    }
    void CanIAttackMethod()
    {
        if (Player == null)
        {
            EnemyAni.SetBool("Attack", false);
            return;
        }
        float Dstns = Vector3.Distance(Player.transform.position, transform.position);
        if (Dstns < AttackDstns)
        {
            EnemyAni.SetBool("Attack", true);
        }
        else
        {
            EnemyAni.SetBool("Attack", false);
        }
    }
}
