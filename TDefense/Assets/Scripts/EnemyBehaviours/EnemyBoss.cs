using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> sprites;
    public List<RuntimeAnimatorController> animators;
    void Start()
    {
        SpriteRenderer bossSprite = GetComponentInChildren<SpriteRenderer>();
        Animator bossAnimator = GetComponentInChildren<Animator>();
        int currentWave = GetComponent<Enemy>().waveManager.Wave;

        if (currentWave % 100 == 20)
        {
            bossSprite.sprite = sprites[0];
            bossAnimator.runtimeAnimatorController = animators[0];
        } else if (currentWave % 100 == 40)
        {
            bossSprite.sprite = sprites[1];
            bossAnimator.runtimeAnimatorController = animators[1];
        }
        else if (currentWave % 100 == 60)
        {
            bossSprite.sprite = sprites[2];
            bossAnimator.runtimeAnimatorController = animators[2];
        }
        else if (currentWave % 100 == 80)
        {
            bossSprite.sprite = sprites[3];
            bossAnimator.runtimeAnimatorController = animators[3];
        }
        else if (currentWave % 100 == 0)
        {
            bossSprite.sprite = sprites[4];
            bossAnimator.runtimeAnimatorController = animators[4];
        }


        GetComponent<DamageComponent>().DamagePoints = FindFirstObjectByType<Player>().gameObject.GetComponent<HealthComponent>().MaxHealthPoints;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

   
}
