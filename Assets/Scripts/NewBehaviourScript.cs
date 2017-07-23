using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        Debug.Log("Start 1");
        System.Func<Task> func = async () =>
        {
            var s = await aaa();
            Debug.Log($"func 1 {s}");
        };

        func();

        var context = SynchronizationContext.Current;
        Task.Run(async () =>
        {
            SynchronizationContext.SetSynchronizationContext(context);
            await Task.Delay(1000);
            Debug.Log(transform.position);
            // context.Post(state =>
            // {
            //     
            // }, null);

        });

        var t = bbb(() =>
        {
            Debug.Log("callback??");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    async Task<int> bbb(System.Action callback)
    {
        var task = new TaskCompletionSource<int>();
        callback += () => task.SetResult(200);

        await task.Task;

        return 100;
    }

    async Task<string> aaa()
    {
        Debug.Log("aaa start");
        for (var i = 0; i < 10; i++)
        {
            await Task.Delay(1500);
            Debug.Log($"aaa {i}");
        }

        Debug.Log("aaa end");

        return "end";
    }
}
