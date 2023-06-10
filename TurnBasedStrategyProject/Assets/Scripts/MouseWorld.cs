using UnityEngine;

public class MouseWorld : MonoBehaviour
{

    public static MouseWorld instance;

    
    [SerializeField] LayerMask planeLayerMask;


    private void Awake()
    {
        instance= this;
    }

    private void Update()
    {
        GetPosition();
    }

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.planeLayerMask);
        return raycastHit.point;

    }
}
