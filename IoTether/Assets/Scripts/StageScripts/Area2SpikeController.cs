using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area2SpikeController : SpikeController
{
    public GameObject topSprite;

    protected override void Start()
    {
        topSprite.SetActive(false);
        base.Start();
    }

    protected override IEnumerator ChangeSprite()
    {
        while (true)
        {
            spriteRenderer.sprite = spikeSprites[0];
            canDamage = false;
            yield return new WaitForSeconds(primeInterval);

            spriteRenderer.sprite = spikeSprites[1];
            canDamage = true;
            topSprite.SetActive(true);
            base.DamageAllInContact();
            yield return new WaitForSeconds(activeInterval);

            spriteRenderer.sprite = spikeSprites[2];
            canDamage = true;
            base.DamageAllInContact();
            yield return new WaitForSeconds(activeInterval);

            spriteRenderer.sprite = spikeSprites[3];
            canDamage = false;
            topSprite.SetActive(false);
            yield return new WaitForSeconds(cooldownInterval);

        }

    }
}
