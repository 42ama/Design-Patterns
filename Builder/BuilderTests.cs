using System.Collections.Generic;
using System.Text;
using Builder.Data;
using Builder.Logic;
using Builder.Logic.Builder;
using Builder.Logic.Director;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Builder
{
    /// <summary>
    /// ������������� ��� ������ ������� �����.
    /// </summary>
    [TestClass]
    public class BuilderTests
    {
        /// <summary>
        /// ���.
        /// </summary>
        private Bar _bar { get; set; }

        /// <summary>
        /// ������� ������.
        /// </summary>
        private IBartender _cheapBartender { get; set; }

        /// <summary>
        /// ���������������� � ������� ������.
        /// </summary>
        private IBartender _professionalBartender { get; set; }

        /// <summary>
        /// ��������� ������ ������� ��������� ��� ���������.
        /// </summary>
        private readonly Dictionary<string, string> _cheapCocktailsReference = new Dictionary<string, string>()
        {
            {
                CocktailNames.WhiteRussian,
                @"����������� ������� �����, ����� ������� ��� �����.
����������� ���� �������� �������, ���� � ���-�� ��������.
���� ������� ������� �������� �����.
����� ������������ �� ������ ������ �������� ������������, ��� ��������� ���.
������� ������ ��������� �� ������������.

�������:
�-�-�! ��� �� ����� �������."
            },
            {
                CocktailNames.B52,
                @"����������� ���� �������� �������, ���� � ���-�� ��������.
����������� ���� �������� �������, ���� � ���-�� ��������.
����������� ���� ������ � ������������ ����.
�������� � ������� ��������� ��������� �� ����.

�������:
�-�-�! ��� �� �52."

            },
            {
                CocktailNames.LongIcelandIceTea,
                @"����������� ���� ������ � ����� ���.
����������� ������� �����, ����� ������� ��� �����.
����������� ���� ����-�� ������������� �����.
����������� ���� ����-�� ������������� �����.
����������� ���� ������ � ������������ ����.
����������� ��������� �������� � �������
�����������, ��� ������� ���������� ���������.
����������� ���� ����-����.
����� ������������ �� ������ ������ �������� ������������, ��� ��������� ���.
������� ������ ��������� �� ������������.

�������:
�-�-�! ��� �� ��� ����-������ ��."
            },
            {
                CocktailNames.Appletini,
                @"����������� ������� �����, ����� ������� ��� �����.
����������� ��������� �������� � �������
����������� ������� ������������� �������� ���.
����������� ������� �������� ����, ��� ����� �������� ���� � �������� ���.
�����������, ��� ������� ���������� ���������.
����� ������������ �� ������ ������ �������� ������������, ��� ��������� ���.
������� ������ ��������� �� ������������.

�������:
�-�-�! ��� �� ��������."
            }
        };

        /// <summary>
        /// ��������� ������ ���������������� ��������� ��� ���������.
        /// </summary>
        private readonly Dictionary<string, string> _professionalCocktailsReference = new Dictionary<string, string>()
        {
            {
                CocktailNames.WhiteRussian,
                @"����������� ������� �����, ����� ������� ��� �����.
����������� ���� �������� �������, ���� � ���-�� ��������.
���� ������� ������� �������� �����.
�������� ������ �������� �����, ��� ������ ��� �������.
������� ������ ��������� �� ������������.

�������:
�-�-�! ��� �� ����� �������."
            },
            {
                CocktailNames.B52,
                @"����������� ���� �������� �������, ���� � ���-�� ��������.
����������� ���� �������� �������, ���� � ���-�� ��������.
����������� ���� ������ � ������������ ����.
�������� � ������� ��������� ��������� �� ����.

�������:
�-�-�! ��� �� �52."

            },
            {
                CocktailNames.LongIcelandIceTea,
                @"����������� ���� ������ � ����� ���.
����������� ������� �����, ����� ������� ��� �����.
����������� ���� ����-�� ������������� �����.
����������� ���� ����-�� ������������� �����.
����������� ���� ������ � ������������ ����.
����������� ��������� �������� � �������
�����������, ��� ������� ���������� ���������.
����������� ���� ����-����.
�������� ������ �������� �����, ��� ������ ��� �������.
������� ������ ��������� �� ������������.

�������:
�-�-�! ��� �� ��� ����-������ ��."
            },
            {
                CocktailNames.Appletini,
                @"����������� ������� �����, ����� ������� ��� �����.
����������� ��������� �������� � �������
����������� ������� ������������� �������� ���.
����������� ������� �������� ����, ��� ����� �������� ���� � �������� ���.
�����������, ��� ������� ���������� ���������.
�������� ������ �������� �����, ��� ������ ��� �������.
������� ������ ��������� �� ������������.

�������:
�-�-�! ��� �� ��������."
            }
        };

        /// <summary>
        /// ���������� ��������� ����� ������ ������.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _bar = new Bar();
            _cheapBartender = new CheapBartender();
            _professionalBartender = new ProfessionalBartender();
        }

        #region CheapBartender

        /// <summary>
        /// ����� ������� � �������� ������� ����� �������.
        /// </summary>
        [TestMethod]
        public void CheapBartender_WhiteRussian_EqualToReference()
        {
            // Arrange
            var expected = _cheapCocktailsReference[CocktailNames.WhiteRussian];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareWhiteRussian(_cheapBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// �52 � �������� ������� ����� �������.
        /// </summary>
        [TestMethod]
        public void CheapBartender_B52_EqualToReference()
        {
            // Arrange
            var expected = _cheapCocktailsReference[CocktailNames.B52];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareB52(_cheapBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ���� ������ ��� �� � �������� ������� ����� �������.
        /// </summary>
        [TestMethod]
        public void CheapBartender_LongIcelandIceTea_EqualToReference()
        {
            // Arrange
            var expected = _cheapCocktailsReference[CocktailNames.LongIcelandIceTea];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareLongIcelandIceTea(_cheapBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ������� � �������� ������� ����� �������.
        /// </summary>
        [TestMethod]
        public void CheapBartender_Appletini_EqualToReference()
        {
            // Arrange
            var expected = _cheapCocktailsReference[CocktailNames.Appletini];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareAppletini(_cheapBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region ProfessionalBartender

        /// <summary>
        /// ����� ������� � ����������������� ������� ����� �������.
        /// </summary>
        [TestMethod]
        public void ProfessionalBartender_WhiteRussian_EqualToReference()
        {
            // Arrange
            var expected = _professionalCocktailsReference[CocktailNames.WhiteRussian];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareWhiteRussian(_professionalBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// �52 � ����������������� ������� ����� �������.
        /// </summary>
        [TestMethod]
        public void ProfessionalBartender_B52_EqualToReference()
        {
            // Arrange
            var expected = _professionalCocktailsReference[CocktailNames.B52];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareB52(_professionalBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ���� ������ ��� �� � ����������������� ������� ����� �������.
        /// </summary>
        [TestMethod]
        public void ProfessionalBartender_LongIcelandIceTea_EqualToReference()
        {
            // Arrange
            var expected = _professionalCocktailsReference[CocktailNames.LongIcelandIceTea];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareLongIcelandIceTea(_professionalBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ������� � ����������������� ������� ����� �������.
        /// </summary>
        [TestMethod]
        public void ProfessionalBartender_Appletini_EqualToReference()
        {
            // Arrange
            var expected = _professionalCocktailsReference[CocktailNames.Appletini];
            expected = expected.Trim();

            // Act
            var actual = _bar.PrepareAppletini(_professionalBartender);
            actual = actual.Trim();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        /// <summary>
        /// ���� ������� ��� �� � �������� � �������� �������� ����������.
        /// </summary>
        [TestMethod]
        public void BartendersCompare_LongIcelandIceTea_DifferentResult()
        {
            //  �����-�� �������� ����� ���������� �����������, �� ����� �������
            // ����-������� ��� �� ����� ����� ������ � �������� � ����������������� �������.

            // Act
            var cheapLongIcelandIceTea = _bar.PrepareLongIcelandIceTea(_cheapBartender);
            var professionalLongIcelandIceTea = _bar.PrepareLongIcelandIceTea(_professionalBartender);

            // Assert
            Assert.AreNotEqual(cheapLongIcelandIceTea, professionalLongIcelandIceTea);
        }
    }
}
