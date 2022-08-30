using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaMago : MonoBehaviour
{
    // public GameObject poder;
    public float speed = 4f;
    public float lateralspeed = 3f;
    public float rotationspeed = 1000f;
    // private bool canShoot = true;
    // private float cameraAxisX = 0f;
    
    private Animator anim;
    public float x, y, z;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        z = Input.GetAxis("Mouse X");

        bool atacando = Input.GetKeyDown(KeyCode.E);
        if (atacando) anim.SetBool("ataque", true);
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
