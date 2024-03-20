using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType {Straight, Spin}
    public enum Objective : int {Enemy=0, Player=1}
    [Header("Bullet Attributes")]
    public Objective BulletObjective;
    public GameObject Bullet;
    public float Bulletlife=7f;
    public float Bulletspeed=1f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawner;
    [SerializeField]private float FiringRate = 0.5f;

    private GameObject spawnedbullet;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(spawner== SpawnerType.Spin){
            transform.eulerAngles= new Vector3(0f,0f,transform.eulerAngles.z+1f);
        }
        if(timer>=FiringRate){
            Fire();
            timer=0;
        }
    }

    private void Fire(){
        if(Bullet){
            spawnedbullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            spawnedbullet.GetComponent<Bullet>().objective = (Bullet.Objective)BulletObjective;
            spawnedbullet.GetComponent<Bullet>().Speed = Bulletspeed;
            spawnedbullet.GetComponent<Bullet>().Bulletlife = Bulletlife;
            spawnedbullet.transform.rotation = transform.rotation;
        }
    }
}