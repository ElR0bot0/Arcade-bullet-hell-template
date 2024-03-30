using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    public float BackgroundSpeed = 1f;
    public GameObject Background;


    private GameObject BackgroundClone1;
    private GameObject BackgroundClone2;
    private float BackgroundWidth = 0f;
    private Vector3 PosicionInicial1;
    private Vector3 PosicionInicial2;
    // Start is called before the first frame update
    void Start()
    {
        if (Background)
        {
            PosicionInicial1= transform.position;
            BackgroundClone1 = Instantiate(Background, PosicionInicial1, Quaternion.identity);
            SpriteRenderer renderer = BackgroundClone1.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                // Get the bounds of the object
                Bounds bounds = renderer.bounds;

                // Get the width of the object (size in the X direction)
                BackgroundWidth = bounds.size.x;

            }
            PosicionInicial2 = new Vector3(BackgroundWidth-0.1f, 0f, 0f);
            BackgroundClone2 = Instantiate(Background, PosicionInicial2, Quaternion.identity);
        }
        Destroy(this.Background);
    }

    // Update is called once per frame
    void Update()
    {
        float NuevaPosicion1 = Mathf.Repeat(Time.time * BackgroundSpeed + PosicionInicial1.x, BackgroundWidth + PosicionInicial2.x - 0.1f);
        float NuevaPosicion2 = Mathf.Repeat(Time.time * BackgroundSpeed + PosicionInicial2.x, BackgroundWidth + PosicionInicial2.x - 0.1f);
        BackgroundClone1.transform.position = transform.position+ PosicionInicial2 + Vector3.left * NuevaPosicion1; 
        BackgroundClone2.transform.position = transform.position + PosicionInicial2 + Vector3.left * NuevaPosicion2;
    }
}
