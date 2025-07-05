import Image from "next/image";
import third from "@/public/banner/fourth.png";
import fourth from "@/public/banner/third.png";

const DeliveryPartners = () => {
    return (
        <div className="flex flex-col gap-2 items-start">
            <h3 className="uppercase text-[32px]">Партнеры по доставке</h3>
            <p className="text-[#000000]">
                Quisque ultrices nec massa nec pretium. Curabitur quis quam accumsan, vestibulum
                libero vel, porta erat. Quisque id turpis placerat, malesuada orci vitae, facilisis
                leo.
            </p>
            <div className="flex flex-col mt-5 w-full gap-5">
                <Image className="w-full h-[250px] object-cover" src={third} alt="partners-image" />
                <Image
                    className="w-full h-[250px] object-cover"
                    src={fourth}
                    alt="partners-image"
                />
            </div>
        </div>
    );
};

export default DeliveryPartners;
