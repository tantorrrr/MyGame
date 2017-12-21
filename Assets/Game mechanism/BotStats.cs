using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;
using UnityEngine.UI;
public class BotStats : MonoBehaviour
{
    public float HP = 100f;
    public bool dead = false;
    public float deadDestroyTime = 8f;
    [Space(1)]
    [Tooltip("If is building set true")]
    public bool isBuilding = false;
    [Space(7)]
    [Header("Player Settings")]
    public ActivateWeapons weapons;
    public BehaviourPuppet puppet;
    public GameObject[] dropDownObjects;
    public TextMesh HPText;
    public Image HPImage;
    public PuppetMaster puppetMaster;
    [Space(4)]
    [Header("Building Settings")]
    public TextMesh HpBuildingText;
    void Awake()
    {
        if (!isBuilding)
            puppet.OnCollisionImpulse += OnCollisionImpulse;

    }
    void OnCollisionImpulse(MuscleCollision m, float impulse)
    {
        if (m.collision.contacts.Length == 0) return;
        //  Debug.LogError(impulse + " = " + m.collision.contacts.Length);
        // Debug.LogError(impulse);
    }

    public void dropDown()
    {
        for (int i = 0; i < dropDownObjects.Length; i++)
        {
            dropDownObjects[i].GetComponent<MeshCollider>().isTrigger = false;
            dropDownObjects[i].transform.parent = null;
            dropDownObjects[i].AddComponent<Rigidbody>();
        }
    }
    public void DamageIt(int damage)
    {

        HP -= damage;

        if (HP <= 0)
        {
            Kill();
            UpdateHP(0);
        }
        else
        {
            UpdateHP((int)HP);
        }

    }
    void UpdateHP(int hp)
    {
        if (!isBuilding)
        {
            if (HPText)
                HPText.text = hp.ToString();
            UpdateHPBar(hp);
        }
        else
        {
            if (HpBuildingText)
                HpBuildingText.text = hp.ToString();

        }
    }
    private void UpdateHPBar(int hp)
    {
        float left = 0f;
        float right = 100 - hp;
        float posY = -50f;
        float height = 100f;
        RectTransform this_rect = HPImage.rectTransform;
        this_rect.anchorMin = new Vector2(0, 1);
        this_rect.anchorMax = new Vector2(1, 1);
        Vector2 temp = new Vector2(left, posY - (height / 2f));
        this_rect.offsetMin = temp;
        temp = new Vector3(-right, temp.y + height);
        this_rect.offsetMax = temp;

    }
    private void Kill()
    {
        dead = true;
        if (!isBuilding)
        {
            puppetMaster.state = PuppetMaster.State.Dead;
            if (weapons)
            {
                foreach (GameObject weapon in weapons.weapons)
                {
                    weapon.transform.parent = null;
                    weapon.GetComponent<Rigidbody>().isKinematic = false;
                    weapon.GetComponent<MeshCollider>().isTrigger = false;
                    weapon.layer = LayerMask.NameToLayer("Terrain");
                    Destroy(weapon, 5);

                }
            }

            Destroy(transform.root.gameObject, deadDestroyTime);

        }
        else
        {
            //dead = true;
            Destroy(transform.root.gameObject, deadDestroyTime);
        }


    }
}
