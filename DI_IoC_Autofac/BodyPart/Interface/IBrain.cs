

namespace DI_IoC_Autofac.BodyPart.Interface
{
    /// <summary>
    /// Интерфейс объединяющий все мозги.
    /// </summary>
    public interface IBrain
    {
        /// <summary>
        /// Производит мысль определенной сложности.
        /// </summary>
        /// <returns>Мысль определенной сложности.</returns>
        public string ProduceThought();
    }
}
