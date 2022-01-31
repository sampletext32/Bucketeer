using System.Collections;
using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject ingameScreen;

    [SerializeField]
    private GameObject endScreen;

    public void End()
    {
        StartCoroutine(SlideDown());
        endScreen.SetActive(true);
    }

    private IEnumerator SlideDown()
    {
        while (true)
        {
            var position = ingameScreen.transform.position;
            var dest     = position + new Vector3(0, -2, 0);
            position                        = Vector3.Lerp(position, dest, 0.9f * Time.deltaTime);
            ingameScreen.transform.position = position;
            if ((dest - position).sqrMagnitude < 0.1)
            {
                ingameScreen.transform.position = dest;
                break;
            }

            yield return null;
        }

        yield break;
    }
}