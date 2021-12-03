using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    GameObject targetObj;

    MeshRenderer targetMesh;
    MeshRenderer thisObjMesh;


    Coroutine coroutine;

    //スピード用の変数
    [SerializeField]
    float SpeedParameter = 10;
    [SerializeField]
    string target;
    [SerializeField]
    float disappear_time = 1.5f;
    float time = 0f;

    [SerializeField]
    float Accelerate = 0;

    [SerializeField]
    float MaxSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.Find(target);erer>();
        time = 0;
        Accelerate = 0;
        MaxSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {

        //ターゲットに向かってホーミングさせる
        targetObj = GameObject.Find(target);
        if (coroutine == null)
        {
            coroutine = StartCoroutine(MoveCoroutine());
        }


        time += Time.deltaTime;
        print(time);
        if (time > disappear_time)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator MoveCoroutine()
    {
        float speed = SpeedParameter * Time.deltaTime;
        while (this.gameObject.transform.position != targetObj.transform.position)
        {
            yield return new WaitForEndOfFrame();
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetObj.transform.position, speed);
        }

        
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
