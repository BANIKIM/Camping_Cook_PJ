using UnityEngine;

public interface IState
{
    void OnEnter();
    void OnUpdate();
    void OnExit();
}

public enum IngredientType
{
    Beef = 1,
    Marshmallow,
    Salmon,
    Potato,
    Carrot,
    Onion,
    Asparagus,
    Mushroom,
}

[RequireComponent(typeof(CookedIngredient))]
[RequireComponent(typeof(SeasoningIngredient))]
[RequireComponent(typeof(SkewerIngredient))]

public class Ingredient : MonoBehaviour
{
    public IngredientType ingredientType;
    public CookedIngredient cookedIngred;
    public SeasoningIngredient seasoningIngred;
    public SkewerIngredient skewerIngred;

    public int sliceCount = 0;

    public Material crossMat;
    public Material[] materials;
    public MeshRenderer mesh;

    private void Start()
    {
        TryGetComponent(out seasoningIngred);
        TryGetComponent(out cookedIngred);
        TryGetComponent(out skewerIngred);
        mesh = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        cookedIngred.OnUpdate();
        skewerIngred.OnUpdate();
    }

    public void Cook_ch_mat()// 쿡스테이터스에 따라 머테리얼 값을 변경한다
    {
        mesh.material = materials[(int)cookedIngred.cookedState];
    }

    public int CheckCookIdx()
    {
        var _ingred_type = ((int)ingredientType * 10) + ((int)cookedIngred.cookedState);
        return _ingred_type;
    }

    public int CheckPrepIdx()
    {
        var _temp = sliceCount.Equals(0) ? 0 : 1;
        var _ingred_type = ((int)ingredientType * 10000) + (_temp * 1000) +
            ((int)seasoningIngred.salt_s * 100) + ((int)seasoningIngred.pepper_s * 10) +
            ((int)skewerIngred.skewer_state);
        return _ingred_type;
    }
}
