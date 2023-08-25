using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    const int amplitude = 1;　//一マス分の移動距離
    Vector3 playerPosition;
    public Floor floor; //マップ情報
    RaycastHit hit; //前方のオブジェクト検知
    bool movable;
    WaitForSeconds wait = new WaitForSeconds(0.25f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = transform.localPosition;　//プレイヤー位置の取得
        Debug.DrawLine(transform.position, transform.forward + transform.position * 1.0f, Color.green);

        TestMove(playerPosition);
    }

    

    void TestMove(Vector3 playerPpsition) //アニメーション移動を目指す
    {
        //(a,b,c)に移動したい、という場合ではなく、今いる位置から(d,e,f)移動したいという場合は、.SetRelativeをつけてあげれば良い。
        //(RectTransform)(gameObject.transform).DOLocalMove(new Vector3(8, 0, 0), 0.5f).SetRelative(); 今いる場所から右へ8移動
        //Debug.Log(IsMovable());

        if (movable == true)
        {
            //int x = (int)Mathf.Ceil(playerPosition.x);
            //int z = (int)Mathf.Ceil(playerPosition.z);

            if (Input.GetKeyDown("up") && IsMovable() == true)
            {
                //Debug.Log(transform.forward);
                transform.DOLocalMove(transform.forward * amplitude, 0.3f).SetRelative(); //transform.fowardはオブジェクトの正面
                StartCoroutine(Wait());
            }

            if (Input.GetKeyDown("right"))
            {
                transform.DORotate(new Vector3(0, 90, 0), 0.2f).SetRelative();
                StartCoroutine(Wait());
            }

            if (Input.GetKeyDown("left"))
            {
                transform.DORotate(new Vector3(0, -90, 0), 0.2f).SetRelative();
                StartCoroutine(Wait());
            }

            if (Input.GetKeyDown("down"))
            {
                transform.DORotate(new Vector3(0, 180, 0), 0.2f).SetRelative();
                StartCoroutine(Wait());
            }

            if (Input.GetKeyDown("space"))
            {
                if (DetectionDoor() == true)
                {
                    transform.Translate(0, 0, amplitude * 2); // ドアをすり抜けて二歩進む
                    StartCoroutine(Wait());
                }

            }
        }
        
    }

    public bool DetectionDoor()
    {
        if (Physics.Linecast(transform.position, transform.forward + transform.position * 1.0f, out hit))
        { //前方のオブジェクトのタグを取得する

            //Debug.Log(hit.transform.gameObject.tag);
            if (hit.transform.gameObject.tag == "Door")
            {
                return true;
            }
        }
        return false;
    }

    public bool DetectionTreasure()//イベント制御的なものができるようになったらやる。お宝取得
    { //今回はゲームクリアのトリガーとして使う
        if (Physics.Linecast(transform.position, transform.forward + transform.position * 1.0f, out hit))
        { //前方のオブジェクトのタグを取得する

            //Debug.Log(hit.transform.gameObject.tag);
            if (hit.transform.gameObject.tag == "Treasure")
            {
                return true;
            }
        }
        return false;
    }

    bool IsMovable()
    {
        if(Physics.Linecast(transform.position, transform.forward + transform.position * 1.0f, out hit))
        { // 前方にオブジェクトがあるかどうかを検知する
          //Debug.Log("衝突");
            if (hit.transform.gameObject.tag != "Floor")
            {
                return false;
            }
        }
        return true;
    }

    public bool DetectionStairs()
    {
        if (Physics.Linecast(transform.position, transform.forward + transform.position * 1.0f, out hit))
        { //前方のオブジェクトのタグを取得する

            //Debug.Log(hit.transform.gameObject.tag);
            if (hit.transform.gameObject.tag == "Stairs")
            {
                return true;
            }
        }
        return false;
    }

        public void SetSteerActive(bool active)
    {
        movable = active;
    }

    IEnumerator Wait()
    {
        movable = false;
        yield return wait;
        movable = true;
    }


    //void Move(Vector3 playerPpsition) //カクカク移動する
    //{
    //    if (movable == true)
    //    {
    //        if (Input.GetKeyDown("up") && IsMovable() == true)
    //        {
    //            transform.Translate(0, 0, amplitude);
    //        }

    //        if (Input.GetKeyDown("right"))
    //        {
    //            transform.Rotate(0, 90, 0);
    //        }

    //        if (Input.GetKeyDown("left"))
    //        {
    //            transform.Rotate(0, -90, 0);
    //        }

    //        if (Input.GetKeyDown("down"))
    //        {
    //            transform.Rotate(0, 180, 0);
    //        }

    //        if (Input.GetKeyDown("space"))
    //        {
    //            if (DetectionDoor() == true)
    //            {
    //                transform.Translate(0, 0, amplitude * 2); // ドアをすり抜けて二歩進む
    //            }

    //        }
    //    }


    //}



}
