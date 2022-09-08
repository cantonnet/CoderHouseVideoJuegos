using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Slime Data", menuName = "Crear Slime Data")]
public class SlimeData : ScriptableObject
{
    //Desing Data
    [Header("Movimiento")]
    [SerializeField]
    [Range(1f, 10f)]
    public float speed = 2f;

    [Header("Caracteristicas")]
    [SerializeField]
    [Range(1, 10)]
    public int escalamenor = 1;

    [SerializeField]
    [Range(1, 10)]
    public int escalamayor = 4;

    [SerializeField]
    [Range(1, 10)]
    public int vida = 3;

    [SerializeField]
    [Range(1, 10)]
    public int damage = 1;



}
