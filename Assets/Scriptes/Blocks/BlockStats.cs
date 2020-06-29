using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStats : MonoBehaviour
{
    public GameObject Drop, ExtraDrop_1, ExtraDrop_2, ExtraDrop_3, ExtraDrop_4;
    private GameObject Zero;
    public float Health; 
    private float TakenDamage = 1;
    public int MaxQuantityDropDefault, MinQuantityDropDefault;
    public int MaxChanceDropExtra, MinChanceDropExtra;
    private bool IsOnBlock = false;

    public void Enable()
    {
        IsOnBlock = true;
    }

    public void Disable()
    {
        IsOnBlock = false;
    }

    void Update()
    {
        if (IsOnBlock == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Health -= TakenDamage;
                Zero = GameObject.Find("Zero");
                Zero.GetComponent<LoadArray>().Health(Health);
                if (Health <= 0)
                {

                    int count = Random.Range(MinQuantityDropDefault, MaxQuantityDropDefault + 1);
                    var position = transform.position;
                    for (int i = 0; i < count; i++)
                    {
                        var go = Instantiate(Drop, new Vector2(position.x, position.y), Quaternion.identity);
                        go.GetComponent<DropingItem>().BlockID = Drop;
                        go.GetComponent<DropingItem>().Explode();
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
}
