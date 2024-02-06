using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrilledSystem : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Texture[] textures;

    private Renderer cubeRenderer;
    private int randomTextureIndex;

    private void Start()
    {
        cubeRenderer = cube.GetComponent<Renderer>();
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeCubeTexture);
    }

    private void ChangeCubeTexture()
    {
        randomTextureIndex = Random.Range(0, textures.Length);
        cubeRenderer.material.mainTexture = textures[randomTextureIndex];
    }
}
