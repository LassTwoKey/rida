import banner from '@/public/banner/banner.png'
import essenza from '@/public/banner/essenza.png'
import Image from "next/image";
import { Button } from "@/shared/ui/button";

const Banner = () => {
    return (
        <div className='relative '>
            <Image alt = 'banner-image' className='w-full relative min-h-[315px]' src = {banner}/>
            <div className='absolute top-2 left-3 flex gap-5 flex-col items-start'>
               <Image src={essenza} alt='essenza'/>
               <p className='uppercase'><span className='text-2xl'>Поделитесь</span><br/>промокодом — получайте бонусы</p>
                <p className='uppercase text-sm'>Отправьте его другу — и он получит скидку 10% на первый заказ.</p>
                <Button className='h-12 w-[96%]'>Перейти в каталог</Button>
            </div>
        </div>
    )
}

export default Banner;