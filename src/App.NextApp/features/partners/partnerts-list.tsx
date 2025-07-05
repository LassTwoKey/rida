import Image from "next/image";
import partner from "@/public/banner/partner.jpg";
import { Button } from "@/shared/ui/button";

const PartnertsList = () => {
    return (
        <div className="flex flex-col mt-10">
            <h3 className="uppercase text-2xl font-involve">Новые партнёры</h3>
            <div className="grid grid-cols-1 gap-5 mt-7">
                {Array.from({ length: 3 }).map((_, i) => (
                    <div key={i} className="relative">
                        <Image
                            className="w-full h-[163px] object-cover"
                            src={partner}
                            alt="partner-image"
                        />
                        <div className="absolute top-12 left-4 flex flex-col items-start">
                            <h3 className="text-xl uppercase">Pulsar Optic</h3>
                            <p className="max-w-[150px] text-xs">
                                Очки для вашего уникального стиля.
                            </p>
                        </div>
                    </div>
                ))}
            </div>
            <Button className="mt-4">Смотреть ещё</Button>
        </div>
    );
};

export default PartnertsList;
