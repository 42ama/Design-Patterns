using DI_IoC_Autofac.BodyPart.Interface;

namespace DI_IoC_Autofac.BodyPart.Implementation
{
    /// <summary>
    /// Мозг, считающий количество созданных экземпляров данного класса.
    /// </summary>
    public class MetaBrain : IBrain
    {
        /// <summary>
        /// Количество экземпляров данного класса.
        /// </summary>
        private static int _instancesCount = 0;

        /// <summary>
        /// Номер текущего экземпляра.
        /// </summary>
        private int _instanceNumber;

        public MetaBrain()
        {
            _instancesCount++;
            _instanceNumber = _instancesCount;
            
        }

        /// <summary>
        /// Возвращает мысль с информацией об созданных экземплярах данного класса.
        /// </summary>
        /// <returns>Мысль с информацией об созданных экземплярах данного класса.</returns>
        public string ProduceThought()
        {
            return $"I'm brain №{_instanceNumber}, I have {_instancesCount - 1} brothers.";
        }
    }
}
