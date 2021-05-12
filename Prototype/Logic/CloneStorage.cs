using System;
using System.Collections.Generic;
using System.Text;
using Prototype.Data;

namespace Prototype.Logic
{
    /// <summary>
    /// Хранилище клонов.
    /// </summary>
    public static class CloneStorage
    {
        /// <summary>
        /// Реестр клонов.
        /// </summary>
        private static readonly Dictionary<CloneTag, CloneTrooper> CloneTrooperRegistry = new Dictionary<CloneTag, CloneTrooper>();

        /// <summary>
        /// Реестр обмундирования.
        /// </summary>
        private static readonly Dictionary<EquipmentTag, Equipment> EquipmentRegistry = new Dictionary<EquipmentTag, Equipment>();

        /// <summary>
        ///  При первом использовании хранилища клонов заполняет реестр клонов и
        /// реестр обмундирования клонов.
        /// </summary>
        static CloneStorage()
        {
            InitEquipmentRegistry();
            InitCloneTrooperRegistry();
        }

        /// <summary>
        /// Производит клона согласно его тэгу.
        /// </summary>
        /// <param name="tag">Тэг клона.</param>
        /// <returns>Клон найденный по тэгу.</returns>
        public static CloneTrooper CloneByTag(CloneTag tag)
        {
            CloneTrooperRegistry.TryGetValue(tag, out var clone);

            if (clone == null)
            {
                throw new Exception("Клон с таким тэгом не найден, попробуйте другой.");
            }

            return (CloneTrooper)clone.Clone();
        }

        /// <summary>
        /// Заполнить реестр обмундирования.
        /// </summary>
        private static void InitEquipmentRegistry()
        {
            EquipmentRegistry.Add(EquipmentTag.Radio, new Equipment
            (
                "Настроена на частоту 0.451 МГц", "Прямоугольная армейская рация"
            ));
            EquipmentRegistry.Add(EquipmentTag.RocketLauncher, new Equipment
            (
                "Содержит 4 ракетных заряда", "Выглядит как опасная продолговатая труба"
            ));
            EquipmentRegistry.Add(EquipmentTag.LaserGun, new Equipment
            (
                "Попадает лишь в 50% случаев", "Футуристически выглядящий набор цилиндров и прямоугольников"
            ));
            EquipmentRegistry.Add(EquipmentTag.Binoculars, new Equipment
            (
                "Попадает лишь в 50% случаев", "Футуристически выглядящий набор цилиндров и прямоугольников"
            ));
        }

        /// <summary>
        /// Заполнить реестр клонов.
        /// </summary>
        private static void InitCloneTrooperRegistry()
        {
            CloneTrooperRegistry.Add(CloneTag.Commander, new CloneTrooper
            (
                "На самом деле, я не знаю что делаю", "Командующий", (Equipment)EquipmentRegistry[EquipmentTag.Radio].Clone()
            ));
            CloneTrooperRegistry.Add(CloneTag.HeavyAssault, new CloneTrooper
            (
                "...", "Тяжелый Штурмовик", (Equipment)EquipmentRegistry[EquipmentTag.RocketLauncher].Clone()
            ));
            CloneTrooperRegistry.Add(CloneTag.Assault, new CloneTrooper
            (
                "Эх, сейчас бы в кроватку", "Штурмовик", (Equipment)EquipmentRegistry[EquipmentTag.LaserGun].Clone()
            ));
            CloneTrooperRegistry.Add(CloneTag.Recon, new CloneTrooper
            (
                "Достаточно ли я незаметен?", "Разведчик", (Equipment)EquipmentRegistry[EquipmentTag.Binoculars].Clone()
            ));
        }
    }
}
