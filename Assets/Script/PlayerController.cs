using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    const int amplitude = 1;�@//��}�X���̈ړ�����
    Vector3 playerPosition;
    public Floor floor; //�}�b�v���
    RaycastHit hit; //�O���̃I�u�W�F�N�g���m
    bool movable;
    WaitForSeconds wait = new WaitForSeconds(0.25f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = transform.localPosition;�@//�v���C���[�ʒu�̎擾
        Debug.DrawLine(transform.position, transform.forward + transform.position * 1.0f, Color.green);

        TestMove(playerPosition);
    }

    

    void TestMove(Vector3 playerPpsition) //�A�j���[�V�����ړ���ڎw��
    {
        //(a,b,c)�Ɉړ��������A�Ƃ����ꍇ�ł͂Ȃ��A������ʒu����(d,e,f)�ړ��������Ƃ����ꍇ�́A.SetRelative�����Ă�����Ηǂ��B
        //(RectTransform)(gameObject.transform).DOLocalMove(new Vector3(8, 0, 0), 0.5f).SetRelative(); ������ꏊ����E��8�ړ�
        //Debug.Log(IsMovable());

        if (movable == true)
        {
            //int x = (int)Mathf.Ceil(playerPosition.x);
            //int z = (int)Mathf.Ceil(playerPosition.z);

            if (Input.GetKeyDown("up") && IsMovable() == true)
            {
                //Debug.Log(transform.forward);
                transform.DOLocalMove(transform.forward * amplitude, 0.3f).SetRelative(); //transform.foward�̓I�u�W�F�N�g�̐���
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
                    transform.Translate(0, 0, amplitude * 2); // �h�A�����蔲���ē���i��
                    StartCoroutine(Wait());
                }

            }
        }
        
    }

    public bool DetectionDoor()
    {
        if (Physics.Linecast(transform.position, transform.forward + transform.position * 1.0f, out hit))
        { //�O���̃I�u�W�F�N�g�̃^�O���擾����

            //Debug.Log(hit.transform.gameObject.tag);
            if (hit.transform.gameObject.tag == "Door")
            {
                return true;
            }
        }
        return false;
    }

    public bool DetectionTreasure()//�C�x���g����I�Ȃ��̂��ł���悤�ɂȂ�������B����擾
    { //����̓Q�[���N���A�̃g���K�[�Ƃ��Ďg��
        if (Physics.Linecast(transform.position, transform.forward + transform.position * 1.0f, out hit))
        { //�O���̃I�u�W�F�N�g�̃^�O���擾����

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
        { // �O���ɃI�u�W�F�N�g�����邩�ǂ��������m����
          //Debug.Log("�Փ�");
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
        { //�O���̃I�u�W�F�N�g�̃^�O���擾����

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


    //void Move(Vector3 playerPpsition) //�J�N�J�N�ړ�����
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
    //                transform.Translate(0, 0, amplitude * 2); // �h�A�����蔲���ē���i��
    //            }

    //        }
    //    }


    //}



}
