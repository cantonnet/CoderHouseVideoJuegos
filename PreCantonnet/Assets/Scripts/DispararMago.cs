using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararMago : MonoBehaviour
{
    public GameObject poder;
    private bool canShoot = true;
    float cantidadmp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cantidadmp > 14)
        {
            if(Input.GetKeyDown(KeyCode.E)){
                if (canShoot)
                {
                    Invoke("instanciar", 0.85f);
                    canShoot = false;
                    Invoke("ResetShoot", 2f);
                }
        }
        }
    }
    
        private void ResetShoot()
    {
        canShoot = true;
    }

    private void instanciar()
    {
        Instantiate(poder, transform.position, transform.rotation);
    }

    public void tomarmp(float nuevoValor)
    {
        cantidadmp = nuevoValor;
    }
    
}
