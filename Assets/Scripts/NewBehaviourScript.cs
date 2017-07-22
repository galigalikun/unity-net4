using System.Collections;
using System.Collections.Generic;
using TA = System.Threading.Tasks;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        Debug.Log("Start 1");
        System.Func<TA.Task> func = async () =>
        {
            var s = await aaa();
            Debug.Log($"func 1 {s}");
        };

        func();

        TA.Task.Run(() => Debug.Log(transform.position));
    }

    // Update is called once per frame
    void Update()
    {

    }

    async TA.Task<string> aaa()
    {
        Debug.Log("aaa start");
        for (var i = 0; i < 10; i++)
        {
            await TA.Task.Delay(1500);
            Debug.Log($"aaa {i}");
        }

        Debug.Log("aaa end");

        return "end";
    }
}
