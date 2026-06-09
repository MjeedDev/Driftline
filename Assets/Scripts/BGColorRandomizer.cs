using System.Collections;
using UnityEngine;

public class BGColorRandomizer : MonoBehaviour
{
    [SerializeField] private float changeColorCooldown = 10f;
    [SerializeField] private Color[] colors;

    private void Start()
    {
        StartCoroutine(ChangeBGColor());
    }

    private IEnumerator ChangeBGColor()
    {
        while (true)
        {
            int randomColor = Random.Range(0, colors.Length);
            Camera.main.backgroundColor = colors[randomColor];
            yield return new WaitForSeconds(changeColorCooldown);
        }
    }
}