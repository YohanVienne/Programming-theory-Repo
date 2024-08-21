using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    // Start is called before the first frame update
    override public void Start()
    {
        Debug.Log("I'm a dog !");
        base.Start();
        StartCoroutine(TickGetHealth());
    }

    // Update is called once per frame
    override public void Update()
    {
    }

    IEnumerator TickGetHealth()
    {
        yield return new WaitForSeconds(1);
        Health += 1;
        Debug.Log($"I have {Health} now");
        StartCoroutine(TickGetHealth());

    }

}
