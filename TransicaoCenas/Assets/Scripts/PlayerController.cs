using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocidade;
    float movH, movV;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        movH = Input.GetAxis("Horizontal");
        movV = Input.GetAxis("Vertical");

        transform.Translate(
            new Vector3(movH, movV, 0f) * velocidade * Time.deltaTime
            );
    }
}
