using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float aggroRange;
    [SerializeField] public float speed = 2f;
    [SerializeField] public int scoreAmount;
    public bool scoreUpdated = false;


}
