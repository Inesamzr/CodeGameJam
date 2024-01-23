using System.Collections;
using UnityEngine;

public class CreateDragon : MonoBehaviour
{
    [SerializeField] private GameObject dragonPrefab;
    [SerializeField] private int circleRadius;
    [SerializeField] private int xCenter;
    [SerializeField] private int zCenter;
    [SerializeField] private int nbDragMax;
    private int nbDrag = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDragons());
    }

    IEnumerator SpawnDragons()
    {
        while (nbDrag < nbDragMax)
        {
            createDrag();
            yield return null;
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
            dragonExampleComponent.InitiateMovement(new Vector3(xCenter-xInitial, 300f, zCenter- zInitial));
            nbDrag++;
        }
        else
        {
            Debug.LogError("Le composant DragonExample n'est pas attaché à l'objet dragonInstance.");
        }
    }

}
