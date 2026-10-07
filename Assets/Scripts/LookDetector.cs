using UnityEngine;

public class LookDetector : MonoBehaviour
{
    public Camera cam;
    public LayerMask interactableMask;
    public float maxDistance = 4f;

    [Header("Timers")]
    public float lookToCloseSeconds = 1.5f;
    public float lookAwayToOpenSeconds = 2.0f;

    //private DoorController _currentDoor;
    //private float _lookTimer;
    //private float _lookAwayTimer;

    void Awake()
    {
        if (cam == null) cam = Camera.main;
    }

    void Update()
    {
        //DoorController hitDoor = RaycastDoor();

        //if (hitDoor != null)
        //{
        //    if (_currentDoor != hitDoor)
        //    {
        //        _currentDoor = hitDoor;
        //        _lookTimer = 0f;
        //        _lookAwayTimer = 0f;
        //    }

        //    _lookTimer += Time.deltaTime;
        //    _lookAwayTimer = 0f;

        //    if (_lookTimer >= lookToCloseSeconds)
        //        _currentDoor.Close();
        //}
        //else
        //{
        //    if (_currentDoor != null)
        //    {
        //        _lookAwayTimer += Time.deltaTime;
        //        _lookTimer = 0f;
        //
        //       if (_lookAwayTimer >= lookAwayToOpenSeconds)
        //            _currentDoor.Open();
        //    }
        //}
    }

    //private DoorController RaycastDoor()
    //{
    //    Ray r = new Ray(cam.transform.position, cam.transform.forward);
    //    if (Physics.Raycast(r, out RaycastHit hit, maxDistance, interactableMask, QueryTriggerInteraction.Ignore))
    //    {
    //        return hit.collider.GetComponentInParent<DoorController>();
    //    }
    //    return null;
    //    var hitDoor = RaycastDoor();
    //    if (hitDoor != null)
    //        Debug.Log("LOOKING AT DOOR: " + hitDoor.name);
    //}
}