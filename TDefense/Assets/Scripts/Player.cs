using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    HealthComponent playerHealth;
    [SerializeField]
    Camera mainCamera;

    public GameObject bullet;
    public GameObject turret;
    public Transform bulletSpawnPoint;

    public void InitPlayer()
    {
        playerHealth = GetComponent<HealthComponent>();
        playerHealth.InitHealthComponent();
    }

    Vector3 GetMousePosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }

    Vector3 LookAtMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    // Start is called before the first frame update
    void Start()
    {
        InitPlayer();
        playerHealth.LogHealth();
    }

    // Update is called once per frame
    void Update()
    {
        turret.transform.rotation = Quaternion.LookRotation(Vector3.forward, LookAtMousePosition() - transform.position); ;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, bulletSpawnPoint.position, turret.transform.rotation);
        }

    }
}
