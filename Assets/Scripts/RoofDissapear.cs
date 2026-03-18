using UnityEngine;

public class RoofDissapear : MonoBehaviour
{
    // when player enters zone, make roof invisible
    // when player exits zone, make roof visible again

    [SerializeField] private Camera playerCam;
    private static bool roofState = true;
    private readonly int ogSize = 12;
    private readonly int buildingSize = 8;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player entered roof zone");

        if (other.CompareTag("Player"))
        {
            roofState = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player exited roof zone");

        if (other.CompareTag("Player"))
        {
            roofState = true;
        }
    }

    private void Update()
    {
        if (roofState)
        {
            playerCam.cullingMask |= (1 << LayerMask.NameToLayer("Roof"));
            playerCam.orthographicSize = ogSize;

        }
        else
        {
            playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer("Roof"));
            playerCam.orthographicSize = buildingSize;
        }
    }
}
