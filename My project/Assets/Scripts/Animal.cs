using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private int health = 10;
    public int Health{get => health; set => health = value ;}

    public virtual void Start(){
        Debug.Log($"Hello Animal and I have {health} of health");
    }

    public virtual void Update() {

    }
}
