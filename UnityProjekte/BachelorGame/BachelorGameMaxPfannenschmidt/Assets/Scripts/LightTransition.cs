using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTransition : MonoBehaviour
{
    public Light krankenzimmerlightSpot;
    public Light krankenzimmerlightPointA;
    public Light krankenzimmerlightPointB;

    public Light EsstischLightA;
    public Light EsstischLightB;
    public Light FlurLight;
    public Light StehlampeLight;
    public Light ScheinwerferLight;

    public GameObject EsstischLampe;
    public GameObject EsstischLampe2;
    public GameObject Stehlampe;
    public GameObject Scheinwerfer;
    public GameObject FlurLampe;

    public Material EsstischlampeAus;
    public Material StehlampeAus;
    public Material ScheinwerferAus;
    public Material FlurAus;





    public void KrankenzimmerlightOn()
    {

        StartCoroutine(SmoothlightTransition(krankenzimmerlightSpot, 0f, 5f, 0.5f));
        StartCoroutine(SmoothlightTransition(krankenzimmerlightPointA, 0f, 0.3f, 0.5f));
        StartCoroutine(SmoothlightTransition(krankenzimmerlightPointB, 0f, 0.3f, 0.5f));
    }

    public void WohzimmerLightOFF()
    {
        float EsstischLightAIntesnity = EsstischLightA.intensity;
        StartCoroutine(SmoothlightTransition(EsstischLightA, EsstischLightAIntesnity, 0f, 0.1f));
        EsstischLampe.GetComponent<MeshRenderer>().material = EsstischlampeAus;


        float EsstischLightBIntesnity = EsstischLightB.intensity;
        StartCoroutine(SmoothlightTransition(EsstischLightB, EsstischLightBIntesnity, 0f, 0.1f));
        EsstischLampe2.GetComponent<MeshRenderer>().material = EsstischlampeAus;


        float FlurLightIntesnity = FlurLight.intensity;
        StartCoroutine(SmoothlightTransition(FlurLight, FlurLightIntesnity, 0f, 0.1f));
        FlurLampe.GetComponent<MeshRenderer>().material = FlurAus;


        float StehlampeIntesnity = StehlampeLight.intensity;
        StartCoroutine(SmoothlightTransition(StehlampeLight, StehlampeIntesnity, 0f, 0.1f));
        Stehlampe.GetComponent<MeshRenderer>().material = StehlampeAus;


         float ScheinwerferLightIntensity = ScheinwerferLight.intensity;
        StartCoroutine(SmoothlightTransition(ScheinwerferLight, StehlampeIntesnity, 0f, 0.1f));
        Scheinwerfer.GetComponent<MeshRenderer>().material = ScheinwerferAus;

    }

    // Coroutine, um die Intensität eines Lichts über einen Zeitraum glatt zu ändern
    private IEnumerator SmoothlightTransition(Light light, float startIntensity, float endIntensity, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            light.intensity = Mathf.Lerp(startIntensity, endIntensity, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        light.intensity = endIntensity;
    }
}