import BasketItems from "@/features/basket/basket-items";

const Basket = () => {
    return (
        <div className="flex flex-col gap-3 mt-5">
            <h2 className="uppercase text-[32px]">Корзина</h2>
            <BasketItems />
        </div>
    );
};

export default Basket;
