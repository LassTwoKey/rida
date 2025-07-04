import { ADVANTAGES_LIST } from "@/shared/constants";
import Image from "next/image";


const Advantages = () => {
    return (
        <div className='grid grid-cols-1 gap-4'>
            {ADVANTAGES_LIST.map((item) => (
                <div key = {item.id} className='border border-[#00000033] h-[273px]'>
                    <div className='p-3 flex flex-col gap-1 items-start'>
                        <Image className='w-full h-[184px] object-cover' src={item.img} alt='advantages-image'/>
                        <h3 className='uppercase text-2xl'>{item.title}</h3>
                        <p>{item.desc}</p>
                    </div>
                </div>
            ))}
        </div>
    )
}

export default Advantages;