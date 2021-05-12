

namespace Adapter.Adaptee.Interface
{
    /// <summary>
    /// Низшее существо, способное к возвышению.
    /// </summary>
    public interface ILesserForm
    {
        /// <summary>
        /// Количество трудностей, которые необходимо преодолеть.
        /// </summary>
        public int DifficultyCount { get; }

        /// <summary>
        /// Преодолевает трудность и сообщает о своем состоянии.
        /// </summary>
        /// <returns>Сообщение о состоянии существа.</returns>
        public string AscendDifficulty();
    }
}
