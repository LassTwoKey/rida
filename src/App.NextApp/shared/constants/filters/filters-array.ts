const NEW_ARRAY = [
    {
        title: "Новинки",
        content: [
            { id: 1, label: "Pre-teen and young adult" },
            { id: 2, label: "Fashion colors and design" },
            { id: 3, label: "Competitive Price Point" }
        ]
    }
];

const MATERIALS_ARRAY = [
    {
        title: "Материал оправы",
        content: [
            { id: 1, label: "Пластик" },
            { id: 2, label: "Металл" },
            { id: 3, label: "Комбинированные" },
            { id: 4, label: "Дерево" },
            { id: 5, label: "Титановые" },
            { id: 6, label: "Солнцезащитные" }
        ]
    }
];

const TYPE_ARRAY = [
    {
        title: "Тип",
        content: [
            { id: 1, label: "Мужской" },
            { id: 2, label: "Женский" },
            { id: 3, label: "Детский" }
        ]
    }
];

const COLOR_ARRAY = [
    {
        title: "Цвет",
        content: [
            { id: 1, label: "Чёрный" },
            { id: 2, label: "Белый" },
            { id: 3, label: "Серый" },
            { id: 4, label: "Синий" },
            { id: 5, label: "Коричневый" },
            { id: 6, label: "Красный" }
        ]
    }
];

export const FILTERS_OBJECT = {
    new: NEW_ARRAY,
    material: MATERIALS_ARRAY,
    type: TYPE_ARRAY,
    color: COLOR_ARRAY
};
