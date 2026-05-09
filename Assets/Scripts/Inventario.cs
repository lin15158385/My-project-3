using UnityEngine;
using UnityEngine.UI; // Precisamos disto para mexer em Imagens!

public class Inventario : MonoBehaviour
{
    // Uma lista com os ícones da nossa UI
    public Image[] iconesDosSlots;

    // Um contador para saber quantos itens já apanhámos
    private int itensGuardados = 0;

    // Esta função vai ser chamada pelos itens 3D
    public void AdicionarItem(Sprite imagemDoItem)
    {
        // Verifica se ainda temos espaço (se não chegámos ao limite dos slots)
        if (itensGuardados < iconesDosSlots.Length)
        {
            // Pega no próximo slot vazio e muda a imagem dele para a do item apanhado
            iconesDosSlots[itensGuardados].sprite = imagemDoItem;

            // Ativa (torna visível) a imagem nesse slot
            iconesDosSlots[itensGuardados].gameObject.SetActive(true);

            // Aumenta o número de itens guardados
            itensGuardados++;

            Debug.Log("Item adicionado ao inventário!");
        }
        else
        {
            Debug.Log("O inventário está cheio!");
        }
    }
    // Nova função: A porta vai usar isto para verificar se tens a chave
    public bool TemItem(Sprite imagemProcurada)
    {
        // Vai procurar em todos os slots do teu inventário
        for (int i = 0; i < iconesDosSlots.Length; i++)
        {
            // Se encontrar a imagem da chave num slot que está ativo...
            if (iconesDosSlots[i].sprite == imagemProcurada && iconesDosSlots[i].gameObject.activeSelf)
            {
                return true; // Sim, tens a chave!
            }
        }
        return false; // Não, não tens a chave.
    }
}
