import { Button } from "@/shared/ui/button"
import Image from "next/image";
import Link from "next/link";
import banner from "@/public/banner/banner.png";
import essenza from "@/public/banner/essenza.png";

const Banner = () => {
    return (
        <div className="relative my-6">
            <Image alt="banner-image" className="w-full relative min-h-[315px]" src={banner} />
            <div className="absolute top-2 left-3 flex gap-5 flex-col items-start">
                <Image src={essenza} alt="essenza" />
                <p className="uppercase">
                    <span className="text-2xl">Поделитесь</span>
                    <br />
                    промокодом — получайте бонусы
                </p>
                <p className="uppercase text-sm">
                    Отправьте его другу — и он получит скидку 10% на первый заказ.
                </p>
                <Link href='/catalog' className='m-auto w-[96%]'>
                <Button className="h-12 w-[96%]">Перейти в каталог</Button>
                </Link>
            </div>
        </div>
    );
};

export default Banner;
