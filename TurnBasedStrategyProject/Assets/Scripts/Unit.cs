using UnityEngine; 

public class Unit : MonoBehaviour
{
    public GameObject Head;
     
    private GridPosition gridPosition;

    private Vector3 scaleSize;

    // Start is called before the first frame update
    void Start()
    {
        scaleSize = transform.localScale;
        gridPosition = LevelGrid.instance.GetGridPosition(transform.position);
        LevelGrid.instance.AddUnitAtGridPosition(gridPosition, this);
    }

    // Update is called once per frame
    void Update()
    {
        GridPosition newGridPosition = LevelGrid.instance.GetGridPosition(transform.position);
        if (newGridPosition != gridPosition)
        {
            LevelGrid.instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
            gridPosition = newGridPosition;
        }
    }


    public void IncreaseSize()
    {
        scaleSize += new Vector3(0.1f, 0.1f, 0.1f);
    }



}
