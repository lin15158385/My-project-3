using UnityEngine;
using TMPro;

public class TecladoVirtual : MonoBehaviour
{
    [Header("Onde o texto vai aparecer")]
    public TMP_InputField ecraDoPC;

    // Esta função vai ser usada pelos botões dos números (0 a 9)
    public void AdicionarNumero(string numero)
    {
        // Pega no texto que já lá está e acrescenta o novo número à frente
        ecraDoPC.text += numero;
    }

    // Esta função vai ser usada por um botão de "Limpar" ou "Del"
    public void ApagarTudo()
    {
        ecraDoPC.text = ""; // Esvazia a caixa
    }
}