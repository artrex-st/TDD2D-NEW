using UnityEngine;
using System.Collections;

public class SobeDesce : MonoBehaviour {


    public bool subir,descer;
    public LayerMask layerRay, layerRay2;

    /*
    //desenhar raycast Circle
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(GetComponent<Transform>().transform.position, 0.5f);
    }
    */
    void Update () {
        subir = Physics2D.OverlapCircle(GetComponent<Transform>().transform.position, 0.5f, layerRay);
        descer = Physics2D.OverlapCircle(GetComponent<Transform>().transform.position, 0.5f, layerRay2);
        if (subir && !descer)
        {
            GetComponent<ConstantForce2D>().force = new Vector2(0, 15);
            GetComponent<ConstantForce2D>().relativeForce = new Vector2(0, 10);
        }
        if(!subir || descer)
        {
            GetComponent<ConstantForce2D>().force = new Vector2(0, 0);
            GetComponent<ConstantForce2D>().relativeForce = new Vector2(0, 0);
        }
    }
}
