using System.ComponentModel;

namespace CryptographyExamples.Algorithms.Symmetric.Enums
{
    public enum Provider
    {
        /// <summary>
        /// Representa a classe base para implementações criptografia dos algoritmos simétricos Rijndael.
        /// </summary>
        [Description("Rijndael")]
        Rijndael,

        /// <summary>
        /// Representa a classe base para implementações do algoritmo RC2.
        /// </summary>
        [Description("RC2")]
        RC2,

        /// <summary>
        /// Representa a classe base para criptografia de dados padrões (DES - Data Encryption Standard).
        /// </summary>
        [Description("DES - Data Encryption Standard")]
        DES,

        /// <summary>
        /// Representa a classe base (TripleDES - Triple Data Encryption Standard).
        /// </summary>
        [Description("TripleDES - Triple Data Encryption Standard")]
        TripleDES
    }
}
