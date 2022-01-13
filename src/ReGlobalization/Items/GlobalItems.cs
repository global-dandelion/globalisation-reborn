using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ReGlobalization.Items
{
    /// <summary>
    /// Здесь занимаемся оригинальными предметами из игры.
    /// </summary>
    internal class GlobalItems : GlobalItem
    {
        #region Constants

        /// <summary>
        /// Идентификатор медной кирки.
        /// </summary>
        private const int COPPER_PICKAXE = 3509;

        /// <summary>
        /// Ключ для сохранения информации о прочности инструмента.
        /// </summary>
        private const string CAPACITY_KEY = "Capacity";

        #endregion

        #region Fields

        /// <summary>
        /// Внутренняя прочность у предмета.
        /// </summary>
        private float? _capacity = null;

        #endregion

        #region Override Methods

        /// <summary>
        /// Загружаем информацию при крафте.
        /// </summary>
        /// <param name="item">Полученный предмет.</param>
        public override void SetDefaults(Item item)
        {
            // Если это кирка.
            if(item.pick > 0) 
                _capacity ??= 0f;
        }

        /// <summary>
        /// В этом методе сохраняем информацию о конкретном предмете (по параметру item).
        /// </summary>
        /// <param name="item">Предмет, для которого сохраняется информация.</param>
        /// <param name="tag">Объект, который позволяет работать с сохранением и загрузкой информации.</param>
        public override void SaveData(Item item, TagCompound tag)
        {
            switch (item.type)
            {
                case COPPER_PICKAXE: tag.Add(CAPACITY_KEY, this._capacity); break;

                default: break;
            }
        }

        /// <summary>
        /// В этом методе загружаем информацию о конкретном предмете (по параметру item).
        /// </summary>
        /// <param name="item">Предмет, для которого загружается информация.</param>
        /// <param name="tag">Объект, который позволяет работать с сохранением и загрузкой информации.</param>
        public override void LoadData(Item item, TagCompound tag)
        {
            switch (item.type)
            {
                case COPPER_PICKAXE: this._capacity = tag.GetFloat(CAPACITY_KEY); break;

                default: break;
            }
        }

        /// <summary>
        /// В этом методе будет происходить логика вычисления значения параметра для прочности инструмента.
        /// </summary>
        /// <param name="item">Предмет, для которого вычисляется прочность.</param>
        /// <param name="player">Объект текущего игрока, который использовал предмет.</param>
        /// <returns></returns>
        public override bool? UseItem(Item item, Player player)
        {
            switch (item.type)
            {
                // А где класс ItemID? Раньше можно было не искать по википедии типы предметов, а по константам находить.
                case COPPER_PICKAXE: { /* TODO: алгоритм изменения прочности. */}; break;
            }

            return true;
        }

        #endregion
    }
}
