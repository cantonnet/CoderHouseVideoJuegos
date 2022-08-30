using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDelSpawn : MonoBehaviour
{
    public GameObject criatura;
    public float tiempodespawn = 5f;
    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        instanciar();
    }

    private void instanciar()
    {
        if (time >= tiempodespawn)
        {
            Instantiate(criatura, transform);
            time = 0f;
        }
    }
}
