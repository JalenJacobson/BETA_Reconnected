using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivate : MonoBehaviour
{
    public Animator anim;
    public GameObject EnemyManager;
    public GameObject Target1, Target2, Target3, Target4;
    public GameObject Pump, Gears, Brute, Sat, Luz;
    public GameObject Lazer1, Lazer2, Lazer3, Lazer4;
    public GameObject Empty1, Empty2, Empty3, Empty4;

    public healthBar healthBar;

    public float startHealth = 100; 
    public float currentHealth; 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = startHealth;
        healthBar.setHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {

      if(other.name.Contains("Gear") || other.name.Contains("Brute") || other.name.Contains("Luz") || other.name.Contains("Pump") || other.name.Contains("Sat"))
      {
        anim.Play("SS_BOSS_UP");
        StartCoroutine(Sequence1());
      }
    }

    public void takeDamage(float damageGiven)
    {
      currentHealth -= damageGiven;
      healthBar.setHealth(currentHealth);
    }  

    IEnumerator Sequence1()
    {
        yield return new WaitForSeconds(10f);
        anim.Play("Boss_Squares");
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(9f);
        anim.Play("Boss_Stationary");
        yield return new WaitForSeconds(1f);
        anim.Play("Boss_SmallSquares");
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(9f);
        anim.Play("Boss_Stationary");
        yield return new WaitForSeconds(1f);
        anim.Play("Boss_VerticleLines");
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(7f);
        anim.Play("Boss_Stationary");
        yield return new WaitForSeconds(1f);
        StartCoroutine(FollowBots1());
    }
    IEnumerator Sequence1_2()
    {
        yield return new WaitForSeconds(10f);
        anim.Play("Boss_Squares");
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(.1f);
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(9f);
        anim.Play("Boss_Stationary");
        yield return new WaitForSeconds(1f);
        anim.Play("Boss_SmallSquares");
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(.1f);
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(9f);
        anim.Play("Boss_Stationary");
        yield return new WaitForSeconds(1f);
        anim.Play("Boss_VerticleLines");
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(.1f);
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(7f);
        anim.Play("Boss_Stationary");
        yield return new WaitForSeconds(1f);
        StartCoroutine(FollowBots2());
    }

    IEnumerator Sequence2()
    {
        yield return new WaitForSeconds(10f);
        anim.Play("Boss_HorizontalLines");
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(.1f);
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(5f);
        anim.Play("Boss_SmallCircles");
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(.1f);
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(5.5f);
        anim.Play("Boss_Circles");
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(.1f);
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(9f);
        anim.Play("Boss_HorizontalLines");
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(.1f);
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(.1f);
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(5f);
        anim.Play("Boss_SmallCircles");
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(.1f);
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(.1f);
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(5.5f);
        anim.Play("Boss_Circles");
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(.1f);
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(.1f);
        EnemyManager.SendMessage("Spawn1");
        EnemyManager.SendMessage("Spawn2");
        EnemyManager.SendMessage("Spawn3");
        EnemyManager.SendMessage("Spawn4");
        yield return new WaitForSeconds(9f);
        anim.Play("Boss_Stationary");
        yield return new WaitForSeconds(1f);
        StartCoroutine(FollowBots2());
    }


    IEnumerator FollowBots1()
    {
        Lazer1.SendMessage("Slow");
        Lazer2.SendMessage("Slow");
        Lazer3.SendMessage("Slow");
        Lazer4.SendMessage("Slow");
        yield return new WaitForSeconds(1f);
        Target1.transform.SetParent(Pump.transform);
        Target2.transform.SetParent(Luz.transform);
        Target3.transform.SetParent(Brute.transform);
        Target4.transform.SetParent(Sat.transform);
        yield return new WaitForSeconds(.1f);
        Target1.transform.position = Pump.transform.position;
        Target2.transform.position = Luz.transform.position;
        Target3.transform.position = Brute.transform.position;
        Target4.transform.position = Sat.transform.position;
        anim.Play("Boss_FollowBots");   
        yield return new WaitForSeconds(15f);
        StartCoroutine(FollowEmpty());      
    }
    IEnumerator FollowBots2()
    {
        Lazer1.SendMessage("Slow2");
        Lazer2.SendMessage("Slow2");
        Lazer3.SendMessage("Slow2");
        Lazer4.SendMessage("Slow2");
        yield return new WaitForSeconds(1f);
        Target1.transform.SetParent(Pump.transform);
        Target2.transform.SetParent(Luz.transform);
        Target3.transform.SetParent(Brute.transform);
        Target4.transform.SetParent(Sat.transform);
        yield return new WaitForSeconds(.1f);
        Target1.transform.position = Pump.transform.position;
        Target2.transform.position = Luz.transform.position;
        Target3.transform.position = Brute.transform.position;
        Target4.transform.position = Sat.transform.position;
        anim.Play("Boss_FollowBots");   
        yield return new WaitForSeconds(15f);
        StartCoroutine(FollowEmpty());      
    }

    IEnumerator FollowEmpty()
    {
        EnemyManager.SendMessage("batterySpawn1");
        EnemyManager.SendMessage("batterySpawn2");
        Lazer1.SendMessage("Fast");
        Lazer2.SendMessage("Fast");
        Lazer3.SendMessage("Fast");
        Lazer4.SendMessage("Fast");
        yield return new WaitForSeconds(.1f);
        Target1.transform.SetParent(Empty1.transform);
        Target2.transform.SetParent(Empty2.transform);
        Target3.transform.SetParent(Empty3.transform);
        Target4.transform.SetParent(Empty4.transform);
        yield return new WaitForSeconds(.1f);
        Target1.transform.position = Empty1.transform.position;
        Target2.transform.position = Empty2.transform.position;
        Target3.transform.position = Empty3.transform.position;
        Target4.transform.position = Empty4.transform.position;   
        yield return new WaitForSeconds(3f);
        StartCoroutine(Sequence2());      
    }

  IEnumerator Spawn1()
    {
        yield return new WaitForSeconds(1f);
        EnemyManager.SendMessage("Spawn1");
        StartCoroutine(Spawn2());
    }

  IEnumerator Spawn2()
    {
        yield return new WaitForSeconds(1f);
        EnemyManager.SendMessage("Spawn2");
        StartCoroutine(Spawn3());
    }
  IEnumerator Spawn3()
    {
        yield return new WaitForSeconds(1f);
        EnemyManager.SendMessage("Spawn3");
        StartCoroutine(Spawn4());
    }
  IEnumerator Spawn4()
    {
        yield return new WaitForSeconds(1f);
        EnemyManager.SendMessage("Spawn4");
        StartCoroutine(Spawn1());
    }
}
