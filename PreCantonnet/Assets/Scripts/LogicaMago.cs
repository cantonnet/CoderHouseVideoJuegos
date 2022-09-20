using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LogicaMago : MonoBehaviour
{
    // public GameObject poder;
    [SerializeField] HUDManager HUDManager;
    [SerializeField] DispararMago DispararMago;
    public bool canrun = false;
    public float runmulti = 1.5f;
    public float speed = 2.7f;
    public float lateralspeed = 2.5f;
    public float rotationspeed = 1000f;
    public float recargamana;
    public float tiempoderecargamana = 5;
    // private bool canShoot = true;
    // private float cameraAxisX = 0f;
    public static event Action OnDead;
    private Animator anim;
    public float x, y, z;
    public int hp = 100;
    public int mp = 100;

    [SerializeField] WeaponManager WeaponManager;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("GAME OVER");
            LogicaMago.OnDead.Invoke();
        }
        correr();
        manaaumentar();
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        z = Input.GetAxis("Mouse X");
        if (canrun) {anim.SetBool("run", true);} else {anim.SetBool("run", false);}
        if (mp > 15)
        {
         bool atacando = Input.GetKeyDown(KeyCode.E);
         if (atacando) {anim.SetBool("ataque", true); mp = mp - 15; HUDManager.SetMPBar(mp); DispararMago.tomarmp(mp);}
        }
        bool atacando2 = Input.GetKeyUp(KeyCode.E);
        if (atacando2) anim.SetBool("ataque", false);
        // if (atacando) anim.SetTrigger("atacar");

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
        MovePlayer();
        RotatePlayer();

        // if(Input.GetKeyDown(KeyCode.E)){
        //     if (canShoot)
        //     {
        //         canShoot = false;
        //         Invoke("instanciar", 0.15f);
        //         Invoke("ResetShoot", 0.29f);
        //     }
        // }
    }

    private void MovePlayer()
    {
        transform.Translate(0, 0, y * speed * Time.deltaTime);
        transform.Translate(x * lateralspeed * Time.deltaTime, 0, 0);
    }

    public void RotatePlayer()
    {
        transform.Rotate(0, z * Time.deltaTime * rotationspeed, 0);
        // cameraAxisX += Input.GetAxis("Horizontal");
        // Quaternion newRotation = Quaternion.Euler(0, cameraAxisX, 0);
        // transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime *  rotationspeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        { 
            //agregar a listata
            other.gameObject.SetActive(false);
            WeaponManager.WeaponList.Add(other.gameObject);
            //cola
            WeaponManager.WeaponQueue.Enqueue(other.gameObject);

            //dic
            WeaponManager.WeaponDirectory.Add(other.gameObject.name,other.gameObject);
            Debug.Log(WeaponManager.WeaponDirectory[other.gameObject.name]);
        }
    }

    void manaaumentar()
    {
        recargamana = recargamana + Time.deltaTime;
        if (recargamana > tiempoderecargamana)
        {   
            if (mp < 100)
             {
                mp = mp + 10;
                HUDManager.SetMPBar(mp);
                DispararMago.tomarmp(mp);
             }
             recargamana = 0;
        }
    }

    void correr()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            canrun = false;
            speed = 2.7f;
            lateralspeed = 2.5f;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            canrun = true;
            speed = 4f;
            lateralspeed = 3f;
        }
    }

    // private void FixedUpdate() 
    //     {
    //     jugador.Move(new Vector3(x, 0, y) * speed * Time.deltaTime);
    //     // transform.Rotate(0, hor * Time.deltaTime * speedrotar, 0);
    // //     }

    // private void ResetShoot()
    // {
    //     canShoot = true;
    // }

    // private void instanciar()
    // {
    //     Instantiate(poder, transform.position, transform.rotation);
    // }
    
}
