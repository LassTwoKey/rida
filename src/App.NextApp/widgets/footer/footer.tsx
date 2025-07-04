'use client';

import { FOOTER_LIST } from "@/shared/constants";
import Link from "next/link";
import Image from 'next/image'

const Footer = () => {
    return (
        <div className='fixed bottom-0 left-0 bg-white w-full h-[60px]'>
            <div className='grid grid-cols-4 gap-4 justify-between py-3 px-8'>
                {FOOTER_LIST.map(item => (
                    <Link href={item.link} key={item.id} className='bg-transparent flex justify-center items-center border-none'>
                        <Image className='h-[32px] w-[32px]' alt = 'footer-icon' src={item.icon} height={32} width={32} />
                    </Link>
                ))}
            </div>
        </div>
    )
}

export default Footer;