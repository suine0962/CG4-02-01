using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backScript : MonoBehaviour
{
    ReflectionProbe probe;

    // Start is called before the first frame update
    void Start()
    {
        this.probe = GetComponent<ReflectionProbe>();
    }

    // Update is called once per frame
    void Update()
    {
        this.probe.transform.position =
           new Vector3(Camera.main.transform.position.x,
                       Camera.main.transform.position.y,
                       Camera.main.transform.position.z * 1);
        probe.RenderProbe();
    }
}
