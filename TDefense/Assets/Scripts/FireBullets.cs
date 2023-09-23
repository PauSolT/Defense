using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireBullets : MonoBehaviour
{
    public SoundManager soundManager;

    public GameObject bullet;
    public Transform bulletSpawnPoint;
    private readonly float baseFireRate = 1f;
    public float BaseFireRate { get => baseFireRate; }

    float fireRate = 0f;
    public float FireRate { get => fireRate; set => fireRate = value; }

    bool canFire = true;

    int baseBulletDamage = 5;
    private int currentBulletDamage = 0;
    public int BaseBulletDamage { get => baseBulletDamage; }
    public int CurrentBulletDamage { get => currentBulletDamage; set => currentBulletDamage = value; }

    readonly float baseCritRate = 0f;
    float critRate;
    readonly float baseCritDamage = 50f;
    float critDamage = 50f;
    public float BaseCritRate { get => baseCritRate; }
    public float CritRate { get => critRate; set => critRate = value; }
    public float CritDamage { get => critDamage; set => critDamage = value; }
    public float BaseCritDamage { get => baseCritDamage; }

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            canFire = false;
        }
    }

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
        canFire = false;
        GameObject bulletInstance = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
        StartCoroutine(FireRateHandler());
        yield return null;
    }

    IEnumerator FireRateHandler()
    {
        float timeToNextFire = 1 / fireRate;
        soundManager.audios[3].Play();
        yield return new WaitForSeconds(timeToNextFire);
        canFire = true;
    }
}
