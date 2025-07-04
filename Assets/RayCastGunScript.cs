using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class RayCastGunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate=15f;
    
    public Camera fpscam; 
    private float nextTimeFire;
    void Update()
    {
        
        if (Mouse.current.leftButton.isPressed && Time.time>=nextTimeFire)
        {
            Debug.Log("Fire!!");
            nextTimeFire = Time.time+1f/fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward,out hit, range)) 
        {
            Debug.Log(hit.transform.name);
            TargetScript target=hit.transform.GetComponent<TargetScript>();

            if (target!=null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
