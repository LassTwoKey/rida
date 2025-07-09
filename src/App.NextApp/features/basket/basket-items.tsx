import Image from "next/image";
import glass from "@/public/card/glass.png";
import { Button } from "@/shared/ui/button";
import { Checkbox } from "@/shared/ui/checkbox";
import { Heart, Minus, Plus, X } from "lucide-react";

const BasketItems = () => {
    return (
        <div className="flex flex-col gap-3">
            <div className="flex justify-between items-center">
                <h4 className="font-semibold">Ваша корзина</h4>
                <p className="text-gray-500">1 ITEM</p>
            </div>
            <div className="flex justify-between items-center">
                <div className="flex items-center gap-2">
                    <Checkbox className="rounded-full border-gray-400 " />
                    <p>Выбрать все</p>
                </div>
                <p>Удалить выбранные</p>
            </div>
            <div className="flex gap-5  mt-5">
                <div className="relative">
                    <Image
                        className="relative min-w-[205px] h-[151px]"
                        src={glass}
                        alt="basket-item"
                    />
                    <Checkbox className="absolute top-2 left-2 rounded-full border-gray-400" />
                </div>
                <div className="flex justify-between w-full">
                    <div className="flex flex-col items-start">
                        <h3 className="#000000">ESSENZA</h3>
                        <p className="text-gray-400 text-sm">ESS1045</p>
                        <p className="text-gray-400 text-sm">52-18-140</p>
                        <div className="my-3 w-[90px] h-[36px] border border-gray-400 flex items-center justify-between p-2">
                            <Minus size={20} />
                            <p>1</p>
                            <Plus size={20} />
                        </div>
                        <Heart size={20} color="gray" />
                    </div>
                    <div className="flex">
                        <X />
                    </div>
                </div>
            </div>
            <Button className="my-4">Оформить заказ</Button>
        </div>
    );
};

export default BasketItems;
