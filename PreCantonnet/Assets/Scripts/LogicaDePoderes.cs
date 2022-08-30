using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDePoderes : MonoBehaviour
{
    public int speed = 6;
    float y;
    float time;
    float eliminaral = 5;
    // Start is called before the first frame update
    void Start()
    {
        y = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(0, 0, y * speed * Time.deltaTime);
        time += Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        DestroyGameObject();
    }

    void DestroyGameObject()
    {
        if (time >= eliminaral)
        {
            time = 0f;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Criatura"))
        { 
            Destroy(gameObject);
        }
    }
}
