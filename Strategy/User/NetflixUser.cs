using System;

namespace Strategy.User
{
    /// <summary>
    /// Пользователь сервиса Netflix.
    /// </summary>
    public class NetflixUser
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }


        // Поле хранящее оценку Драмы пользователя.
        private int _dramaAppeal;

        /// <summary>
        /// Оценка Драмы пользователя.
        /// </summary>
        public int DramaAppeal
        { 
            get 
            {
                return _dramaAppeal;
            }

            set
            {
                ValidateAppealValue(value, nameof(DramaAppeal));
                _dramaAppeal = value;
            }
        }


        // Поле хранящее оценку Комедии пользователя.
        private int _comedyAppeal;

        /// <summary>
        /// Оценка Комедии пользователя.
        /// </summary>
        public int ComedyAppeal
        {
            get
            {
                return _comedyAppeal;
            }

            set
            {
                ValidateAppealValue(value, nameof(ComedyAppeal));
                _comedyAppeal = value;
            }
        }


        // Поле хранящее оценку Мюзикла пользователя.
        private int _musicalAppeal;

        /// <summary>
        /// Оценка Мюзикла пользователя.
        /// </summary>
        public int MusicalAppeal
        {
            get
            {
                return _musicalAppeal;
            }

            set
            {
                ValidateAppealValue(value, nameof(MusicalAppeal));
                _musicalAppeal = value;
            }
        }

        /// <summary>
        /// Проверяет, входит ли переданное значение <c>value</c> в диапазон между 0 и 10.
        /// </summary>
        /// <param name="value">Значение для проверки.</param>
        /// <param name="valueName">Название проверяемой переменной, для информации в ошибке.</param>
        private void ValidateAppealValue(int value, string valueName)
        {
            if (value < 0 || value > 10)
            {
                throw new Exception($"Значение {valueName} должно находиться в пределах между 0 и 10.");
            }
        }
    }
}
