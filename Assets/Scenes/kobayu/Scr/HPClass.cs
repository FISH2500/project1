using UnityEngine;

[System.Serializable]
public class HPClass
{
    public float HP = 0;//HP。ここは設定しない。MaxHPで上書きされる。
    public float MaxHP = 0;//最大HP。この値をHPに上書きする。
    public void HPUD(float D)//HP増やしたり減らしたりするときに使うメソッド。
    {
        HP += D;
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
    }
}
