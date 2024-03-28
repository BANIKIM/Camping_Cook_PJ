using EzySlice;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Knife : MonoBehaviour
{
    public Transform _startPos;
    public Transform _endPos;
    public VelocityEstimator _velocityEstimator;

    [SerializeField] private AudioSource _audiosource;

    public LayerMask _targetLayer;

    private void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(_startPos.position, _endPos.position, out RaycastHit hit, _targetLayer);

        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            SliceObj(target);
        }
    }

    public void SliceObj(GameObject target)
    {
        Ingredient ingred = target.GetComponent<Ingredient>();
        Vector3 velo = _velocityEstimator.GetVelocityEstimate();
        Vector3 slice_normal = Vector3.Cross(_endPos.position - _startPos.position, velo);
        Material cross = target.GetComponent<Ingredient>().crossMat;
        slice_normal.Normalize();

        if (ingred.sliceCount <= 2)
        {
            SlicedHull hull = target.Slice(_endPos.position, slice_normal);
            PlaySound(ingred);
            if (hull != null)
            {
                GameObject upperHull = hull.CreateUpperHull(target, cross);
                SetUpSliceCompoent(upperHull, ingred);
                GameObject lowerHull = hull.CreateLowerHull(target, cross);
                SetUpSliceCompoent(lowerHull, ingred);
                Debug.Log("삭제~");
                Destroy(target);
            }
        }
    }

    private void PlaySound(Ingredient ingred)
    {
        switch (ingred.ingredientType)
        {
            case IngredientType.Beef:
            case IngredientType.Salmon:
                _audiosource.PlayOneShot(AudioManager.instance._sfxClips[(int)SFX_List.SliceMeat]);
                break;
            case IngredientType.Potato:
            case IngredientType.Carrot:
            case IngredientType.Onion:
            case IngredientType.Asparagus:
            case IngredientType.Mushroom:
                int temp = Random.Range((int)SFX_List.SliceVegetable1, (int)SFX_List.SliceVegetable2 + 1);
                _audiosource.PlayOneShot(AudioManager.instance._sfxClips[temp]);
                break;
            default:
                break;
        }
    }


    private void SetUpSliceCompoent(GameObject obj, Ingredient target_ingred)
    {
        obj.AddComponent<Rigidbody>();
        MeshCollider mesh = obj.AddComponent<MeshCollider>();
        mesh.convex = true;

        Ingredient ingred = obj.AddComponent<Ingredient>();
    
        ingred.crossMat = target_ingred.crossMat;
        ingred.sliceCount = target_ingred.sliceCount;
        ingred.sliceCount++;
        ingred.GetComponent<SeasoningIngredient>().pepper_s = target_ingred.GetComponent<SeasoningIngredient>().pepper_s;
        ingred.GetComponent<SeasoningIngredient>().salt_s = target_ingred.GetComponent<SeasoningIngredient>().salt_s;
        ingred.ingredientType = target_ingred.ingredientType;
        ingred.materials = target_ingred.materials;


        obj.AddComponent<Cooking>().limitCookTime = 8;

        obj.AddComponent<XRGrabInteractable>();

        obj.layer = 6;
        obj.tag = "Food";
    }

}
