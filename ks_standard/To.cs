using System;
using System.Text.RegularExpressions;

namespace KS_Standard
{
    /// <summary>
    /// Conversores
    /// </summary>
    public partial class To
    {
        private object _value;
        private string _value1;

        public To(object value)
        {
            _value = value;
            _value1 = value.ToString();
        }

        /// <summary>
        /// Converte para inteiro
        /// </summary>
        /// <param name="isnull">caso objeto for nulo, será substituido pelo valor</param>
        /// <returns></returns>
        public int ToInt(int isnull = 0)
        {
            try
            {
                return int.Parse(OnlyNumbers());
            } catch
            {
                return isnull;
            }
        }
    }

    /// <summary>
    /// Transformadores
    /// </summary>
    public partial class To
    {
        /// <summary>
        /// Retorna apenas os números da string.
        /// </summary>
        /// <returns></returns>
        public string OnlyNumbers()
        {
            if (String.IsNullOrEmpty(_value1))
                return null;
            else
                return String.Join("", System.Text.RegularExpressions.Regex.Split(_value1, @"[^\d]"));
        }

        /// <summary>
        /// Remove os espaços excedentes entre:
        /// - Inicio;
        /// - Fim;
        /// - Meio
        /// </summary>
        /// <returns></returns>
        public string Trim()
        {
            Regex regex = new Regex(@"\s{2,}");
            return regex.Replace(_value1, " ").Trim();
        }
    }

    /// <summary>
    /// Formatadores
    /// </summary>
    public partial class To
    {

        public string FrmtTo(string mask)
        {
            try
            {
                return Convert.ToUInt64(OnlyNumbers()).ToString(@"00\.000\.000\/0000\-00");
            }
            catch (Exception ex)
            {
                throw new KSException(ex, messages.m00001_2, _value1);
            }
        }

        public string FrmtToCNPJ()
        {
            return FrmtTo(@"00\.000\.000\/0000\-00");
        }

        public string FrmtToCPF()
        {
            try
            {
                return Convert.ToUInt64(OnlyNumbers()).ToString(@"00\.000\.000\/0000\-00");
            }
            catch (Exception ex)
            {
                throw new KSException(ex, messages.m00001_2, _value1);
            }
        }

        /// <summary>
        /// Faz abreviação do valor de forma inteligente
        /// </summary>
        /// <param name="max_word">Número máximo de palavras</param>
        /// <param name="ignore_word_min">Não contar se a palavra ter o tamanho</param>
        /// <returns></returns>
        public string FrmtAbbrev(int max_word = 3, int ignore_word_min = 2)
        {
            var names = Trim().Split(' ');
            var name = String.Empty;

            for (int i = 0; i < names.Length; i++)
            {
                if (i >= max_word)
                    break;

                name += names[i].Trim() + " ";

                // Não será contato as palavras com menos de ignore_word_min caracteres
                if (names[i].Length <= ignore_word_min)
                    max_word += 1;


            }

            return name.Trim();
        }
    }
}
