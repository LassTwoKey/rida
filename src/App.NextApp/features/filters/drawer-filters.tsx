"use client"

import {Drawer,DrawerClose,DrawerContent,DrawerTitle,DrawerHeader} from '@/shared/ui/drawer'
import {Checkbox} from "@/shared/ui/checkbox";
import {Button} from "@/shared/ui/button";
import { FC } from "react";
import { X } from "lucide-react";


interface FilterOption {
    title: string;
    content: {
        id: number;
        label: string;
    }[];
}

const DrawerFilters:FC<DrawerFilterProps> = ({options}) => {

    if(!options) return;


    return(
    <Drawer open={!!options}>
        <DrawerContent className='px-3 pb-8'>
          <div className='flex items-center justify-between'>
              <h3 className='text-2xl'>{options.title}</h3>
              <X/>
          </div>
            <div className='grid grid-cols-1 mt-7 gap-3'>
                {options.content && options.content.map(item => (
                    <div key = {item.id} className='flex items-center justify-between'>
                    <p>{item.label}</p>
                    <Checkbox/>
                    </div>
                ))}
            </div>
            <div className='grid grid-cols-2 py-4'>
                <Button variant='transparent'>Сбросить</Button>
                <Button>Применить</Button>
            </div>
        </DrawerContent>
    </Drawer>
    )
}

export default DrawerFilters