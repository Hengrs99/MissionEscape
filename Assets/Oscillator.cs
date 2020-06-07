﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;

    float movementFactor;
    float cycles;
    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSinWawe = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWawe / 2f + 0.5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
