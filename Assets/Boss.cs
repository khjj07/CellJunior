using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Threading;
using System.Threading.Tasks;
using DG.Tweening;

public class Boss : MonoBehaviour
{
    public Subject<int> Pattern;
    public int PatternDelay = 4000;
    public int SlamDelay = 3000;
    public int LaserDelay = 3000;
    public Animator Controller;
    public Projectile Laser;
    public Transform Eye;
    public Transform Chest;
    public Transform LaserTarget;

    public void LaserAttack()
    {
        var instance = Instantiate(Laser.gameObject);

        int value = Controller.GetInteger("Pattern");
        Transform Muzzle = value == 2 ? Eye : Chest;
        instance.transform.position = Muzzle.position;
        instance.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.Normalize(LaserTarget.position - instance.transform.position));
        instance.transform.DOMove(LaserTarget.position, 0.3f);
        instance.transform.DOScaleY(5f, 0.5f);
        instance.transform.DOScaleX(0f, 0.5f);
    }

    public async void Stay()
    {
        Controller.SetInteger("Pattern", 0);
        await Task.Delay(PatternDelay);
        Pattern.OnNext(Random.Range(1,4));
    }

    public async void Slam()
    {
        Controller.SetInteger("Pattern", 3);
        await Task.Delay(SlamDelay);
        Pattern.OnNext(0);
    }

    public async void EyesLaser()
    {
        Controller.SetInteger("Pattern", 2);
        await Task.Delay(LaserDelay);
        Pattern.OnNext(0);
    }

    public async void ChestLaser()
    {
        Controller.SetInteger("Pattern", 1);
        await Task.Delay(LaserDelay);
        Pattern.OnNext(0);
    }


    // Start is called before the first frame update
    public void Start()
    {
        Pattern = new Subject<int>();
        Pattern.Where(x => x == 0)
            .Subscribe(x => Stay());
        Pattern.Where(x => x == 1)
           .Subscribe(x =>  ChestLaser());
        Pattern.Where(x => x == 2)
           .Subscribe(x => EyesLaser());
        Pattern.Where(x => x == 3)
           .Subscribe(x => Slam());
        
        Pattern.Subscribe(x => Debug.Log(x.ToString()));

        Pattern.OnNext(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
