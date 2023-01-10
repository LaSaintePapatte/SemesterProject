using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastrumParticleManager : MonoBehaviour
{
    [SerializeField] private GameObject particleParch1;
    [SerializeField] private GameObject particleParch2;
    [SerializeField] private GameObject particleFrag1;
    [SerializeField] private GameObject particleFrag2;
    [SerializeField] private GameObject particleCastrum;
    [SerializeField] private GameObject particleShadowAna;
    [SerializeField] private GameObject particleCoin;
    [SerializeField] private GameObject particlePNJ1;
    [SerializeField] private GameObject particlePNJ2;

    [SerializeField] private PlayerStatus playerStatus;


    // Update is called once per frame
    void Update()
    {
        if (playerStatus.hasCastrum)
        {
            particleCastrum.SetActive(false);
        }
        if (playerStatus.hasParch2 && !playerStatus.parchRestored2)
        {
            particleParch2.SetActive(false);
            particleFrag1.SetActive(true);
            particleFrag2.SetActive(true);
        }
        if (playerStatus.hasParchFrag1)
        {
            particleFrag1.SetActive(false);
        }
        if (playerStatus.hasParchFrag2)
        {
            particleFrag2.SetActive(false);
        }
        if (playerStatus.hasParch1)
        {
            particleParch1.SetActive(false);
        }
        if (playerStatus.parchRestored1 && playerStatus.parchRestored2 && playerStatus.talkedPNJ1 && playerStatus.talkedPNJ2)
        {
            particleCoin.SetActive(true);
        }
        if (playerStatus.hasCoin)
        {
            particleCoin.SetActive(false);
        }
        if (playerStatus.talkedPNJ1)
        {
            particlePNJ1.SetActive(false);
        }
        if (playerStatus.talkedPNJ2)
        {
            particlePNJ2.SetActive(false);
        }
        if (playerStatus.hasCastrum && playerStatus.hasParch1 && !playerStatus.parchRestored1)
        {
            particleShadowAna.SetActive(true);
        }
        if (playerStatus.inShadowAna)
        {
            particleShadowAna.SetActive(false);
        }
        
    }
}
