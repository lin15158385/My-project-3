using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public Image[] iconesDosSlots;
    private int itensGuardados = 0;

    [Header("Interface do Jogo")]
    public GameObject canvasDoInventario;
    public GameObject canvasDoPonto;

    public void LigarInterface()
    {
        if (canvasDoInventario != null) canvasDoInventario.SetActive(true);
        if (canvasDoPonto != null) canvasDoPonto.SetActive(true);
    }

    public void AdicionarItem(Sprite imagemDoItem)
    {
        for (int i = 0; i < iconesDosSlots.Length; i++)
        {
            // CORREÇÃO AQUI: Se o slot estiver desativado OU não tiver imagem nenhuma (null), ele está livre!
            if (iconesDosSlots[i].gameObject.activeSelf == false || iconesDosSlots[i].sprite == null)
            {
                iconesDosSlots[i].sprite = imagemDoItem;
                iconesDosSlots[i].gameObject.SetActive(true);
                itensGuardados++;
                Debug.Log("Item adicionado ao inventário!");
                return; // Pára o código aqui
            }
        }

        Debug.LogWarning("O inventário está cheio!");
    }

    public bool TemItem(Sprite imagemProcurada)
    {
        for (int i = 0; i < iconesDosSlots.Length; i++)
        {
            if (iconesDosSlots[i].sprite == imagemProcurada && iconesDosSlots[i].gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoverItem(Sprite imagemParaRemover)
    {
        for (int i = 0; i < iconesDosSlots.Length; i++)
        {
            if (iconesDosSlots[i].sprite == imagemParaRemover)
            {
                iconesDosSlots[i].sprite = null;
                iconesDosSlots[i].gameObject.SetActive(false);
                itensGuardados--;
                Debug.Log("Item removido do inventário!");
                return;
            }
        }
    }
} 