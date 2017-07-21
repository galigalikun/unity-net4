using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        aaa();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void aaa()
    {
        Task.Delay(100);
    }
}
