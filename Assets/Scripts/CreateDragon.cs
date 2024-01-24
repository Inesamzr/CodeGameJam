using System.Collections;
using UnityEngine;

public class CreateDragon : MonoBehaviour
{
    [SerializeField] private GameObject dragonPrefab;
    [SerializeField] private int circleRadius;
    [SerializeField] private int xCenter;
    [SerializeField] private int zCenter;
    [SerializeField] private int nbDragMax;
    public int nbDrag = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IncrementMaxDragons());
    }

    private void Update()
    {
        if (nbDrag < nbDragMax)
        {
            createDrag();
        }
    }

    IEnumerator IncrementMaxDragons()
    {
        while (true)
        {
            nbDragMax++;
            yield return new WaitForSeconds(40f);
        }
    }

    void createDrag()
    {
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);

        float xInitial = xCenter + circleRadius * Mathf.Cos(randomAngle);
        float zInitial = zCenter + circleRadius * Mathf.Sin(randomAngle);

        Vector3 initialPosition = new Vector3(xInitial, 300f, zInitial);
        Debug.Log(initialPosition +"-" + new Vector3(xCenter - xInitial, 300f, zCenter - zInitial));

        GameObject dragonInstance = Instantiate(dragonPrefab, initialPosition, Quaternion.identity);

        DragonExample dragonExampleComponent = dragonInstance.GetComponent<DragonExample>();

        if (dragonExampleComponent != null)
        {
            dragonExampleComponent.InitiateMovement(new Vector3(xCenter-xInitial, 300f, zCenter- zInitial), this);
            nbDrag++;
        }
        else
        {
            Debug.LogError("Le composant DragonExample n'est pas attaché à l'objet dragonInstance.");
        }
    }

}
