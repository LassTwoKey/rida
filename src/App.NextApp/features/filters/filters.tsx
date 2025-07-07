"use client"

import {useState} from "react";
import { FILTERS_LIST,FILTERS_OBJECT} from "@/shared/constants";
import {Button} from "@/shared/ui/button";
import {Carousel,CarouselContent,CarouselItem} from '@/shared/ui/carousel'
import { ChevronDown } from 'lucide-react';
import DrawerFilters from "@/features/filters/drawer-filters";

const Filters = () => {

    const [filterName, setFilterName] = useState<string | null>(null);


    return (
        <>
        <Carousel
            className='w-full'
            opts={{
                align: "start",
                slidesToScroll: 'auto',
            }}>
            <CarouselContent className="flex items-center ml-[1px] justify-between ">
                {FILTERS_LIST.map(item => (
                    <CarouselItem onClick = {() => setFilterName(item.label)} key={item.id} className="basis-auto pl-1">
                        <Button
                            variant='transparent'
                            className='flex text-[11px] items-center border-[0.5px] border-[#00000033] h-[25px] px-2 justify-center gap-1'
                        >
                            {item.title}
                            <ChevronDown size={20} />
                        </Button>
                    </CarouselItem>
                ))}
            </CarouselContent>
        </Carousel>
            {filterName && <DrawerFilters options = {FILTERS_OBJECT[filterName][0]}/>}
        </>
    )
}

export default Filters