import logo from '@/public/banner/essenza.png'
import { Carousel, CarouselContent, CarouselItem, CarouselPrevious, CarouselNext } from "@/shared/ui/carousel";
import { Button } from "@/shared/ui/button";
import Image from "next/image";

const BrandsPartners = () => {
    return (
        <Carousel
            className='w-full'
            opts={{
                align: "start",
                slidesToScroll: 1,
            }}
        >
            <CarouselContent>
                {Array.from({length: 7}).map((_, i) => (
                    <CarouselItem className='flex flex-col ml-2 max-w-[80px] h-[80px] items-center rounded-full' key={i}>
                        <Button className='border border-gray-500 h-[80%] w-full' variant='circle'>
                            <Image src={logo} alt='brand-logo' width={32} height={32}/>
                        </Button>
                        <p className='text-sm'>ESSENZA</p>
                    </CarouselItem>
                ))}
            </CarouselContent>
        </Carousel>
    )
}

export default BrandsPartners;