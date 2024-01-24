using UnityEngine;
using System.Collections;

public class DragonExample : MonoBehaviour
{
    private Animator anim;
    int IdleSimple;
    int IdleAgressive;
    int IdleRestless;
    int Walk;
    int BattleStance;
    int Bite;
    int Drakaris;
    int FlyingFWD;
    int FlyingAttack;
    int Hover;
    int Lands;
    int TakeOff;
    int Die;
    Vector3 destination;
    bool isMoving = false;
    private Rigidbody rb;

    private CreateDragon createDragon;

    public float speed = 0.1f; // Vitesse de déplacement du dragon

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
        IdleSimple = Animator.StringToHash("IdleSimple");
        IdleAgressive = Animator.StringToHash("IdleAgressive");
        IdleRestless = Animator.StringToHash("IdleRestless");
        Walk = Animator.StringToHash("Walk");
        BattleStance = Animator.StringToHash("BattleStance");
        Bite = Animator.StringToHash("Bite");
        Drakaris = Animator.StringToHash("Drakaris");
        FlyingFWD = Animator.StringToHash("FlyingFWD");
        FlyingAttack = Animator.StringToHash("FlyingAttack");
        Hover = Animator.StringToHash("Hover");
        Lands = Animator.StringToHash("Lands");
        TakeOff = Animator.StringToHash("TakeOff");
        Die = Animator.StringToHash("Die");
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveToDestination();
    }

    void MoveToDestination()
    {

        if (isMoving)
        {
            // Déplacez le dragon vers la destination à une vitesse donnée
            rb.MovePosition(Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime));

            // Si le dragon est proche de la destination, arrêtez le mouvement
            if (Vector3.Distance(transform.position, destination) < 4f)
            {
                createDragon.nbDrag--;
                Destroy(gameObject);
            }
        }

    }

    public void InitiateMovement(Vector3 targetDestination, CreateDragon createDragon)
    {

        this.createDragon = createDragon;

        // Définissez la destination et activez le mouvement
        destination = targetDestination;
        transform.LookAt(destination);

        isMoving = true;
    }

}
