using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    static int score;
    static int bajas;
    static float tiempo;
    public static GameManager instance;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            score = 0;
            bajas = 0;
            tiempo = 0;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
    }
}
