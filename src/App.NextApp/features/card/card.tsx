import {Heart,Star,ShoppingBasket} from 'lucide-react'
import { Button } from "@/shared/ui/button";
import glass from '@/public/card/glass.png'
import Image from 'next/image'


const Card = () => {
    return (
        <div className='w-full min-h-[321px] bg-white border border-gray-500'>
        <div className='flex flex-col gap-2 p-2'>
            <div className='flex justify-between items-center'>
               <span className='p-1 border border-black rounded-full'>Essanza</span>
                <Heart size={20} color = 'black'/>
             </div>
             <div className='flex justify-center items-center'>
                 <Image src = {glass} alt = 'card-icons'/>
             </div>
           <h3 className='font-semibold'>Essanza</h3>
            <p className='text-xs text-[#999999]'>ESS1045</p>
            <p className='text-xs'>54-14-140</p>
            <div className='flex gap-1 items-center'>
                <div className='bg-black h-4 w-4 rounded-full'/>
                <div className='bg-black h-4 w-4 rounded-full'/>
                <div className='bg-black h-4 w-4 rounded-full'/>
                <div className='bg-black h-4 w-4 rounded-full'/>
            </div>
            <p className='text-[#109104] text-xs font-semibold'>В наличии</p>
            <div className='flex items-center gap-2'>
                <Star color='#FBC531' fill='#FBC531' size = {20}/>
                <p>4,2</p>
            </div>
            <div className='flex justify-center items-center'>
              <Button className='cursor-pointer flex justify-center items-center'>
                  <ShoppingBasket color = 'white'/>
                  <p>16 апреля</p>
              </Button>
            </div>
        </div>
        </div>
    )
}

export default Card;