using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prototype.Data;
using Prototype.Logic;

namespace Prototype
{
    [TestClass]
    public class PrototypeTests
    {
        /// <summary>
        /// ���������, ��� ����� �� ��������� � ����� ����� ���������. �� �� ���� � ��� �� ������
        /// </summary>
        [TestMethod]
        public void ClonesWithSameTagFromCloningTanks_AreEqualNotSame()
        {
            var commanderA = CloneStorage.CloneByTag(CloneTag.Commander);
            var commanderB = CloneStorage.CloneByTag(CloneTag.Commander);

            Assert.AreEqual(commanderA, commanderB);
            Assert.AreNotSame(commanderA, commanderB);
        }

        /// <summary>
        /// ���������, ��� ���� ����� - ����������. �� �� ���� � ��� �� ������.
        /// </summary>
        [TestMethod]
        public void CloneFromClone_AreEqualNotSame()
        {
            var heavyAssaultA = CloneStorage.CloneByTag(CloneTag.HeavyAssault);
            var heavyAssaultB = (CloneTrooper)heavyAssaultA.Clone();

            Assert.AreEqual(heavyAssaultA, heavyAssaultB);
            Assert.AreNotSame(heavyAssaultA, heavyAssaultB);
        }

        /// <summary>
        /// ���������, ��� ������ ����� �� ��������� - ������.
        /// </summary>
        [TestMethod]
        public void DifferentClonesFromCloningTanks_AreNotEqual()
        {
            var assault = CloneStorage.CloneByTag(CloneTag.Assault);
            var recon = CloneStorage.CloneByTag(CloneTag.Recon);

            Assert.AreNotEqual(assault, recon);
        }
    }
}
