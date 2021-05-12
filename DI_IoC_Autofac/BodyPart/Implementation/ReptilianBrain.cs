using DI_IoC_Autofac.BodyPart.Interface;

namespace DI_IoC_Autofac.BodyPart.Implementation
{
    /// <summary>
    /// Простейший мозг.
    /// </summary>
    public class ReptilianBrain : IBrain
    {
        /// <summary>
        /// Возвращает простейшую мысль.
        /// </summary>
        /// <returns>Простейшая мысль.</returns>
        public string ProduceThought()
        {
            return "Warm, primordial soup... Blackness-s...";
        }
    }
}
