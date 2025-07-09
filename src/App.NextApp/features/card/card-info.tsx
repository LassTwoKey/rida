"use client";

import { useState } from "react";
import Image from "next/image";
import { CARD_INFORMATION } from "@/shared/constants";
import { Button } from "@/shared/ui/button";
import { CircleQuestionMark, Star } from "lucide-react";

const CardInfo = () => {
    const [tab, setTab] = useState("Описание");

    const cardData = {
        Описание: CARD_INFORMATION.description,
        Характеристика: CARD_INFORMATION.characteristic,
        Доставка: CARD_INFORMATION.delivery
    };

    return (
        <div className="flex flex-col gap-3">
            <div className="flex flex-col">
                <Image className="w-full" src={CARD_INFORMATION.images[0]} alt="card" />
                <div className="grid grid-cols-2 my-3">
                    {CARD_INFORMATION.images.slice(1, 3).map((image, i) => (
                        <Image
                            className="max-h-[108px] object-cover"
                            src={image}
                            alt="card-images"
                            key={i}
                        />
                    ))}
                </div>
                <div className="flex flex-col gap-5 text-xl my-6">
                    <h4 className="text-[16px] text-[#10A200]">В наличии</h4>
                    <h4 className="font-bold">А-132</h4>
                    <h4>Коричневый/Золотой - BRN</h4>
                    <h4>53 - 16 - 140</h4>
                </div>
                <div className="flex items-center gap-3">
                    {Array.from({ length: 4 }).map((_, i) => (
                        <div className="bg-black h-4 w-4 rounded-full" key={i} />
                    ))}
                </div>
                <div className="grid grid-cols-2 my-6 gap-3 ">
                    <Button className="bg-transparent text-black h-[60px] border border-[#00000033] flex flex-col gap-1">
                        <Star size={20} />
                        Отзывы
                    </Button>
                    <Button className="bg-transparent text-black  h-[60px] border border-[#00000033] flex flex-col gap-1">
                        <CircleQuestionMark size={20} />
                        Вопросы
                    </Button>
                </div>
                <div className="border border-[#00000033] min-h-[60px] w-full p-2 mb-8">
                    <div className="grid grid-cols-3">
                        {["Описание", "Характеристика", "Доставка"].map((item, i) => (
                            <Button
                                onClick={() => setTab(item)}
                                variant={item === tab ? "default" : "transparent"}
                                className="max-h-[30px]"
                                key={i}
                            >
                                {item}
                            </Button>
                        ))}
                    </div>
                    <p className="mt-3">{cardData[tab]}</p>
                </div>
                <div className="mb-5 uppercase">
                    <Button>Добавить в корзину</Button>
                </div>
            </div>
        </div>
    );
};

export default CardInfo;
