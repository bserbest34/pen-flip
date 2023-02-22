using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using Dlite.Games.Managers;

public class TapAndHold : MonoBehaviour
{
    [Header("Abilities")]

    internal float maxAnimationSpeed;
    public float animationSpeed = 0;

    private GameObject hand;

    [Space]

    public Image timeBar;
    public float time;
    public bool isTapped = false;

    [Space]
    public List<Material> materials = new List<Material>();
    public List<Rigidbody> teacherRb = new List<Rigidbody>();
    public List<Rigidbody> studentRb = new List<Rigidbody>();
    [Space]

    int KizarmaID, TerlemeID;

    public float maxTime;
    float breakTime;

    //Level end
    public Slider levelBar;
    public float levelCount;
    public float levelEndCount;

    public float levelTime;

    public GameObject penTarget;
    public GameObject pen;

    public GameObject teacher;
    public GameObject student;

    internal bool isGameRunning;

    private Coroutine routine;


    private float speed = 1;
    private float startTime;

    public Animator bluranimator;

    int sayac;

    int target;
    // Parmaklar.
    [Header("Fingers")]
    public Transform index, middle, little, ring, thumb;

    public List<GameObject> teacherTarget = new List<GameObject>();

    void Start()
    {
        target = Random.Range(0, 4);
        sayac = 0;
        isGameRunning = false;
        levelTime = 0;
        time = 0;
        breakTime = 0;
        maxTime = PlayerPrefs.GetFloat("MaxSure", 12);
        maxAnimationSpeed = PlayerPrefs.GetFloat("MaxAnimSpeed", 1);

        transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = materials[0];

        hand = transform.gameObject;

        hand.GetComponent<Animator>().speed = 0;

        startTime = Time.time;

        levelBar.GetComponent<Slider>().maxValue = levelEndCount;

    }
    void Update()
    {
        TapNHold();
        StartAnimations();
        if (isGameRunning == false) return;
        if (isTapped)
        {
            time += Time.deltaTime;
            levelTime += Time.deltaTime;
        }
        else
        {
            if(sayac == 0)
            {
                if (time >= maxTime * 0.75f)
                {
                    sayac++;
                    time -= Time.deltaTime;
                }
            }
            if (sayac == 1)
            {
                if (time >= maxTime * 0.85f)
                {
                    sayac++;
                    time -= Time.deltaTime;
                }
            }
            if (sayac == 2)
            {
                if (time >= maxTime * 0.95f)
                {
                    sayac++;
                    time -= Time.deltaTime;
                }
            }

            breakTime += Time.deltaTime;
        }
        Debug.Log(sayac);
        //fail.
        if (time >= maxTime)
        {
            transform.GetComponent<Animator>().enabled = false;
            isGameRunning = false;
            StartCoroutine(FailFunc());

            FindObjectOfType<UIManager>().FailGame();
        }


        timeBar.fillAmount = time / maxTime;
        SetTimeUp();
        SetTimeDown();





    }


    public void IncomeUpgrade()
    {

        float oldMinMoney = PlayerPrefs.GetFloat("minMoney", 1);
        PlayerPrefs.SetFloat("minMoney", oldMinMoney + 0.2f);
        PlayerPrefs.SetFloat("maxMoney", oldMinMoney + 0.2f);
    }




    public void StaminaUpgrade()
    {
        PlayerPrefs.SetFloat("MaxSure", maxTime + 1);
        maxTime = PlayerPrefs.GetFloat("MaxSure");
    }
    public void SpeedUpgrade()
    {
        PlayerPrefs.SetFloat("MaxAnimSpeed", maxAnimationSpeed + 0.05f);
        maxAnimationSpeed = PlayerPrefs.GetFloat("MaxAnimSpeed");
    }
    public void GetMoney()
    {
        FindObjectOfType<MoneyManager>().InstantiateMoney(1);
        HapticManager.Haptic(Dlite.Games.HapticType.MediumImpact);
        StartCoroutine(Counter());
        

        //success
        if (levelCount == levelEndCount)
        {
            Scale(1f ,1f);
            transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = materials[0];
            isGameRunning = false;
            //transform.GetComponent<Animator>().enabled = false;
            StartCoroutine(SuccessFunc());
            FindObjectOfType<UIManager>().SuccesGame();
        }
    }

    IEnumerator Counter()
    {
        levelCount++;
        var leveltemp = levelCount - 1;

        for(int i=0; i < 10 ; i++)
        {
            yield return new WaitForSeconds(0.04f);
            levelBar.GetComponent<Slider>().value +=  (0.1f);

        }
    }
    void StartAnimations()
    {
        if (isGameRunning == false) return;
        if (isTapped)
        {
            hand.GetComponent<Animator>().SetBool("isTap", true);
            hand.GetComponent<Animator>().SetBool("holdTap", true);
            if (animationSpeed >= maxAnimationSpeed)
                return;
            if (animationSpeed != maxAnimationSpeed)
            {
                //hand.GetComponent<Animator>().speed += Time.deltaTime;
                animationSpeed += Time.deltaTime;
                hand.GetComponent<Animator>().SetFloat("speed", maxAnimationSpeed);
            }
        }
        else
        {
            hand.GetComponent<Animator>().speed = maxAnimationSpeed;
            hand.GetComponent<Animator>().SetBool("isTap", false);
            if (animationSpeed <= 0)
                return;
            else
            {
                hand.GetComponent<Animator>().speed -= 0.01f;
                animationSpeed -= 0.01f;
                if (animationSpeed <= 0)
                {
                    animationSpeed = 0;
                    hand.GetComponent<Animator>().SetBool("holdTap", false);
                }
            }
            breakTime = 0;
        }
    }
    void TapNHold()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isTapped = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            isTapped = false;
        }
    }
    void SetTimeDown()
    {
        if (breakTime >= 3f)
        {
            if (KizarmaID == 0 && !isTapped)
            {
                Scale(1f, 1f);

            }

            if (TerlemeID == 1 && !isTapped)
            {
                TerlemeID--;
            }

            if (KizarmaID == 1 && !isTapped)
            {
                transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = materials[0];
                KizarmaID--;
            }

        }
        else if (breakTime >= 2f)
        {
            if (TerlemeID == 2 && !isTapped)
            {
                TerlemeID--;
            }

            if (KizarmaID == 2 && !isTapped)
            {
                Scale(1.25f, 1.2f);
                transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = materials[1];
                bluranimator.SetBool("blur", false);
                KizarmaID--;

            }
            //ScaleUpThree();
        }
        else if (breakTime >= 1f)
        {
            if (TerlemeID == 3 && !isTapped)
            {
                TerlemeID--;
            }

            if (KizarmaID == 3 && !isTapped)
            {
                Scale(1.5f, 1.3f);
                transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = materials[2];
                KizarmaID--;
            }
            //ScaleUpTwo();
        }
    }
    void SetTimeUp()
    {
        if(isGameRunning == false) return;
        if (time >= maxTime * 0.75f)
        {
            //ScaleUpThree();
            if (KizarmaID == 0 && isTapped)
            {
                Scale(1.25f , 1.2f);
                transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = materials[1];
                KizarmaID++;
            }
            if (TerlemeID == 0 && isTapped)
            {
                TerlemeID++;
            }
        }
        if (time >= maxTime * 0.8f)
        {
            //ScaleUpTwo();
            if (KizarmaID == 1 && isTapped)
            {
                Scale(1.5f, 1.3f);
                transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = materials[2];
                KizarmaID++;
            }
            if (TerlemeID == 1 && isTapped)
            {
                TerlemeID++;
            }
        }
        if (time >= maxTime * 0.9f)
        {
            //ScaleUp();
            if (KizarmaID == 2 && isTapped)
            {
                Scale(1.75f, 1.5f);
                transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = materials[3];
                bluranimator.SetBool("blur", true);
                KizarmaID++;
            }
            if (TerlemeID == 2 && isTapped)
            {
                TerlemeID++;
            }
        }

    }
    IEnumerator FailFunc()
    {

        HapticManager.Haptic(Dlite.Games.HapticType.Failure);
        pen.transform.parent = null; 

        if (teacher.activeInHierarchy)
        {
            pen.GetComponent<BoxCollider>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            pen.transform.DOMove(teacherTarget[target].transform.position, 1f);
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().enabled = false;
            pen.transform.rotation = Quaternion.Euler(0, 90, 0);
            yield return new WaitForSeconds(1f);
            pen.transform.parent = teacherTarget[target].gameObject.transform;
            GameObject.Find("Teacher").GetComponent<Animator>().enabled = false;
            //Vector3.Lerp(pen.transform.localPosition, teacherTarget[target].gameObject.transform.localPosition, 10* 100);
            pen.transform.localPosition = new Vector3(0, 0, 0);
            for (int i = 0; i < teacherRb.Count; i++)
            {
                teacherRb[i].isKinematic = false;
                teacherRb[i].useGravity = true;
            }
        }
        else if (student.activeInHierarchy)
        {
            Vector3.Lerp(pen.transform.position, penTarget.transform.position, 100f);
            pen.transform.DOMove(penTarget.transform.position, 0.5f);
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().enabled = false;
            pen.transform.rotation = Quaternion.Euler(0, 90, 0);
            yield return new WaitForSeconds(0.5f);
            student.GetComponent<Animator>().enabled = false;
            if(GameObject.Find("StudentTarget").transform.Find("mixamorig:Hips").Find("mixamorig:Spine").Find("PenTarget").gameObject.activeInHierarchy)
                pen.transform.parent = GameObject.Find("StudentTarget").transform.Find("mixamorig:Hips").Find("mixamorig:Spine").Find("PenTarget").transform;
            else
                pen.transform.parent = GameObject.Find("StudentTarget").transform.Find("mixamorig:Hips").Find("mixamorig:Spine").Find("mixamorig:Spine1").Find("mixamorig:Spine2").Find("mixamorig:Neck").Find("mixamorig:Head").Find("PenTarget").transform;

            pen.transform.localPosition = new Vector3(0, 0, 0);
            for (int i = 0; i < studentRb.Count; i++)
            {
                studentRb[i].isKinematic = false;
                studentRb[i].useGravity = true;
            }
        }
    }
    IEnumerator SuccessFunc()
    {
        yield return new WaitForSeconds(0f);
        HapticManager.Haptic(Dlite.Games.HapticType.Success);
        GameObject pencil = Instantiate(pen);
        pencil.transform.parent = null;
        pencil.transform.localScale = new Vector3(1, 1, 1);
        pencil.transform.position = pen.transform.position;
        pencil.transform.rotation = Quaternion.Euler(-7.338f, -16.85f, 17.215f);
        pencil.AddComponent<Rigidbody>();
        pencil.GetComponent<Rigidbody>().useGravity = true;
        pencil.GetComponent<Rigidbody>().isKinematic = false;
        pencil.GetComponent<Rigidbody>().AddForce(Vector3.up * 7.5f, ForceMode.Impulse);
        pencil.transform.DORotate(new Vector3(0, 0,Random.Range(80,100)), 2f);
        //pencil.GetComponent<Rigidbody>().mass =

        //pencil.transform.DOMove(new Vector3(-2.632395f, 3.3f, -8.820135f), 2);
        //pencil.transform.DORotate(new Vector3(-11.964f, -76.365f, 0.334f), 2);
        pen.gameObject.SetActive(false);
        GetComponent<Animator>().SetTrigger("isSuccess");
    }



    void Scale(float a , float b)
    {
        index.transform.DOKill();


        index.transform.DOScale(Vector3.one, 0.5f).OnComplete(() =>
        {
            index.transform.DOScale(Vector3.one * a, 0.5f).SetLoops(-1, LoopType.Yoyo);
        });

        middle.transform.DOKill();
        middle.transform.DOScale(Vector3.one, 0.5f).OnComplete(() =>
        {
            middle.transform.DOScale(Vector3.one * b, 0.5f).SetLoops(-1, LoopType.Yoyo);
        });

        ring.transform.DOKill();
        ring.transform.DOScale(Vector3.one, 0.5f).OnComplete(() =>
        {
            ring.transform.DOScale(Vector3.one * b, 0.5f).SetLoops(-1, LoopType.Yoyo);
        });

        thumb.transform.DOKill();
        thumb.transform.DOScale(Vector3.one, 0.5f).OnComplete(() =>
        {
            thumb.transform.DOScale(Vector3.one * a, 0.5f).SetLoops(-1, LoopType.Yoyo);
        });

        little.transform.DOKill();
        little.transform.DOScale(Vector3.one, 0.5f).OnComplete(() =>
        {
            little.transform.DOScale(Vector3.one * b, 0.5f).SetLoops(-1, LoopType.Yoyo);
        });
    }

}
