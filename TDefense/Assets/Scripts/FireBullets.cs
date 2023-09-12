using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;

    public float fireRate;

    bool canFire = true;

    int baseBulletDamage = 5;
    private int currentBulletDamage = 0;
    public int BaseBulletDamage { get => baseBulletDamage; }
    public int CurrentBulletDamage { get => currentBulletDamage; set => currentBulletDamage = value; }



    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, LookAtMousePosition() - transform.position);
        if (Input.GetKey(KeyCode.Mouse0) && canFire)
        {
            StartCoroutine(Fire());
        }
    }

    
    Vector3 LookAtMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    // Start is called before the first frame update
    IEnumerator Fire()
    {
        Debug.Log(currentBulletDamage);
        canFire = false;
        GameObject bulletInstance = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
        bulletInstance.GetComponent<DamageComponent>().DamagePoints = currentBulletDamage;
        StartCoroutine(FireRateHandler());
        yield return null;
    }

    IEnumerator FireRateHandler()
    {
        float timeToNextFire = 1 / fireRate;
        yield return new WaitForSeconds(timeToNextFire);
        canFire = true;
    }
}
