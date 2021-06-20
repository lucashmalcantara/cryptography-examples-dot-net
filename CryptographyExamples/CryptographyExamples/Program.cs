using CryptographyExamples.Algorithms.Symmetric;
using CryptographyExamples.Algorithms.Symmetric.Enums;
using CryptographyExamples.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CryptographyExamples
{
    class Program
    {
        private const string ExitOptionKey = "0";
        private const string EncryptionKey = "this_is_an_encryption_key_VHbbQ8tS#X?jnWVsLh%JJ_!H?J@LfLea!eM77m*GFb=NEcWr3k";

        private readonly struct CryptographyResult
        {
            public Provider Provider { get; }
            public string OriginalText { get; }
            public string EncryptedText { get; }
            public string DecryptedText { get; }

            public CryptographyResult(
                Provider provider,
                string originalText,
                string encryptedText,
                string decryptedText)
            {
                OriginalText = originalText;
                EncryptedText = encryptedText;
                DecryptedText = decryptedText;
                Provider = provider;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("#### Exemplos Algoritmos de Criptografia ####");

            var symmetricEncryptionOptions = GetAllSymmetricEncrypAlgorithmstionOptions();

            string selectedOptionKey;

            do
            {
                selectedOptionKey = GetSelectedOptionKey(symmetricEncryptionOptions);

                var validOption =
                     symmetricEncryptionOptions.TryGetValue(selectedOptionKey, out Provider selectedProvider);

                if (validOption)
                    ExecuteOption(selectedProvider);
                
                Console.Clear();
            } while (selectedOptionKey != ExitOptionKey);
        }

        private static void ExecuteOption(Provider selectedProvider)
        {
            var textToEncrypt = GetTextToEncrypt();

            var symmetricEncryption = new SymmetricEncryption(selectedProvider, EncryptionKey);
            var encryptedText = symmetricEncryption.Encrypt(textToEncrypt);
            var decryptedText = symmetricEncryption.Decrypt(encryptedText);

            var cryptographyResult = new CryptographyResult(
                selectedProvider, textToEncrypt, encryptedText, decryptedText);

            DescribeResult(cryptographyResult);
            RequestInteraction();
        }

        private static void RequestInteraction()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private static void DescribeResult(CryptographyResult result)
        {
            Console.WriteLine("\r\n\r\n# Resultado #\r\n");
            Console.WriteLine($"Algoritmo: {result.Provider.GetDescription()}");
            Console.WriteLine($"Texto original: {result.OriginalText}");
            Console.WriteLine($"Texto criptografado: {result.EncryptedText}");
            Console.WriteLine($"Texto descriptografado: {result.DecryptedText}");
            Console.WriteLine("\r\n");
        }

        private static string GetTextToEncrypt()
        {
            Console.WriteLine("\r\nDigite o texto a ser criptografado:");
            return Console.ReadLine();
        }

        private static string GetSelectedOptionKey(IDictionary<string, Provider> symmetricEncryptionOptions)
        {
            DescribeAllOptions(symmetricEncryptionOptions);
            return Console.ReadLine();
        }

        private static void DescribeAllOptions(IDictionary<string, Provider> symmetricEncryptionOptions)
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("         OPÇÕES DE ALGORITMOS");
            Console.WriteLine("-------------------------------------------");

            foreach (var option in symmetricEncryptionOptions)
                Console.WriteLine($"{option.Key} - {option.Value.GetDescription()}");

            Console.WriteLine($"{ExitOptionKey} - Sair");
            Console.WriteLine("\r\nDigite o número do algoritmo desejado: ");
        }

        private static IDictionary<string, Provider> GetAllSymmetricEncrypAlgorithmstionOptions()
        {
            var allProviders = EnumerationsHelper.GetValues<Provider>();
            var providerCount = allProviders.Count();

            var symmetricEncryptionOptions = new Dictionary<string, Provider>();

            for (int i = 0; i < providerCount; i++)
            {
                var optionKey = (i + 1).ToString();
                symmetricEncryptionOptions.Add(optionKey, allProviders.ElementAt(i));
            }

            return symmetricEncryptionOptions;
        }
    }
}
