using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prototype.Data;
using Prototype.Logic;

namespace Prototype
{
    [TestClass]
    public class PrototypeTests
    {
        /// <summary>
        /// Проверяем, что клоны из хранилища с одним тэгом одинаковы. Но не один и тот же объект
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
        /// Проверяем, что клон клона - одинаковый. Но не один и тот же объект.
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
        /// Проверяем, что разные клоны из хранилища - разные.
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
